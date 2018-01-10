from django.shortcuts import render, redirect, HttpResponse
import models
from .models import Users
from django.contrib import messages
from django.core.urlresolvers import reverse

def index(request):
    return render(request, 'login_registration/index.html')

def create(request):
    action="register"
    valid, response = models.Users.objects.basic_validator(request.POST, action)
    if not valid:
        for message in response: #response has user information from database
            messages.error(request, message)
        return redirect('/')
    else:
        print "This is response", response
        request.session['user_id'] = response.id #brackets will not return value
        print request.session['user_id']
        return redirect('/success')

def login(request):
    action="login"
    valid, response = models.Users.objects.basic_validator(request.POST, action)
    if not valid:
        for message in response:
            messages.error(request, message)
        return redirect('/')
    else:
        print "This is response", response
        logged_in_user = Users.objects.get(id = response)
        request.session['name'] = logged_in_user.first_name
        request.session['id'] = logged_in_user.id
        # print response[0].id
        # request.session['user_id'] = response
        # print request.session['user_id']
        # user_id = request.session['user_id']
        # context = {
        #     "specific_user": Users.objects.get(id = user_id)
        # }
        # print "This is context", context
        # print "This is first name", context.specific_user
        # print context[user_name]
        return redirect('/success')

def success(request):
    if not "id" in request.session:
        messages.error(request, "You're not logged in!")
        return redirect('/') 
    else:
        context = {
                "specific_user": request.session['name']
            }
        return render(request,'login_registration/success.html', context)

def logout(request):
    request.session.clear()
    return redirect('/')