var users = {};
users["cbr"] = {username: "cbr", password: "123"};
users["ikivanov"] = {username: "ikivanov", password: "123"};

exports.list = function(req, res){
  res.send("respond with a resource");
};

exports.login = function (req, res) {
    var username = req.body.Username;
    var password = req.body.Password;    

    var user = users[username];
    if (user && user.password === password) {
        res.send({
            success : true,
            userToken: "1234567890",
            msg : "OK",
        });
    } else {
        res.send({
            success : false, 
            msg: "Authentication failed! Bad username or password"
        });
    }
}

exports.logout = function (req, res) {
    res.send({
        success : true,
        msg : "Logout successful",
    });
}