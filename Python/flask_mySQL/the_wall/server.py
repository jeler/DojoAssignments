from flask import Flask, request, redirect, render_template, session, flash
from mysqlconnection import MySQLConnector
import re, md5, os, binascii

app = Flask(__name__)
app.secret_key = 'ThisIsSecret'

mysql = MySQLConnector(app,'the_wall')

@app.route('/')
def index():
    return render_template('index.html')

@app.route('/wall')
def successful():
    if not 'valid_user' in session:
        flash("You need to log in!")
        return redirect('/')
    else:
        name_query = "SELECT CONCAT(first_name, ' ', last_name) AS 'name', id FROM users WHERE users.id = :id"
        name_data = {'id': session['valid_user']}
        name = mysql.query_db(name_query, name_data)
        welcome_name = name[0]['name'] # fetches user name from database and displays based on id
        message_query = "SELECT CONCAT(first_name, ' ', last_name) as 'name', message, DATE(messages.created_at) as 'date', users.id, messages.id from users JOIN messages ON messages.user_id = users.id ORDER BY DATE(messages.created_at) DESC"
        messages = mysql.query_db(message_query)
        # comments_query = "SELECT CONCAT(users.first_name, ' ',  users.last_name) as 'name', DATE(comments.created_at, comment.comments JOIN comments ON comments.users.id = users.id ORDER BY DATE(comments.created_at) DESC" this is not right
        # comments = mysql.query_db(comments_query)
        # add comments = comments in render_template
        return render_template('wall.html', welcome_name = welcome_name, messages = messages)

@app.route('/messagepost', methods=['POST'])
def message_post_success():
    message = request.form['message']
    query  = "INSERT INTO messages (message, updated_at, created_at, user_id) VALUES (:message, NOW(), NOW(), :user_id);"
    data = {
            'message': message,
            'user_id': session['valid_user']
            }
    message_success = mysql.query_db(query, data)

    return redirect('/wall')

@app.route('/commentpost', methods = ['POST'])
def comment_post_success():
    comment = request.form['comment']
    message_id = request.form['message_id']
    query = "INSERT INTO comments (comment, updated_at, created_at, message_id, user_id) VALUES (:comment, NOW(), NOW(), :message_id, :user_id);"
    data = {
            'comment': comment,
            'user_id': session['valid_user'],
            'message_id': message_id #need this to know who is posting
            }
    comment_success = mysql.query_db(query, data)
    return redirect('/wall')

@app.route('/logout')
def reset():
    session.clear()
    return redirect('/')

@app.route('/usernamelogin', methods = ['POST'])
def login_success_page():
    validity_user = True
    email_check = request.form["user_login_email"]
    password_check = request.form["userpassword"]
    user_query = "SELECT * FROM users WHERE users.email = :email LIMIT 1"
    query_data = {'email': email_check}
    user = mysql.query_db(user_query, query_data)
    if len(user) != 0: #validate emaiil 
        encrypted_password = md5.new(password_check + user[0]['salt']).hexdigest()
        if not user[0]['password'] == encrypted_password:
            validity_user = False
            flash("Invalid password!")
    else:
        validity_user = False
        flash("Invalid email")
    if validity_user == False:
        return redirect('/')
    
    session['valid_user'] = user[0]['id']

    return redirect('/wall')

def login_success_page():
    fname_check = request.form["username_login"]
    query  = "SELECT id FROM users" 
    print query
    mysql.query_db(query, data)
    return redirect('/wall')

@app.route ('/process', methods=['POST'])
def registration_process():
    fname = request.form["first_name"]
    lname = request.form["last_name"]
    email = request.form["email"]
    pword = request.form["pw"]
    pconfirm = request.form["pw_confirm"]
    match = re.match('^[_a-z0-9-]+(\.[_a-z0-9-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,4})$', email)
    login_status = True 
    # keep track of all conditions leading to login
    if len(fname) < 2:
        flash("First Name not long enough")
        login_status = False
    print "i got to line 25"
    if not fname.isalpha():
        flash("First Name needs to be letters!")
        login_status = False
    if len(lname) < 2:
        flash("Last Name not long enough")
        login_status = False
    if not lname.isalpha():
        flash("Last Name needs to be letters!")
        login_status = False
    if match == None:
        flash("Email address not valid!")
        login_status = False
        print "i got to line 35"
    if len(pword) < 8:
        flash("Password not long enough!")
        login_status = False
        print "i got to line 37"
    if  not pword == pconfirm:
        flash("Passwords do not match!")
        login_status = False
    print "I got to line 38"
    if pword == pconfirm:
        salt = binascii.b2a_hex(os.urandom(16))
        hashed_pw = md5.new(pword + salt).hexdigest()
    if login_status == True:
        query  = "INSERT INTO users (first_name, last_name, email, password, salt) VALUES (:first_name, :last_name, :email, :password, :salt);"
    # data from request form to mySQL
    # colon allows us to not have to parse string

        data = {
            'first_name': fname,
            'last_name': lname,
            'email': email, 
            'password': hashed_pw,
            'salt': salt
        }
    #submits data from form to mySQL
        session["valid_user"] = mysql.query_db(query, data)
        return redirect('/wall')

    elif login_status == False:
        return redirect('/')

app.run(debug=True)