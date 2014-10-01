var crypto = require('crypto');
var dalService = require('../dal/dalService');

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

    var passwordHash = crypto.createHash('md5').update(password).digest('hex');
    var select = dalService.select("users", { username : username, password: passwordHash });
    dalService.executeSelect(select, function (err, results) {
        if (err) {
            res.send({
                success : false, 
                msg: "An error occured while logging in!. Details: " + err.msessage
            });
        }

        if (results && results.length > 0) {
            var user = results[0];
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
    });
}

exports.logout = function (req, res) {
    res.send({
        success : true,
        msg : "Logout successful",
    });
}