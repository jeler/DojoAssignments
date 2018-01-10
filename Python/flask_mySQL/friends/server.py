from flask import Flask, request, redirect, render_template, session, flash
from mysqlconnection import MySQLConnector
app = Flask(__name__)
mysql = MySQLConnector(app,'friendsdb')

@app.route('/')
def index():
    friends = mysql.query_db("SELECT * FROM friends")
    return render_template('index.html', all_friends = friends ) ## all_friends variable bridges python and HTML files

@app.route('/friends', methods=['POST'])
def create(): # communicates to mySQL what is submitted on request form
    
    query  = "INSERT INTO friends (first_name, last_name, occupation, created_at, updated_at) VALUES (:first_name, :last_name, :occupation, NOW(), NOW());"
    #data from request form to mySQL

    data = {
        'first_name': request.form['first_name'],
        'last_name': request.form['last_name'],
        'occupation': request.form['occupation']
    }
    #submits data from form to mySQL

    mysql.query_db(query, data)

    return redirect('/')
app.run(debug=True)
