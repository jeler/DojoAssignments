from django.shortcuts import render, HttpResponse, redirect
from django.utils.crypto import get_random_string

# Create your views here.

def index(request):
    unique_id = {
        'random_word': get_random_string(length=14)
    }
    return render(request, 'random_word_generator/index.html', unique_id)

def guess(request):
    if request.method == "POST":  
        if "counter" not in request.session:
            request.session['counter'] = 0
        else:
            request.session['counter']+=1
    return redirect('/random_word_generator')

def reset(request):
    if "counter" in request.session:
        request.session.clear()
    return redirect('/random_word_generator')
