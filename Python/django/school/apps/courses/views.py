from django.shortcuts import render, redirect
from .models import Course
from django.contrib import messages

def main(request):
    all_courses = Course.objects.all()
    context = {
        "all_courses": all_courses
    }
    return render(request, "courses/main.html", context)

def add_course(request):
    action = "add_course"
    valid, response = Course.objects.basic_validator(request.POST, action)
    if not valid:
        for message in response: #response has user information from database
            messages.error(request, message)
        return redirect('/')
    else:
        return redirect('/')
def destroy_course(request, course_id):
    this_course = Course.objects.filter(id = course_id)
    context  = {
        "course_info": this_course

    }
    return render(request, "courses/destroy.html", context)

def delete_course(request, course_id):
    course = Course.objects.get(id = course_id)
    course.delete()
    return redirect('/')
