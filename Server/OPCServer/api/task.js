var crypto = require('crypto');
var assert = require('assert');
var utils = require('./utils');
var dalService = require('../dal/dalService');

var user = require('./user');
var ObjectID = require('mongodb').ObjectID;

exports.create = function (req, res) {
    var userToken = req.body.UserToken;
    var task = req.body.Payload;
    
    if (!user.isValidUserToken(userToken)) {
        res.send({
            success : false, 
            msg: "Authentication failed! Invalid user token."
        });
        return;
    }
    
    task = utils.getObjectWithoutId(task);
    if (task.ProjectId) {
        task.ProjectId = new ObjectID(task.ProjectId);
    }

    dalService.insert("tasks", task, function (err, result) {
        var errMsg = "";
        if (err != null) {
            errMsg = "An error occured while insertinga task. Details: " + err.message;
        }
        
        if (!result || result.length === 0) {
            errMsg = "An error occured while inserting a task.";
        }
        
        if (errMsg) {
            res.send({
                success : false,
                msg: errMsg
            });
            return;
        }

        var taskId = new ObjectID(result[0]._id);
            
        res.send({
            success : true,
            TaskId: taskId.toHexString(),
            msg: "OK"
        });
    });
}
