from __future__ import unicode_literals

from django.db import models

import re, bcrypt

class UserManager(models.Manager):
    def basic_validator(self, postData, action): #request.post =  postData
        errors = []
        user_email = postData.get('email')
        match = re.match('^[_a-z0-9-]+(\.[_a-z0-9-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,4})$', user_email)
        user_fname = postData.get('first_name')
        user_lname = postData.get('last_name')
        user_password = postData.get('password')
        pw_confirm = postData.get('pw_confirm')
        check_user = Users.objects.filter(email = user_email) #blue = what you're from database #white = email from form
        print "This is check_user exist", check_user
        if action == "register":
            if len(user_fname) < 1:
                errors.append("First name can't be blank!")
                print "I got to line 19", errors
            if len(user_lname) < 1:
                errors.append("Last name can't be blank!")
            if not user_fname.isalpha():
                errors.append("First name must be letters!")
            if not user_lname.isalpha():
                errors.append("Last name must be letters!")
            if match == None:
                errors.append("Invalid email address!")
            if len(user_password) < 6:
                errors.append("Password is not long enough!")
            if not user_password == pw_confirm:
                errors.append("Passwords do not Match!")
            if not len(check_user) == 0:
                errors.append("This email already exists!")
            if len(errors) == 0: 
                hashed_pw = bcrypt.hashpw(user_password.encode(), bcrypt.gensalt())
                user = Users.objects.create(first_name=user_fname, last_name=user_lname, email=user_email, password=hashed_pw)
                response  = "You have successfully registered" 
                return (True, user)
            else:
                return (False, errors)
        if action == "login":
            if len(user_email) < 1:
                errors.append("You need to enter an email!")
            if len(user_password) < 1:
                errors.append("You need to enter a password!")
                return (False, errors)
            if len(check_user) ==0:
                errors.append("Email address does not exist!")
                return (False, errors)
            if not len(check_user) == 0:  #email exists in the database
                database_password = check_user[0].password  #accesses password from database
                # print "This is database_password", database_password
                if bcrypt.checkpw(user_password.encode(), database_password.encode()): 
                    user_id = check_user[0].id 
                    response  = "You have successfully logged in!"       
                    return (True, user_id) 
                else: 
                    errors.append("Password is incorrect!")
                    print "Errors are", errors
                    return (False, errors)

class Users(models.Model):
    first_name = models.CharField(max_length=255)
    last_name = models.CharField(max_length=255)
    email = models.CharField(max_length=255)
    password = models.CharField (max_length = 255)
    user_review = models.ForeignKey(Books, related_name = "reviews")
    created_at = models.DateTimeField(auto_now_add = True)
    updated_at = models.DateTimeField(auto_now = True)
    def __repr__(self):
        return "<User object: {} {}>".format(self.first_name, self.last_name, self.email)

    # objects = UserManager()

class Books(models.Model):
    title = models.CharField(max_length=255)
    author = models.CharField(max_length=255)
    review = models.CharField(max_length=255)
    created_at = models.DateTimeField(auto_now_add = True)
    updated_at = models.DateTimeField(auto_now = True)
    def __repr__(self):
        return "<User object: {} {}>".format(self.first_name, self.last_name, self.email)

    # objects = UserManager()