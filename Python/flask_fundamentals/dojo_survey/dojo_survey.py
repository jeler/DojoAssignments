from flask import Flask, render_template, request, redirect

app = Flask(__name__)

@app.route('/')
def root_page():
    return render_template('index.html')


@app.route('/results', methods=['POST'])
def answer():
    result = request.form
    return render_template("result.html", monkey = result)

app.run(debug = True)