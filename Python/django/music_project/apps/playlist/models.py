from __future__ import unicode_literals

from django.db import models

import re, bcrypt

from datetime import date, datetime

class UserManager(models.Manager):
    def basic_validator(self, postData, action): #request.post =  postData
        errors = []
        EMAIL_REGEX = re.compile(r'^[a-zA-Z0-9.+_-]+@[a-zA-Z0-9._-]+\.[a-zA-Z]+$')
        user_first_name = postData.get('first_name')
        user_last_name = postData.get('last_name')
        user_email = postData.get('email')        
        user_birthday = postData.get('birthday')
        today_date = str(datetime.now().date())
        # thirteen_years_ago = today_date.timedelta(years = 13)
        # print thirteen_years_ago
        user_password = postData.get('password')
        pw_confirm = postData.get('pw_confirm')
        check_user = User.objects.filter(email = user_email) #blue = what you're from database #white = email from form
        song_title = postData.get("song")
        song_length = postData.get("song_length")
        user_id = postData.get("user_id")
        song_artist = postData.get("artist")
        if action == "register":
            if len(user_first_name) < 4:
                errors.append("First name must be at least 4 letters!")
            if len(user_last_name) < 4:
                errors.append("Last name must be at least 4 letters!")
            if len(user_email) < 1:
                errors.append("Email can't be blank!")
            if not user_first_name.isalpha():
                errors.append("First name must be letters!")
            if not user_last_name.isalpha():
                errors.append("Last name must be letters!")
            if not EMAIL_REGEX.match(user_email):
                errors.append("This email is not valid!")
            if len(user_password) < 6:
                errors.append("Password must be greater than 6 characters!")
            if not user_password == pw_confirm:
                errors.append("Passwords do not match!")
            if len(user_birthday) == 0:
                errors.append("You must enter a birthday!")
            if user_birthday > today_date:
                errors.append("Your birthday must be earlier than the current day!")
            if not len(check_user) == 0:
                errors.append("This email already exists!")
                hashed_pw = bcrypt.hashpw(user_password.encode(), bcrypt.gensalt())
                user = User.objects.create(first_name=user_first_name, last_name= user_last_name, email = user_email, password=hashed_pw, birthday=user_birthday)
            if len(errors) == 0:
                return (True, user)
            else: 
                return (False, errors)  
        if action == "login":
            if len(user_email) ==0:
                errors.append("You need to enter an email!")
            if len(user_password) == 0:
                errors.append("You need to enter a password!")
            if len(check_user) ==0:
                errors.append("Email does not exist!")
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
        if action == "add_song":
            if len(song_title) < 2:
                errors.append("Song name should be more than 2 characters")
            if len(song_length) == 0:
                errors.append("Song must have a length")
            if len(song_artist) < 1:
                errors.append("You need to enter an artist!")
            if len(errors) == 0:
                create_song = Song.objects.create(title = song_title, length=song_length)
                create_artist = Artist.objects.create(artist_name = song_artist, name = create_song)
                this_user = User.objects.get(id = user_id)
                playlist_create = create_song.playlist.add(this_user)
                
                return (True, playlist_create)
            else:
                return(False, errors)

class User(models.Model):
    first_name = models.CharField(max_length=255)
    last_name = models.CharField(max_length=255)    
    email = models.CharField(max_length=255)
    password = models.CharField (max_length = 255)
    birthday= models.DateField()
    created_at = models.DateTimeField(auto_now_add = True)
    updated_at = models.DateTimeField(auto_now = True)
    def __repr__(self):
        return "<User object: {} {}>".format(self.first_name, self.last_name, self.email)

    objects = UserManager()


class Song(models.Model):
    title = models.CharField(max_length=255)
    artist_name = models.CharField(max_length=255, default="")    
    length = models.IntegerField(default = "")
    created_at = models.DateTimeField(auto_now_add = True)
    updated_at = models.DateTimeField(auto_now = True)
    playlist = models.ManyToManyField(User, related_name = "playlist")
    
    objects = UserManager()