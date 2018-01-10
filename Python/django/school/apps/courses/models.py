from __future__ import unicode_literals

from django.db import models

class CourseManager(models.Manager):
    def basic_validator(self, postData, action): #request.post =  postData
        errors = []
        course_name = postData.get('name')
        course_description = postData.get('description')
        if action == "add_course":
            if len(course_name) < 5:
                errors.append("Course name needs to be greater than 5 letters!")
            if len(course_description) > 15:
                errors.append("Description can not be more than 15 characters!")
            if len(course_description) < 1:
                errors.append("Course description can not be blank!")
            if len(errors) == 0:
                create_course = Course.objects.create(name= course_name, description = course_description)
                return (True, create_course)
            else: 
                return (False, errors)

class Course(models.Model):
    name = models.CharField(max_length=255)
    description = models.CharField(max_length=255)
    created_at = models.DateTimeField(auto_now_add = True)
    updated_at = models.DateTimeField(auto_now = True)
    def __repr__(self):
        return "<Course object: {} {}>".format(self.name, self.description)

    objects = CourseManager()