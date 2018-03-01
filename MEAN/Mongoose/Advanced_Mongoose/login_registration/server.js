var express = require("express");

var app = express();

var session = require('express-session');

app.use(session({ secret: 'codingdojorocks' }));

app.use(express.static(__dirname + "/static"));

var bodyParser = require('body-parser');

var mongoose = require('mongoose');
bcrypt = require('bcrypt-as-promised')


mongoose.connect('mongodb://localhost/login_registration');

function toLower(v) {
    return v.toLowerCase();
}

var UserSchema = new mongoose.Schema({
    email: {
        type: String, set: toLower, required: true, index: { unique: true },
        validate: {
            validator: function (value) {
                return /^([\w-\.]+@([\w-]+\.)+[\w-]{2,4})?$/.test(value);
            },
            message: "Invalid Email Address!"
        }
    },
    first_name: { type: String, required: [true, "You need to enter a  first name!"], minlength: [2, "first_name must be longer than 2 characters!"] },
    last_name: { type: String, required: [true, "You need to enter a last name!"], minlength: [2, "last_name must be longer than 2 characters!"] },
    password: {
        type: String, required: [true, "You need to enter a password!"], minlength: [8, "Password must be longer than 8 characters"], maxlength: 32,
        validate: {
            validator: function (value) {
                return /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@$!%*?&])[A-Za-z\d$@$!%*?&]{8,32}/.test(value);
            },
            message: "Password failed validation, you must have at least 1 number, uppercase and special character"
        }
    },
    birthday: { type: Date, required: true },
},
    { timestamps: true });

UserSchema.pre('save', function (next) {
    bcrypt.hash(this.password, 10)
        .then(function (hashed_pw) {
            this.password = hashed_pw;
            next();
        })
        .catch(function (errors) {
            console.log(errors)
        });
});

mongoose.model('User', UserSchema); // We are setting this Schema in our Models as 'User'
var User = mongoose.model('User')

mongoose.Promise = global.Promise;

app.use(bodyParser.urlencoded({ extended: true }));


app.set('views', __dirname + '/views');

app.set('view engine', 'ejs');

var errs =[]
// errors im pushing into

app.get('/', function (req, res) {
    res.render("index");
})

app.post('/register_user', function (req, res) {
    if (req.body.password == req.body.password_confirm) {
        var user = new User
            ({
                email: req.body.email,
                first_name: req.body.first_name,
                last_name: req.body.last_name,
                password: req.body.password,
                birthday: req.body.birthday
            })
        user.save(function (err) {
            if (err) {
                res.json(err);
            }
            else {
                console.log("successfully added a user!")
                req.session.user_id = user.id;
                res.redirect('/success');
            }
        });
    }
    else {
        console.log("password confirmation not met!")
        res.redirect('/')
    }
});

app.post('/login_user', function (req, res) {
    User.findOne({ email: req.body.email_login }, function (err, user) {
        if (err) {
            res.json(err)
        }
        if (!user) {
            res.json({err:"no user found"})
        }
        if (user) 
        {
            console.log(user)
            bcrypt.compare(req.body.password_login, user.password)
                .then(function (logged_in) {
                    req.session.user_id = user.id;
                    res.redirect('/success')
                })
                .catch(function (error) {
                    res.json({err: "password incorrect!"});
                })
        }
    })
});

app.get('/success', function (req, res) {
    if (req.session.user_id === undefined) {
        res.redirect('/');
    }
    else {
        res.render("success");
    }
})

app.get('/logout', function (req, res) {
    req.session.destroy();
    res.redirect('/');
})
app.listen(8000, function () {
    console.log("listening on port 8000");
})