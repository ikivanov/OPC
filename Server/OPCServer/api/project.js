var MongoClient = require('mongodb').MongoClient;
var crypto = require('crypto');
var assert = require('assert');
var utils = require('./utils');
var connectionString = utils.getConnectionString();

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
        if (propName === "Id" || propName === "Tasks") {
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

exports.getAll = function (req, res) {
    var userToken = req.params.userToken;

    if (!user.isValidUserToken(userToken)) {
        res.send({
            success: false,
            msg: "Authentication failed! Invalid user token."
        });
        return;
    }

    MongoClient.connect(connectionString, function (err, db) {
        db.collection("projects").find().toArray(function (err, projects) {

            var results = [];

            for (var i = 0; i < projects.length; i++) {
                var project = projects[i];

                var item = {
                    Id: project._id.toString(),
                    Name: project.Name,
                    InternalCode: project.InternalCode,
                    Description: project.Description
                };

                results.push(item);
            }

            res.send({
                success: true,
                projects: results,
                msg: "OK",
            });

            db.close();
        });
    });
}

exports.getAllWithTasks = function (req, res) {
    var userToken = req.params.userToken;
    
    if (!user.isValidUserToken(userToken)) {
        res.send({
            success: false,
            msg: "Authentication failed! Invalid user token."
        });
        return;
    }

    MongoClient.connect(connectionString, function (err, db) {
        db.collection("projects").find().toArray(function (err, projects) {
            
            var results = [];
            var id2project = {};
            
            for (var i = 0; i < projects.length; i++) {
                var project = projects[i];
                
                var item = {
                    Id: project._id.toString(),
                    Name: project.Name,
                    InternalCode: project.InternalCode,
                    Description: project.Description,
                    Tasks: []
                };
                
                results.push(item);
                id2project[item.Id] = item;
            }
            
            db.collection("tasks").find().toArray(function (err, tasks) {
                
                for (var i = 0; i < tasks.length; i++) {
                    var task = tasks[i];

                    if (!task.ProjectId) {
                        continue;
                    }

                    var project = id2project[task.ProjectId];
                    if (!project) {
                        continue;
                    }

                    project.Tasks.push(task);
                }

                res.send({
                    success: true,
                    projects: results,
                    msg: "OK",
                });
                
                db.close();
            });
        });
    });
}

exports.getById = function (req, res) {
    var userToken = req.params.userToken;

    if (!user.isValidUserToken(userToken)) {
        res.send({
            success: false,
            msg: "Authentication failed! Invalid user token."
        });
        return;
    }
}