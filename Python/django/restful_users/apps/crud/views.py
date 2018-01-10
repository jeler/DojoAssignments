from django.shortcuts import render, redirect, HttpResponse
import models
from django.contrib import messages

def index(request):
    users =  { 
        "all_users": models.Users.objects.all(),
    }
    return render(request, 'crud/index.html', users)

def new(request): 
    return render(request, 'crud/users.html')
#this may be wrong. accidentely changed.

def create(request,user_id):
    return redirect(request, '/users/' + user_id)

def id(request, user_id):
    user_info = {
        "specific_user": models.Users.objects.get(id = user_id) #id refers to columm in database
    }
    print user_info
    return render(request, 'crud/id.html', user_info)

def edit(request, user_id):
    edit_user = {
        "specific_user": models.Users.objects.get(id = user_id) #id refers to columm in database
    }
    return render(request,'crud/edit.html', edit_user)

def update(request, user_id): #update route
    action = "update"
    valid, response = models.Users.objects.basic_validator(request.POST, action)
    if not valid:
        for message in response:
            messages.error(request, message)
            print "Message is", message
        return redirect('/users/'+ user_id + '/edit')
    else:
        return redirect('/users/'+ user_id)

def delete(request, user_id):
    entry = models.Users.objects.filter(id = user_id)
    entry.delete()
    return redirect('/users/') 