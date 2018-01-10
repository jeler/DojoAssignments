from django.shortcuts import render, redirect, HttpResponse
from .models import Users, Books, Reviews, Authors
from django.contrib import messages

def index(request):
    return render(request, 'users/index.html')

def register_user(request):
    action="register"
    valid, response = Users.objects.basic_validator(request.POST, action)
    if not valid:
        for message in response: #response has user information from database
            messages.error(request, message)
        return redirect('/')
    else:
        print "This is response", response
        request.session['id'] = response.id #brackets will not return value
        print request.session['id']
        return redirect('/books')

def login_user(request):
    action="login"
    valid, response = Users.objects.basic_validator(request.POST, action)
    if not valid:
        for message in response:
            messages.error(request, message)
        return redirect('/')
    else:
        logged_in_user = Users.objects.get(id = response)
        request.session['id'] = logged_in_user.id
        return redirect('/books')

def user_dashboard_page(request):
    if not "id" in request.session:
        messages.error(request, "You're not logged in!")
        return redirect('/') 
    else:
        user_data = Users.objects.get(id = request.session['id'])
        user_book_reviews = Reviews.objects.order_by('-updated_at').all()
        books_with_reviews = Books.objects.all()
        context = {
                "specific_user": user_data,
                "book_reviews": user_book_reviews,
                "other_books_with_reviews": books_with_reviews,
            }
        return render(request,'users/dashboard.html', context)

def logout(request):
    request.session.clear()
    return redirect('/')

def add_book_review(request): #add a book and redirect to user page
    user_data = Users.objects.get(id = request.session['id'])
    book_data = Authors.objects.all()
    context = {
            "specific_user": user_data,
            'author_data': book_data,
        }
    # print book_data[0].author
    return render(request,'users/review.html', context)

def book_review_process(request): #form processing book reviews
    action ="create_new_book"
    valid, response = Users.objects.basic_validator(request.POST, action)   
    if not valid:
        for message in response:
            messages.error(request, message)
        return redirect('/books/add')
    else: 
        this_user = Users.objects.get(id = request.session['id'])
        this_book = Books.objects.get(id = response.id)
        print response.id
        return redirect('/books/' + str(response.id))


def book_review_page(request, book_id):
    book_data = Books.objects.filter(id = book_id)
    review_data = Reviews.objects.filter(books_id = book_id)
    this_user = Users.objects.get(id = request.session['id'])
    context = {
        "book_data": book_data,
        "reviews": review_data,
        "specific_user": this_user,
    }
    return render(request, 'users/book_page.html', context)

def add_review_from_page_process(request):
    action = "create_review_from_page"
    valid, response = Users.objects.basic_validator(request.POST, action)
    # info in form available here!
    if not valid:
        for message in response:
            messages.error(request, message)
        return redirect('/books/' + request.POST['book_id'])
    else:
        return redirect('/books/' + response)

def user_book_reviews(request, user_id):
    user_info = Users.objects.filter(id = user_id)
    user_reviews = Reviews.objects.filter(user_book_review_id = user_id)
    # other_books =  user_reviews[0].books.book_title
    context = {
        "user_info": user_info,
        "user_review_count": len(user_reviews),
        "other_books": user_reviews,
    }
    #problem: other_books only posts the first book reviewed NOT all. For loop did not solve problem

    return render(request,'users/user_info_page.html', context)

def delete_user_review(request, book_id):
    user_review_delete = Reviews.objects.get(id = book_id)
    user_review_delete.delete()
    return redirect('/books')
