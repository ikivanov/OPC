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
        db.collection("projects").insert([project], {w: 1}, function (err, result) {
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
        db.collection("projects").update({_id: new ObjectID(project.Id)}, project, function (err, result) {
            assert.equal(null, err);
            
            res.send({
                success : true,
                msg: "OK"
            });
            
            db.close();
        });
    });
}