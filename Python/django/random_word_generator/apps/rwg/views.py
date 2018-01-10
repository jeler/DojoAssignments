from django.shortcuts import render, HttpResponse, redirect
from django.utils.crypto import get_random_string

# Create your views here.

def index(request):
    return render(request, 'rwg/index.html')

def guess(request):
    if request.method == "POST":  
        if "counter" not in request.session:
            request.session['counter'] = 1
            print request.session['counter']
        else:
            request.session['counter']+=1
    request.session['random_word'] = get_random_string(length=14)
    return redirect('/')

def reset(request):
    request.session.clear()
    # print request.session['counter']
    # print request.session['random_word']
    return redirect('/')
