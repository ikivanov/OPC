var MongoClient = require('mongodb').MongoClient;
var crypto = require('crypto');
var connectionString = "mongodb://localhost:27017/opc";
var assert = require('assert');

var user = require('./user');
var ObjectID = require('mongodb').ObjectID;

exports.create = function (req, res) {
    var userToken = req.body.UserToken;
    var project = req.body.Payload;

    if (!user.isValidUserToken(userToken)) {
        res.send({
            success : false, 
            msg: "Authentication failed! Invalid user token."
        });
        return;
    }

    MongoClient.connect(connectionString, function (err, db) {
        db.collection("projects").insert([getObjectWithoutId(project)], {w: 1}, function (err, result) {
            assert.equal(null, err);
            
            var projectId = new ObjectID(result[0]._id);

            res.send({
                success : true,
                ProjectId: projectId.toHexString(),
                msg: "OK"
            });

            db.close();
        });
    });
}

var getObjectWithoutId = function (object) {
    if (!object) {
        return null;
    }

    var result = {};

    for (var propName in object) {
        if (propName === "Id") {
            continue;
        }

        if (object.hasOwnProperty(propName)) {
            result[propName] = object[propName];
        }
    }

    return result;
}

exports.update = function (req, res) {
    var userToken = req.body.UserToken;
    var project = req.body.Payload;
    
    if (!user.isValidUserToken(userToken)) {
        res.send({
            success : false, 
            msg: "Authentication failed! Invalid user token."
        });
        return;
    }
    
    MongoClient.connect(connectionString, function (err, db) {
        db.collection("projects").update({_id: new ObjectID(project.Id)}, getObjectWithoutId(project), function (err, result) {
            assert.equal(null, err);
            
            res.send({
                success : true,
                msg: "OK"
            });
            
            db.close();
        });
    });
}

exports.delete = function (req, res) {
    var userToken = req.params.userToken;
    var projectId = req.params.id;

    if (!user.isValidUserToken(userToken)) {
        res.send({
            success : false, 
            msg: "Authentication failed! Invalid user token."
        });
        return;
    }

    MongoClient.connect(connectionString, function (err, db) {
        db.collection("projects").remove({ _id: new ObjectID(projectId) }, { w: 1 }, function (err, numberOfRemovedDocs) {
            assert.equal(null, err);
            assert.equal(1, numberOfRemovedDocs);
            
            res.send({
                success : true,
                msg: "OK"
            });
            
            db.close();
        });
    });
}