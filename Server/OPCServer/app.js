if (process.env.NODE_ENV === undefined) {
    process.env.NODE_ENV = "development";
}

var config = require("konfig")();

if (!config.app) {
    throw new Error("Configuration file needs to be provided!");
}

global.getConfig = function() {
    return config.app;
}

var express = require('express');
var routes = require('./routes');
var user = require('./api/user');
var project = require('./api/project');
var task = require('./api/task');
var http = require('http');
var path = require('path');
var bodyParser = require('body-parser');

var session = require('express-session');
var MemcachedStore = require('connect-memcached')(session);


var app = express();

var cfg = global.getConfig();
var port = cfg.nodejs_port;

app.set('port', port || 3000);
app.set('views', path.join(__dirname, 'views'));
app.set('view engine', 'jade');

var memcachedStore = new MemcachedStore({
    hosts: cfg.memcached.host
});

app.use(session({
    key: cfg.memcached.key,
    secret: cfg.memcached.secret,
    resave: true,
    saveUninitialized: true,
    store: memcachedStore
}));

app.use(bodyParser.json());
app.use(bodyParser.urlencoded({
    extended: true
}));

//app.use(express.favicon());
//app.use(express.logger('dev'));
//app.use(express.json());
//app.use(express.urlencoded());
//app.use(express.methodOverride());
//app.use(app.router); This is not needed anymore!!!
//app.use(require('stylus').middleware(path.join(__dirname, 'public')));
app.use(express.static(path.join(__dirname, 'public')));

// development only
//if ('development' == app.get('env')) {
  //app.use(express.errorHandler());
//}

//this is cookied based authentication method
function authenticate(req, res, next) {
    if (req.session.sid) { //this not only checks if the cookied has sid field defined, but checks if sid exists in db!!!
        next();
    } else {
        res.send({
            success: false, 
            message: "Authenticated failed: Login first!"
        });
    }
}

//hit on site root
app.get('/', routes.index);

//users related functionality
app.post('/api/login', user.login);
app.get('/api/logout', user.logout);

//project related functionality
app.put('/api/project', authenticate, project.create);
app.post('/api/project', authenticate, project.update);
app.delete('/api/project/:id', authenticate, project.delete);
app.get('/api/projects', authenticate, project.getAll);
app.get('/api/projectsWithTasks', authenticate, project.getAllWithTasks);
app.get('/api/projectPlan', authenticate, project.projectPlan);

//task related functionality
app.put('/api/task', authenticate, task.create);

http.createServer(app).listen(port, function(){
    console.log('OPC server listening on port ' + port);
});