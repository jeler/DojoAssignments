from flask import Flask, render_template, request, redirect, session

app = Flask(__name__)
app.secret_key = 'ThisIsSecret'

@app.route('/')
def root_page():
    if "count" not in session:
        session['count'] = 0

    else:
        session['count']+=1

    return render_template('index.html', counter = session['count'])

@app.route('/results')
def addtwo():
    if "count" in session:
        session['count']+=1
    return redirect('/')

@app.route('/reset')
def reset():
    if "count" in session:
        session['count'] = 0
        # session.clear()
    return redirect('/')

app.run(debug = True)