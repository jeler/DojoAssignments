var express = require("express");

var app = express();

app.use(express.static( __dirname + '/Angular/dist' ));

const bodyParser = require('body-parser');

var path = require("path")

app.all("*", (req,res,next) => {
    res.sendFile(path.resolve("./Angular/dist/index.html"))
  });

app.listen(8000, function() 
{
    console.log("listening on port 8000");
})