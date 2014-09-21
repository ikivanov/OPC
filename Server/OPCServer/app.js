var express = require('express');
var routes = require('./routes');
var user = require('./routes/user');
var project = require('./routes/project');
var http = require('http');
var path = require('path');
var bodyParser = require('body-parser');

var app = express();

app.set('port', process.env.PORT || 3000);
app.set('views', path.join(__dirname, 'views'));
app.set('view engine', 'jade');

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

//hit on site root
app.get('/', routes.index);

//users related functionality
app.post('/api/login', user.login);
app.get('/api/logout', user.logout);

//project related functionality
app.put('/api/project', project.create);
app.post('/api/project', project.update);

http.createServer(app).listen(app.get('port'), function(){
  console.log('OPC server listening on port ' + app.get('port'));
});