from django.shortcuts import render, redirect, HttpResponse
from django.contrib import messages
from .models import User

def main(request):
    return render(request, "friends_list/main.html")

def register_user(request):
    action="register"
    valid, response = User.objects.basic_validator(request.POST, action)
    if not valid:
        for message in response: #response has user information from database
            messages.error(request, message)
        return redirect('/main')
    else:
        request.session['id'] = response.id #brackets will not return value
        return redirect('/friends')

def user_dashboard_page(request):
    this_user = User.objects.get(id = request.session['id'])
    other_users = User.objects.exclude(id= request.session['id'])
    friends_list_users = this_user.friend.all()
    users_not_on_list = other_users.exclude(friend = request.session['id'])    
    context = {
        "specific_user": this_user,
        "other_users": users_not_on_list,
        "friends_list_users": friends_list_users
    }
    return render(request, "friends_list/friends.html", context)

def login_process(request):
    action="login"
    valid, response = User.objects.basic_validator(request.POST, action)
    print 'response is', response #if valid, response = user_id
    if not valid:
        for message in response: # response = errors if not valid
            messages.error(request, message)
        return redirect('/main')
    else:
        request.session['id'] = response
        print "This is response", response
        return redirect('/friends')


def logout(request):
    request.session.clear()
    return redirect('/main')

def add_friend(request, friend_id):
    this_user = User.objects.get(id = request.session['id'])
    this_friend = User.objects.get(id = friend_id)
    add_friend =  this_user.friend.add(this_friend) 
    return redirect('/friends')

def user_info_page(request, user_id):
    this_friend = User.objects.get(id = user_id)
    context = {
        "this_friend": this_friend
    }
    return render(request, "friends_list/user_page.html", context)

def delete_friend(request, friend_id):
    this_user = User.objects.get(id = request.session['id'])
    this_friend = User.objects.get(id = friend_id)
    remove_friend = this_user.friend.remove(this_friend)
    return redirect('/friends')