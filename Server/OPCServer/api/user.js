var crypto = require('crypto');
var uuid = require('uuid');
var dalService = require('../dal/dalService');

exports.list = function(req, res){
  res.send("respond with a resource");
};

function getSIDPrivateKey() {
    return "sid" + uuid.v4() + "privatekey";
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
            
            var sid = uuid.v4() + Number(new Date()) + getSIDPrivateKey();
            req.session.regenerate(function () {
                req.session.sid = crypto.createHash('sha256').update(sid).digest('hex');
                
                res.send(
                    {
                        success : true,
                        message: "Login successful!"
                    });
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