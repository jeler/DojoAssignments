from django.conf.urls import url
from . import views           # This line is new!
urlpatterns = [
    url(r'^random_word_generator$', views.index),
    url(r'^guess$', views.guess),
    url(r'^reset$', views.reset)
    
]