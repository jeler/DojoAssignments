from __future__ import unicode_literals

from django.db import models

import re

class UserManager(models.Manager):
    def basic_validator(self, postData, action): #request.post =  postData
        errors = []
        email = postData['email']
        match = re.match('^[_a-z0-9-]+(\.[_a-z0-9-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,4})$', email)
        fname = postData['first_name']
        lname = postData['last_name']
        if len(fname) < 1:
            errors.append("First name can't be blank!")
        if len(lname) < 1:
            errors.append("Last name can't be blank!")
        if not fname.isalpha():
            errors.append("First name must be letters!")
        if not lname.isalpha():
            errors.append("Last name must be letters!")
        if match == None:
            errors.append("Invalid email address!")
        if not len(errors):
            if action == "create":
                user = Users.objects.create(first_name=fname, last_name=lname, email=email)
                return (True, user)
            if action == "update":
                user = Users.objects.get(email = postData['email'])
                user.first_name = postData['first_name']
                user.last_name  = postData['last_name']
                user.email = postData['email']
                user.save()
                return (True, user)
        else:
            return (False, errors)
        

class Users(models.Model):
    first_name = models.CharField(max_length=255)
    last_name = models.CharField(max_length=255)
    email = models.CharField(max_length=255)
    created_at = models.DateTimeField(auto_now_add = True)
    updated_at = models.DateTimeField(auto_now = True)
    def __repr__(self):
        return "<User object: {} {}>".format(self.first_name, self.last_name, self.email)

    objects = UserManager()