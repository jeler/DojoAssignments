from django.shortcuts import render, redirect, HttpResponse
# from .models import Users, Items
from django.contrib import messages
from django.core.urlresolvers import reverse
from .models import User, Trip

def main(request):
    return render(request, 'travel_buddy/login_reg.html')

def create_account(request):
    action="register"
    valid, response = User.objects.basic_validator(request.POST, action)
    if not valid:
        for message in response: #response has user information from database
            messages.error(request, message)
        return redirect('/main')
    else:
        print "This is response", response
        request.session['id'] = response.id #brackets will not return value
        return redirect('/travels')

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
        return redirect('/travels')

def show_user_page(request):
    if not "id" in request.session:
        messages.error(request, "You're not logged in!")
        return redirect('/main') 
    else:
        user_data = User.objects.get(id = request.session['id'])
        user_travel_plan = user_data.travel_plan.all()
        other_travel_plan = Trip.objects.exclude(planner_id = request.session['id']) 
        session_user_not_joined = other_travel_plan.exclude(travel_plan = request.session['id']) # travel_plan filters based on user_id
        context = {
                "specific_user": user_data,
                "user_plan": user_travel_plan,
                "other_plans": session_user_not_joined,
        }
        return render(request,'travel_buddy/travels.html', context)

def logout(request):
    request.session.clear()
    return redirect('/main')

def add_plan(request):
    user_id = User.objects.get(id =request.session['id'])
    context = {
        "specific_user": user_id
    }
    return render(request, 'travel_buddy/add_travel_plan.html', context)

def create_plan_process(request):
    action = "create_plan"
    valid, response = User.objects.basic_validator(request.POST, action)    
    if not valid:
        for message in response: # response = errors if not valid
            messages.error(request, message)
        return redirect('/travels/add')
    else:
        return redirect('/travels')

def trip_info(request, trip_id):
    this_trip = Trip.objects.filter(id = trip_id)
    print this_trip[0].planner_id
    users_joining = this_trip[0].travel_plan.exclude(id = this_trip[0].planner_id)
    context = {
        "trip_info": this_trip,
        "joined_users": users_joining 
    }
    return render(request, 'travel_buddy/travel_plan_page.html', context)

def join_trip (request, trip_id):
    this_user = User.objects.get(id = request.session['id'])
    this_trip = Trip.objects.get(id = trip_id)
    add_wishlist_item = this_user.travel_plan.add(this_trip) 
    return redirect('/travels')

