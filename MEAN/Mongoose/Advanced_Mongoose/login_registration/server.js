var express = require("express");

var app = express();

var session = require('express-session');

app.use(session({ secret: 'codingdojorocks' }));

app.use(express.static(__dirname + "/static"));

var bodyParser = require('body-parser');

var mongoose = require('mongoose');
bcrypt = require('bcrypt')
SALT_WORK_FACTOR = 10

mongoose.connect('mongodb://localhost/login_registration');

function toLower(v) {
    return v.toLowerCase();
}

var UserSchema = new mongoose.Schema({
    email: {type: String, set: toLower, required: true, index: {unique: true}, 
    validate: {
        validator: function(value) {
            return /^([\w-\.]+@([\w-]+\.)+[\w-]{2,4})?$/.test( value );
        },
        message: "Invalid Email Address!"
    }
},
    first_name: {type: String, required: [true, "You need to enter a  first name!"],  minlength: [2, "first_name must be longer than 2 characters!"]},
    last_name: {type: String, required: [true, "You need to enter a last name!"],  minlength: [2, "last_name must be longer than 2 characters!"]},
    password: {type: String, required: [true, "You need to enter a password!"], minlength: [8, "Password must be longer than 8 characters"],maxlength: 32,  
    validate: {
        validator: function( value ) {
          return /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@$!%*?&])[A-Za-z\d$@$!%*?&]{8,32}/.test( value );
        },
        message: "Password failed validation, you must have at least 1 number, uppercase and special character"
      }
},
    birthday: {type: Date, required: true},
},
    { timestamps: true});
    // UserSchema.path('email').validate(function (email) {
    //     var emailRegex = /^([\w-\.]+@([\w-]+\.)+[\w-]{2,4})?$/;
    //     return emailRegex.test(email.text); // Assuming email has a text attribute
    //  }, 'The e-mail field cannot be empty.')
     
    
UserSchema.pre('save', function(next) {
    var user = this;

    // only hash the password if it has been modified (or is new)
    if (!user.isModified('password')) return next();

    // generate a salt
    bcrypt.genSalt(SALT_WORK_FACTOR, function(err, salt) {
        if (err) return next(err);

        // hash the password along with our new salt
        bcrypt.hash(user.password, salt, function(err, hash) {
            if (err) return next(err);

            // override the cleartext password with the hashed one
            user.password = hash;
            next();
        });
    });
});
UserSchema.post('save', function(user) {
    var user = this;
    req.sesison.id = this.id;
    console.log(this.id);
})
        // UserSchema.methods.comparePassword = function(password_confirmation, cb) {
        //     bcrypt.compare(password_confirmation, this.password, function(err, isMatch) {
        //         if (err) return cb(err);
        //         cb(null, isMatch);
        //     });
        // };

mongoose.model('User', UserSchema); // We are setting this Schema in our Models as 'User'
var User = mongoose.model('User')

mongoose.Promise = global.Promise;

app.use(bodyParser.urlencoded({ extended: true }));


app.set('views', __dirname + '/views');

app.set('view engine', 'ejs');

app.get('/', function(req, res) {
    res.render("index");
   })
 
app.post('/register_user', function(req, res) {
    console.log(req.body.email);
    console.log(req.body.password)
    console.log(req.body.password_confirm)
    if(req.body.password == req.body.password_confirm)
    {
        var user = new User 
        ({
            email: req.body.email,
            first_name: req.body.first_name,
            last_name: req.body.last_name,
            password: req.body.password,
            birthday: req.body.birthday
    
        })
        user.save(function(err){
            if(err) {
                console.log("Something went wrong at line 96!")
                res.render('index', {errors: [err]})
            }
            else {
                console.log("successfully added a user!")
                console.log("do you exist?", user.id)
                // req.session.id = user.id
                res.redirect('/success');
            }
        });
    }
    else
    {
        console.log("password confirmation not met!")
        res.redirect('/')
    }
});

app.get('/success', function(req, res) {
    res.render("success");
})
   
app.listen(8000, function() 
{
    console.log("listening on port 8000");
})