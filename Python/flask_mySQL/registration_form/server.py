
#THIS SHIT WILL NOT VALIDATE ANYMORE

from flask import Flask, request, redirect, render_template, session, flash
from mysqlconnection import MySQLConnector
import re, md5, os, binascii

app = Flask(__name__)
app.secret_key = 'ThisIsSecret'

mysql = MySQLConnector(app,'registration_form')

@app.route('/')
def index():
    return render_template('index.html')

@app.route('/success')
def successful():
    return render_template('success.html')

# # @app.route('/usernamelogin', methods = ['POST'])
# # def registration_success_page():
# #     validity_user = True
# #     print "I got to line 16"
# #     email_check = request.form["user_login_email"]
# #     # password_check = request.form["userpassword"]
# #     query  = "SELECT * FROM users WHERE email = :dataemail"
# #     data = {'dataemail':email_check]}
# #     print data
# #     email_result =  mysql.query_db(query, data)
# #     if len(email_result) == 0:
# #         flash("Email not valid!")
# #         validity_user = False
# #     salt = binascii.b2a_hex(os.urandom(16))
# #     hashed_pw = md5.new(userpassword + salt).hexdigest()
# #     password_check = request.form["userpassword"]
# #     query  = "SELECT * FROM users WHERE password = :datapw"
# #     data = {'datapw': password_check}
# #     pw_result = mysql.query_db(query, data)     
# #     if len(pw_result) == 0:
# #         flash("Invalid password!")
# #         validity_user = False
# #         # session["email_check"]
# #     if user_name_validity = False:
# #         return redirect('/')

#     # tells me if the email
#     #if username exists.... and password correct
#     # put user in session
#     # return redirect to success
#     #if not return to login page with flash message
#     return redirect('/success')
# def login_success_page():
#     # fname_check = request.form["username_login"]
#     # query  = "SELECT id FROM users" 
#     # print query
#     # mysql.query_db(query, data)
#     return redirect('/success')
@app.route ('/process', methods=['POST'])
def registration_process():
    fname = request.form["first_name"]
    lname = request.form["last_name"]
    email = request.form["email"]
    pword = request.form["pw"]
    pconfirm = request.form["pw_confirm"]
    match = re.match('^[_a-z0-9-]+(\.[_a-z0-9-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,4})$', email)
    login_status = True 
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
        print "I got to line 37"
        login_status = False
    print "I got to line 38"
    if pword == pconfirm:
        print "I got to line 40!"
        login_status = True
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
        mysql.query_db(query, data)
        return redirect('/success')

    elif login_status == False:
        return redirect('/')

app.run(debug=True)