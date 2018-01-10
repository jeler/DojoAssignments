from flask import Flask, render_template, request, redirect, session

import random

app = Flask(__name__)
app.secret_key = 'ThisIsSecret'

@app.route('/')
def random_num():
    if "number" not in session: 
        session['number'] = random.randint(0,10)
    print "The password is", session['number']
    return render_template('index.html', number = session['number'])

@app.route('/results', methods=['POST'])
def outcome():
    guess = int(request.form['number'])
    if session['number'] == guess:
        message = "You're Right!"
    elif session['number'] > guess:
        message = "Too Low"
    elif session['number'] < guess:
        message ="Too High"
        
    session['message'] = message

    return redirect('/')

@app.route('/reset')
def reset():
    session.clear()
    return redirect('/')

app.run(debug = True)