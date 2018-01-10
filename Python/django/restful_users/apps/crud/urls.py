from django.conf.urls import url
from . import views           # This line is new!
urlpatterns = [
    url(r'^$', views.index),
    url(r'^new$', views.new),
    url(r'^create$', views.create),
    url(r'^(?P<user_id>\d+)$', views.id),
    url(r'^(?P<user_id>\d+)/edit', views.edit),
    url(r'^(?P<user_id>\d+)/update$', views.update),  
    url(r'^(?P<user_id>\d+)/delete$', views.delete),       
         
]