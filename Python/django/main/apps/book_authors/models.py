from __future__ import unicode_literals

from django.db import models

class Books(models.Model):
    name = models.CharField(max_length=255)
    desc = models.TextField(max_length=1000)
    created_at = models.DateTimeField(auto_now_add = True)
    updated_at = models.DateTimeField(auto_now = True)
    def __repr__(self):
        return "<User object: {} {}>".format(self.name, self.desc)

class Authors(models.Model):
    first_name = models.CharField(max_length = 255)
    last_name = models.CharField(max_length = 255)
    email = models.CharField(max_length = 255)
    created_at = models.DateTimeField(auto_now_add = True)
    updated_at = models.DateTimeField(auto_now = True)
    book = models.ManyToManyField(Books, related_name = "book_authors")
    notes = models.TextField()
    def __repr__(self):
        return "<User object: {} {}>".format(self.first_name, self.last_name)

