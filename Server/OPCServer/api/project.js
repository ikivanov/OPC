var crypto = require('crypto');
var assert = require('assert');
var dalService = require('../dal/dalService');

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

    dalService.insert("projects", getObjectWithoutId(project), function (err, result) {
        var errMsg = "";
        if (err != null) {
            errMsg = "An error occured while creating a project. Details: " + err.message;
        }
        
        if (!result || result.length === 0) {
            errMsg = "An error occured while creating a project.";
        }
        
        if (errMsg) {
            res.send({
                success : false,
                msg: errMsg
            });
            return;
        }
        
        var projectId = new ObjectID(result[0]._id);

        res.send({
            success : true,
            ProjectId: projectId.toHexString(),
            msg: "OK"
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

    dalService.update("projects", { _id: new ObjectID(project.Id) }, getObjectWithoutId(project), function (err, result) {
        if (err !== null) {
            res.send({
                success : false,
                msg: "An error occured while updating a project."
            });

            return;
        }

        res.send({
            success : true,
            msg: "OK"
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

    dalService.remove("projects", { _id: new ObjectID(projectId) }, function (err, numberOfRemovedDocs) {
        if (err !== null) {
            res.send({
                success : false,
                msg: "An error occured while deleting a project."
            });
            
            return;
        }

        res.send({
            success : true,
            msg: "OK"
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
    
    var select = dalService.select("projects");
    dalService.executeSelect(select, function (err, projects) {
        assert.equal(null, err);
        
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

    var select = dalService.select("projects").join(dalService.select("tasks"), "ProjectId", "Tasks");
    dalService.executeSelect(select, function (err, projects) {
        var results = [];

        for (var i = 0; i < projects.length; i++) {
            var project = projects[i];
            
            var item = {
                Id: project._id.toString(),
                Name: project.Name,
                InternalCode: project.InternalCode,
                Description: project.Description,
                Tasks: project.Tasks
            };
            results.push(item);
        }

        res.send({
            success: true,
            projects: results,
            msg: "OK",
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