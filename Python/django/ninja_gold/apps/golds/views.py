from django.shortcuts import render, HttpResponse, redirect

from random import randint

from datetime import datetime

# Create your views here.
def index(request):
    if "user_gold" not in request.session:
        request.session['user_gold'] = 0
    if "messages" not in request.session:
        request.session['messages'] = []
    return render(request, 'golds/index.html')

def process_money(request):
    if request.method == "POST":
        farm_gold = randint(10,20)
        print farm_gold
        cave_gold = randint(5, 10)
        house_gold = randint(2, 5)
        casino_gold = randint(-50, 50) #Does not seem to give negative values: why??
        # time = strftime("%Y-%m-%d %H:%M %p", gmtime())
        now = datetime.now()
        if request.POST['building'] == "farm":
            request.session['user_gold']+=farm_gold
            message = "Earned " + str(farm_gold)+ " gold from the farm " + str(now)
        if request.POST['building'] == "cave":
            request.session['user_gold']+=cave_gold
            message = "Earned " + str(cave_gold)+ " gold from the cave " + str(now)
        if request.POST['building'] == "house":
            request.session['user_gold']+=house_gold
            message = "Earned " + str(cave_gold)+ " gold from the house" + str(now)
        if request.POST['building'] == "casino":
            request.session['user_gold']+=cave_gold
            message = "Earned " + str(cave_gold)+ " gold from the casino " + str(now)

        request.session['messages'].append(message)
    return redirect('/')

def reset(request):
    request.session.clear()
    return redirect('/')