var MongoClient = require('mongodb').MongoClient;
var crypto = require('crypto');
var assert = require('assert');
var utils = require('./utils');
var connectionString = utils.getConnectionString();

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
    
    MongoClient.connect(connectionString, function (err, db) {
        db.collection("tasks").insert([task], { w: 1 }, function (err, result) {
            assert.equal(null, err);
            
            var taskId = new ObjectID(result[0]._id);
            
            res.send({
                success : true,
                TaskId: taskId.toHexString(),
                msg: "OK"
            });
            
            db.close();
        });
    });
}
