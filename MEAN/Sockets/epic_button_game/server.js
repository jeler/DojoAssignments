var express = require("express");

var app = express();

var session = require('express-session');

app.use(session({secret: 'codingdojorocks'}));

app.use(express.static(__dirname + "/static"));

var bodyParser = require('body-parser');

app.use(bodyParser.urlencoded({extended: true}));


app.set('views', __dirname + '/views'); 

app.set('view engine', 'ejs');


app.get('/', function(req, res) {
    res.render("index");
   })
   
var server = app.listen(8000, function () {
    console.log("listening on port 8000");
});
var io = require('socket.io').listen(server);
io.sockets.on('connection', function (socket) {
    var counter = 0;
    socket.on("counter_clicked", function () {
        // console.log('Someone clicked a button!  Reason: ' + data.reason);
        counter ++;
        io.emit('server_response', {counter});
        // console.log("Client/socket is connected!");
    });
    socket.on("counter_resetter", function() {
        counter =0;
        io.emit('server_response', {counter});
    })

});