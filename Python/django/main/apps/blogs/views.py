from django.shortcuts import render, HttpResponse, redirect

# Create your views here.

def index(request):
    placeholder = "placeholder to later display all the list of blogs"
    return HttpResponse(placeholder)

def new(request):
    placeholder = "placeholder to display new form for blog"
    return HttpResponse(placeholder)

def create(request):
    return redirect(index)

def show(request, number):
    placeholder = "placeholder to display blog " + number
    return HttpResponse(placeholder)

def edit(request, number):
    placeholder = "placeholder to edit blog " + number
    return HttpResponse(placeholder)

def delete(request, number):
    return redirect(index)

