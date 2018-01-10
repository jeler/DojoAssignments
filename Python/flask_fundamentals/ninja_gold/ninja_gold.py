from flask import Flask, render_template, request, redirect, session

from datetime import datetime

import random

app = Flask(__name__)
app.secret_key = 'ThisIsSecret'

@app.route('/')
def bank():
    if "user_gold" not in session:
        session['user_gold'] = 0
    if "messages" not in session:
        session['messages'] = []
    return render_template('index.html')

@app.route('/process_money', methods=["POST"])
def earned_gold():
    farm_gold = random.randint(10,20)
    cave_gold = random.randint(5, 10)
    house_gold = random.randint(2, 5)
    casino_gold = random.randint(-50, 50)
    now = datetime.now()
    building = request.form["building"]
    if building == "farm":
        session['user_gold']+=farm_gold
        message = "Earned " + str(farm_gold)+ " gold from the farm " + str(now)
    elif building == "cave":
        session['user_gold']+=cave_gold
        message = "Earned " + str(cave_gold) + " gold from the cave " + str(now)
    elif building == "house":
        session['user_gold']+=house_gold
        message = "Earned " + str(house_gold) + " gold from the house " + str(now)    
    elif building == "casino":
        session['user_gold']+=casino_gold
        message = "Earned " + str(casino_gold) + " gold from the casino " + str(now)

    session['messages'].append(message)
    
    return redirect('/')

@app.route('/reset')
def reset():
    session.clear()
    return redirect('/')


app.run(debug = True)