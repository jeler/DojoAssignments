var express = require("express");

var app = express();
// 

var session = require("express-session")({
    secret: "my-secret",
    resave: true,
    saveUninitialized: true
});
var sharedsession = require("express-socket.io-session");

// Use express-session middleware for express
app.use(session);

// Use shared session middleware for socket.io
// setting autoSave:true

app.use(express.static(__dirname + "/static"));

var bodyParser = require('body-parser');

app.use(bodyParser.urlencoded({ extended: true }));


app.set('views', __dirname + '/views');

app.set('view engine', 'ejs');

var users = [];

app.get('/', function (req, res) {
    res.render("index");
})

var server = app.listen(8000, function () {
    console.log("listening on port 8000");
});

var io = require('socket.io').listen(server);
io.use(sharedsession(session, {
    autoSave:true
})); 
io.sockets.on('connection', function (socket) {
    var counter = 0;
    socket.on("got_a_new_user", function (data) {
        // receive data from socket.emit(got_new_user)
        // if(!socket.handshake.session.counter)
        // {
        //     socket.handshake.session.counter = 1;
        // }
        // else
        // {
        //     socket.handshake.session.counter+=1;
        // }

        // socket.handshake.session.user_id = id;
        // console.log("This is line 49" + socket.handshake.session.user_id);
        // socket.handshake.session.save();
        // console.log("this is id", id);
        // req.session.user_id = id;
        // console.log(req.session.user_id);
        var new_user = data.name;
        users.push(new_user);
        console.log("users array!" + users);
        io.emit('existing_users', {users});
        console.log(data);
        socket.broadcast.emit('new_user', {data})       
    });
});
// var io = require('io').listen(server);{
//     io.on("got_a_new_user", function (app) {
//         app.io.route("got_a_new_user", function (req) {
//             app.io.broadcast(new_user, { new_user_name: req.data.name })
//             socket.emit('server_response', { response: "sockets are the best!" });
//         });
//     });
// }