from flask import Flask, render_template, request, redirect

app = Flask(__name__)

@app.route('/')
def root_page():
    return render_template('index.html')

@app.route('/ninja/')
def every_ninjas():
    return render_template('all_ninjas.html')

@app.route('/ninja/<color>')
def all_ninjas(color):
    if color == "blue":
        return render_template('ninja.html', color = 'blue')
    elif color == "orange":
        return render_template('ninja.html', color = 'orange')
    elif color == "purple":
        return render_template('ninja.html', color = 'purple')
    elif color == "red":
        return render_template('ninja.html', color = 'red')
    else:
        return render_template('ninja.html')
app.run(debug = True)