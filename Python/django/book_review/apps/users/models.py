from __future__ import unicode_literals

from django.db import models

import re, bcrypt

from django.core.validators import MinValueValidator, MaxValueValidator

class UserManager(models.Manager):
    def basic_validator(self, postData, action): #request.post =  postData
        errors = []
        user_email = postData.get('email')
        EMAIL_REGEX = re.compile(r'^[a-zA-Z0-9.+_-]+@[a-zA-Z0-9._-]+\.[a-zA-Z]+$')
        user_name = postData.get('name')
        user_alias = postData.get('alias')
        user_password = postData.get('password')
        pw_confirm = postData.get('pw_confirm')
        check_user = Users.objects.filter(email = user_email) #blue = what you're from database #white = email from form
        add_book_title = postData.get('book_title')
        existing_author = postData.get('existing_author')
        add_new_author = postData.get('new_author')
        add_review = postData.get('review')       
        add_rating = postData.get('rating')
        check_author_exist = Authors.objects.filter(name = add_new_author)
        check_book = Books.objects.filter(book_title = add_book_title)
        user_id  = postData.get('user_id') #gets user_id from hidden portion of form on dashboard
        check_user_id_review = Users.objects.filter(id = user_id)
        book_id_book_page = postData.get('book_id')
        user_id_book_page = postData.get('user_id')


        #At some point, deal with problem of multiple users can have reviews of same book

        if action == "register":
            if len(user_name) < 1:
                errors.append("Name can't be blank!")
            if not user_name.isalpha():
                errors.append("Name must be letters!")
            if not EMAIL_REGEX.match(user_email): 
                errors.append("Invalid email address!")
            if len(user_password) < 6:
                errors.append("Password is not long enough!")
            if not user_password == pw_confirm:
                errors.append("Passwords do not Match!")
            if not len(check_user) == 0:
                errors.append("This email already exists!")
            if len(errors) == 0:
                hashed_pw = bcrypt.hashpw(user_password.encode(), bcrypt.gensalt())
                user = Users.objects.create(name=user_name, alias=user_alias, email=user_email, password=hashed_pw)
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

        if action == "create_new_book":
            if len(add_book_title) < 1:
                errors.append("Book Title can't be blank!")
            if not len(check_author_exist) == 0:
                errors.append("Author already in database!")
            if len(existing_author) == 0 and len(add_new_author) ==0: #existing_author = dropdown menu; #add_new_author = text field
                errors.append("You need to enter an author!")
            if len(add_review) == 0:
                errors.append("Review can not be blank!")
            # if not len(add_new_author) == 0:   
            #     # if new author field is not 0 (drop down menu) and does not match existing author
            # if not len(existing_author) == 0:
            #     # if existing author not 0             
            if len(errors) == 0:
                author_database = Authors.objects.create(name = add_new_author)
                book_database = Books.objects.create(book_title = add_book_title, writer = author_database)
                review_database = Reviews.objects.create(review = add_review, rating = int(add_rating), books = book_database, user_book_review_id = user_id)             
                return (True, book_database)
            else: 
                return (False, errors)
        if action == "create_review_from_page":
            #how to prevent user from creating duplicate reviews??
            #how to have only logged in user delete their own reviews???
            if len(add_review) < 1:
                errors.append("You need to enter a review!")
            if len(errors) == 0:
                review_database = Reviews.objects.create(review= add_review, rating = int(add_rating), books_id= book_id_book_page, user_book_review_id = user_id_book_page)
                return (True, book_id_book_page)
            else:
                return (False, errors)


class Users(models.Model):
    name = models.CharField(max_length=255)
    alias = models.CharField(max_length=255)
    email = models.CharField(max_length=255)
    password = models.CharField (max_length = 255)
    created_at = models.DateTimeField(auto_now_add = True)
    updated_at = models.DateTimeField(auto_now = True)
    def __repr__(self):
        return "<User object: {} {}>".format(self.name, self.alias, self.email)

    objects = UserManager()

class Authors(models.Model):
    name = models.CharField(max_length = 255)
    created_at = models.DateTimeField(auto_now_add = True)
    updated_at = models.DateTimeField(auto_now = True)

    objects = UserManager()

class Books(models.Model):
    book_title = models.TextField(default = "")
    created_at = models.DateTimeField(auto_now_add = True)
    updated_at = models.DateTimeField(auto_now = True)
    writer = models.ForeignKey(Authors, related_name="writer")

    objects = UserManager()
    
class Reviews(models.Model):
    user_book_review = models.ForeignKey(Users,related_name="user_book_review")
    rating = models.IntegerField(validators=[MinValueValidator(0), MaxValueValidator(5)])
    review = models.TextField(default="")
    books = models.ForeignKey(Books, related_name ="books")
    created_at = models.DateField(auto_now_add = True)
    updated_at = models.DateTimeField(auto_now = True)

    objects = UserManager()

