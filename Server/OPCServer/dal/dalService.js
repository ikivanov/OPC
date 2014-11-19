var MongoClient = require('mongodb').MongoClient;
var assert = require('assert');
var format = require('util').format;

var cfg = global.getConfig();
var replicaSet = cfg.replicaSet;

getConnectionString = function () {
    if (replicaSet.active) {
        return format("mongodb://%s,%s,%s/%s?replicaSet=%s&readPreference=%s"
                        , replicaSet.primary
                        , replicaSet.secondary
                        , replicaSet.arbiter
                        , cfg.db_name
                        , replicaSet.replicationName
                        , replicaSet.readPreference);
    }

    //"mongodb://localhost:27017/opc";
    return format("mongodb://%s:%s/%s"
        , cfg.mongo_host
        , cfg.mongo_port
        , cfg.db_name
    );
}

exports.select = function (collectionName, condition) {
    return new SelectStatement(collectionName, condition);
}

exports.executeSelect = function (select, callback) {
    new SelectExecuter().execute(select, function (err, results) {
        assert.equal(null, err);
        
        if (callback) {
            callback(err, results);
        }
    });
}

exports.insert = function (collectionName, object, callback) {
    MongoClient.connect(getConnectionString(), function (err, db) {
        db.collection(collectionName).insert([object], { w: 1 }, function (err, result) {
            assert.equal(null, err);
            
            if (callback) {
                callback(err, result);
            }
            
            db.close();
        });
    });
}

exports.update = function (collectionName, condition, object, callback) {
    MongoClient.connect(getConnectionString(), function (err, db) {
        db.collection(collectionName).update(condition, object, function (err, result) {
            assert.equal(null, err);
            
            if (callback) {
                callback(err, result);
            }
            
            db.close();
        });
    });
}


exports.remove = function (collectionName, condition, callback) {
    MongoClient.connect(getConnectionString(), function (err, db) {
        db.collection(collectionName).remove(condition, { w: 1 }, function (err, numberOfRemovedDocs) {
            assert.equal(null, err);
            
            if (callback) {
                callback(err, numberOfRemovedDocs);
            }
            
            db.close();
        });
    });
}

var Callback = function (scope, func) {
    this.scope = scope;
    this.func = func;
}

var SelectStatement = function (collection, condition) {
    this.collection = collection;
    this.condition = condition;
    this.parent = null;
    this.joins = [];
}

SelectStatement.prototype = {
    join: function (select, fkCol, resultCol) {
        select.parent = this;
        this.joins.push({ select: select, fkCol: fkCol, resultCol: resultCol });
        return this;
    }
}

var SelectExecuter = function (select) {
    this.selectQueue = [];
    this.rootSelect = null;
    var autoId = 0;
}

SelectExecuter.prototype = {
    execute: function (select, callback) {
        var that = this;
        that.rootSelect = select;
        
        this.register(select);
        
        MongoClient.connect(getConnectionString(), function (err, db) {
            if (select.joins.length > 0) {
                for (var i = 0; i < select.joins.length; i++) {
                    var join = select.joins[i];
                    db.collection(join.select.collection).find(join.condition).toArray(function (err, results) {
                        that.internalCallback.call(that, callback, join.select, err, results);
                    });
                }
            }
            
            db.collection(select.collection).find(select.condition).toArray(function (err, results) {
                that.internalCallback.call(that, callback, select, err, results);
            });
        });
    },
    
    register: function (select) {
        this.selectQueue.push(select);
    },
    
    internalCallback: function (callback, select, err, results) {
        var that = this;
        select.ready = true;
        select.result = results;
        
        if (this.checkIfAllReady()) {
            var id2mainEntity = {};
            
            if (that.rootSelect.joins.length > 0) {
                for (var i = 0; i < that.rootSelect.result.length; i++) {
                    var entity = results[i];
                    id2mainEntity[entity._id.toString()] = entity;
                }
                
                for (var i = 0; i < that.rootSelect.joins.length; i++) {
                    var join = that.rootSelect.joins[i];
                    var fkCol = join.fkCol;
                    var resultCol = join.resultCol;
                    var joinResults = join.select.result;
                    
                    for (var j = 0; j < joinResults.length; j++) {
                        var joinRes = joinResults[j];
                        
                        var mainEntityId = joinRes[fkCol];
                        
                        if (!mainEntityId) continue;
                        
                        mainEntity = id2mainEntity[mainEntityId.toString()];
                        if (!mainEntity.hasOwnProperty(resultCol)) {
                            mainEntity[resultCol] = [];
                        }
                        
                        mainEntity[resultCol].push(joinRes);
                    }
                }
            }
            
            if (callback) {
                callback(err, results);
            }
        }
    },
    
    checkIfAllReady: function () {
        var res = true;
        
        for (var i = 0; i < this.selectQueue.length; i++) {
            res = this.selectQueue[i].ready && res;
            
            if (!res) return false;
        }
        
        return true;
    }
}