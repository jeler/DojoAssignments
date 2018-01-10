from flask import Flask, render_template, request, redirect

app = Flask(__name__)

@app.route('/')

def root():
    return render_template('index.html')


@app.route('/ninjas')
def ninjas():
    return render_template('ninjas.html')
    
@app.route('/dojos/')
def dojotemp():
    return render_template('dojo.html')

@app.route('/dojos/new', methods=['POST'])
def create_user():    
    name = request.form['name']
    email = request.form['email']
    return redirect('/dojos/')

app.run(debug = True)