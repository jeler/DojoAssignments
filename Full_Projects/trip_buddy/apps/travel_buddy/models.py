from __future__ import unicode_literals

from django.db import models

from datetime import date, datetime

import re, bcrypt

from time import gmtime, strftime

class UserManager(models.Manager):
    def basic_validator(self, postData, action): #request.post =  postData
        errors = []
        name = postData.get('name')
        username = postData.get('username')
        user_password = postData.get('password')
        pw_confirm = postData.get('pw_confirm')
        destination = postData.get("destination")
        description = postData.get("description")        
        travel_from_date = postData.get("travel_from")
        travel_end_date = postData.get("travel_end")
        trip_planner_id = postData.get("trip_planner_id")
        print travel_from_date
        today_date = str(datetime.now().date())
        print today_date

        # today_date = strftime("%Y-%m-%d %H:%M %p", gmtime())
        check_user = User.objects.filter(username = username) #blue = what you're from database #white = email from form
        if action == "register":
            if len(name) < 3:
                errors.append("Name must be greater than 3 characters!")
            if not name.isalpha():
                errors.append("Name must be letters!")
            if len(user_password) < 8:
                errors.append("Password must be greater than 8 characters!")
            if not user_password == pw_confirm:
                errors.append("Passwords do not Match!")
            if not len(check_user) == 0:
                errors.append("This username already exists!")
            if len(errors) == 0:
                hashed_pw = bcrypt.hashpw(user_password.encode(), bcrypt.gensalt())
                user = User.objects.create(name=name, username= username, password=hashed_pw)
                return (True, user)
            else: 
                return (False, errors)  
        if action == "login":
            if len(check_user) ==0:
                errors.append("Username does not exist!")
            if len(user_password) == 0:
                errors.append("You need to enter a password!")
            if not len(check_user) == 0:
                database_password = check_user[0].password
                if bcrypt.checkpw(user_password.encode(), database_password.encode()): 
                    user_id = check_user[0].id       
                else: 
                    errors.append("Password is incorrect!")
            if len(errors) == 0:
                return (True, user_id)
            else:
                return (False, errors)
        if action == "create_plan":
            print "I got to line 59"
            if len(destination) < 1:
                errors.append("Destination can not be blank!")
            if len(description) < 1:
                errors.append("Description can not be blank!")
            if travel_from_date < today_date:
                errors.append("Date must be in the future!")
            if travel_from_date > travel_end_date:
                errors.append("Start Date cannot be after end date!")
            if len(errors) == 0:
                create_plan = Trip.objects.create(destination = destination, description = description, travel_start_date =travel_from_date, travel_end_date = travel_end_date, planner_id = trip_planner_id )
                this_user = User.objects.get(id = trip_planner_id)
                travel_plan_create = create_plan.travel_plan.add(this_user)
                return (True, travel_plan_create)
            else:
                return(False, errors)

class User(models.Model):
    name = models.CharField(max_length=255)
    username = models.CharField(max_length=255)
    password = models.CharField (max_length = 255)
    created_at = models.DateTimeField(auto_now_add = True)
    updated_at = models.DateTimeField(auto_now = True)
    def __repr__(self):
        return "<User object: {} {}>".format(self.name, self.username)

    objects = UserManager()


class Trip(models.Model):
    destination = models.TextField()
    planner = models.ForeignKey(User, related_name = "planner")
    travel_start_date = models.DateField()
    travel_end_date = models.DateField()
    description = models.TextField()
    created_at = models.DateTimeField(auto_now_add = True)
    updated_at = models.DateTimeField(auto_now = True)
    travel_plan = models.ManyToManyField(User, related_name = "travel_plan")
    def __repr__(self):
        return "<User object: {} {}>".format(self.destination, self.planner)
    

    objects = UserManager()

