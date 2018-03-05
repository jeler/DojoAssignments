const mongoose = require("mongoose")
const User = mongoose.model("User")
var max_login_attempts = 5,
    lock_time = 30 * 60 * 1000,
    lockout = false
// login_attempts = 0;
// min * seconds * milliseconds(current = 30 min)

class UserController {
    createnewuser(req, res) {
        User.find({ email: req.body.email }, function (err, user) {
            console.log(user)
            if (user.length != 0) {
                console.log("user exists")
                res.json({ err: "User already exists!" })
            }
            else {

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
                        req.session.user_id = user.id;
                        var session_user = req.session.user_id
                        console.log(session_user, "this is session user!")
                        console.log(req.session.user_id)
                        res.json({ message: "Successfully added user!" });
                    }
                })
            }
        })
    };

    loginuser(req, res) {
        User.find({ email: req.body.email }, function (err, user)
        // find user in db
        {
            console.log(user, "in conroller!")
            if (user.length == 0) {
                // login_attempts++;
                // console.log("this is login_attempts",login_attempts);
                // user doesn't exist
                // increment login attempt
                res.json({ err: "User does not exist!" })
            }
            else 
            {
            bcrypt.compare(req.body.password, user[0].password)
                .then(same => {
                    // var session_user = req.session.user[0]._id
                    // console.log(session_user);
                    console.log(user, "in compare password!")
                    console.log(user[0].id, "user id?");
                    req.session.user_id = user[0].id
                    var session_user = req.session.user_id
                    console.log(session_user, "session user at 66!")
                    res.json({user: user, session_user: session_user});
                })
                .catch(function (err) {
                    console.log(err);
                    console.log("got here in catch!")
                    res.json({ pw_error: "Incorrect password!" })
                })
            }
        })
    }
                    
    logout(req, res) {
        req.session.destroy();
        res.json({message: "You have been logged out!"})
    }

    checkSessionId(req, res) {
        console.log(req.session.user_id, "do you exist here?");
        // console.log(session_user)
        if (req.session.user_id === undefined) {
            console.log(req.session.user_id)
            res.json({session: false})
        }
        else {
            User.findOne({_id: req.session.user_id}, function(err, user)
        {
            if(user)
            {
                
                console.log(req.session.user_id, "session user at line 82")
                console.log(user)
                res.json({session: req.session.user_id, user:user});
            }
        })
        }
    }
}
module.exports = new UserController
{

}