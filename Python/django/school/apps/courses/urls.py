from django.conf.urls import url
from . import views  
urlpatterns = [
    url(r'^$', views.main, name="main"),  
    url(r'^add_course$', views.add_course, name="add_course"),
    url(r'^courses/destroy/(?P<course_id>\d+)$', views.destroy_course, name="destroy_course"),
    url(r'^delete_course/(?P<course_id>\d+)$', views.delete_course),                        
]