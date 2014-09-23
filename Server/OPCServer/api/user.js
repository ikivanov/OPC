var MongoClient = require('mongodb').MongoClient;
var crypto = require('crypto');
var connectionString = "mongodb://localhost:27017/opc";

var users = {};
users["cbr"] = {username: "cbr", password: "123"};
users["ikivanov"] = {username: "ikivanov", password: "123"};

exports.list = function(req, res){
  res.send("respond with a resource");
};

var loggedUsers = {};

exports.isValidUserToken = function (userToken) {
    if (!userToken) {
        return false;
    }

    return loggedUsers[userToken] !== undefined;
}

exports.login = function (req, res) {
    var username = req.body.Username;
    var password = req.body.Password;
    
    MongoClient.connect(connectionString, function (err, db) {
        var passwordHash = crypto.createHash('md5').update(password).digest('hex');
        db.collection("users").findOne({ username : username, password: passwordHash }, function (err, user) {
            if (user) {
                var userToken = crypto.randomBytes(20).toString('hex');
                var userId = user._id.toString();
                loggedUsers[userToken] = userId;
                
                res.send({
                    success : true,
                    userToken: userToken,
                    msg : "OK",
                });
            } else {
                res.send({
                    success : false, 
                    msg: "Authentication failed! Bad username or password."
                });
            }
            
            db.close();
        });
    });
}

exports.logout = function (req, res) {
    res.send({
        success : true,
        msg : "Logout successful",
    });
}