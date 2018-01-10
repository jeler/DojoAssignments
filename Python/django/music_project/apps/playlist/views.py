from django.shortcuts import render, redirect, HttpResponse
from .models import User, Song
from django.contrib import messages

def main(request):
    return render(request, 'playlist/loginreg.html')

def register_account(request):
    action="register"
    valid, response = User.objects.basic_validator(request.POST, action)
    if not valid:
        for message in response: #response has user information from database
            messages.error(request, message)
        return redirect('/main')
    else:
        request.session['id'] = response.id
        return redirect('/dashboard')

def login(request):
    action="login"
    valid, response = User.objects.basic_validator(request.POST, action)
    if not valid:
        for message in response: #response has user information from database
            messages.error(request, message)
        return redirect('/main')
    else:
        print response
        request.session['id'] = response
        return redirect('/dashboard')

def dashboard(request):
    if not "id" in request.session:
        messages.error(request, "You're not logged in!")
        return redirect('/main') 
    else:
        user_data = User.objects.get(id = request.session['id'])
        user_playlist = user_data.playlist.all()
        print user_playlist[0].title
        context = {
            "specific_user": user_data,
            "user_playlist": user_playlist
        }
        
        return render(request, 'playlist/dashboard.html', context)

def logout(request):
    request.session.clear()
    return redirect('/main')

def add_song(request):
    action = "add_song"
    valid, response = User.objects.basic_validator(request.POST, action)
    if not valid:
        for message in response: #response has user information from database
            messages.error(request, message)
        return redirect('/dashboard')
    return redirect('/dashboard')


