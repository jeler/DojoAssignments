from django.conf.urls import url
from . import views           # This line is new!
urlpatterns = [
    url(r'^$', views.index, name="my_index"),
    url(r'^register_user$', views.register_user, name="register_user"),
    url(r'^login_page$', views.user_dashboard_page, name="login_page"),
    url(r'^login_process$', views.login_user, name="login_user"),
    url(r'^logout$', views.logout, name="logout"),
    url(r'^books$', views.user_dashboard_page, name="dashboard"),
    url(r'^books/add$', views.add_book_review, name="book"),
    url(r'^books/review_process$', views.book_review_process, name="book_review_process"),    
    url(r'^books/(?P<book_id>\d+)$', views.book_review_page, name="book_review_page"),
    url(r'^books/add_review_from_page_process$', views.add_review_from_page_process, name="add_review_from_page_process"),
    url(r'^users/(?P<user_id>\d+)$', views.user_book_reviews, name="user_book_reviews"),
    url(r'^delete/(?P<book_id>\d+)$', views.delete_user_review, name="delete_user_review"),
          
]