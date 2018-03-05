from __future__ import unicode_literals

from django.db import models

import re, bcrypt

from time import gmtime, strftime

from datetime import date, datetime

class UserManager(models.Manager):
    def basic_validator(self, postData, action): #request.post =  postData
        errors = []
        user_email = postData.get('email')
        EMAIL_REGEX = re.compile(r'^[a-zA-Z0-9.+_-]+@[a-zA-Z0-9._-]+\.[a-zA-Z]+$')
        user_name = postData.get('name')
        user_alias = postData.get('alias')
        user_password = postData.get('password')
        pw_confirm = postData.get('pw_confirm')
        user_birthday = postData.get('birthday')
        check_user = User.objects.filter(email = user_email)
        today_date = str(datetime.now().date())

        if action == "register":
            if len(user_name) < 1:
                errors.append("Name can't be blank!")
            if not user_name.isalpha():
                errors.append("Name must be letters!")
            if not EMAIL_REGEX.match(user_email): 
                errors.append("Invalid email address!")
            if len(user_alias) < 1:
                errors.append("Alias can't be blank!")
            if len(user_password) < 6:
                errors.append("Password is not long enough!")
            if not user_password == pw_confirm:
                errors.append("Passwords do not Match!")
            if not len(check_user) == 0:
                errors.append("This email already exists!")
            if len(user_birthday) < 1:
                errors.append("You need to have a birthday!")
            if user_birthday > today_date:
                errors.append("Birthday can not be in the future!")
            if len(errors) == 0:
                hashed_pw = bcrypt.hashpw(user_password.encode(), bcrypt.gensalt())
                user = User.objects.create(name=user_name, alias=user_alias, email=user_email, password=hashed_pw, birthday=user_birthday)
                return (True, user)
            else:
                return (False, errors)
        if action == "login":
            if len(check_user) ==0:
                errors.append("Email address does not exist!")
            if len(user_password) ==0:
                errors.append("You need to enter a password!")
            if not len(check_user) == 0: #email exists in the database
                database_password = check_user[0].password  #accesses password from database
                if not bcrypt.checkpw(user_password.encode(), database_password.encode()): 
                    errors.append("Password is incorrect!")
                else:
                    user_id = check_user[0].id
            if len(errors) == 0:
                return (True, user_id)
            else:
                return (False, errors)

class User(models.Model):
    name = models.CharField(max_length=255)
    alias = models.CharField(max_length=255)
    email = models.CharField(max_length=255)
    password = models.CharField (max_length = 255)
    birthday = models.DateField()
    created_at = models.DateTimeField(auto_now_add = True)
    updated_at = models.DateTimeField(auto_now = True)
    friend = models.ManyToManyField("self", related_name = "friend")    
    
    def __repr__(self):
        return "<User object: {} {}>".format(self.name, self.alias, self.email)

    objects = UserManager()
    
    

