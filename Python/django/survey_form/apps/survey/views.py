from django.shortcuts import render, HttpResponse, redirect

def index(request):
    return render(request, 'survey/index.html')

def process(request):
    if request.method == "POST":
        request.session['results']= request.POST
    if "counter" not in request.session:
        request.session['counter'] = 1
    else:
        request.session['counter']+=1
    return redirect('/result')

def result(request):
    return render(request, 'survey/result.html')
