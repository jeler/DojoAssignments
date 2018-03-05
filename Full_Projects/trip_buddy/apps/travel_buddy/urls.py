from django.conf.urls import url
from . import views  
urlpatterns = [
        url(r'^main$', views.main, name="main"),
        url(r'^create_account$', views.create_account, name="create_account"),
        url(r'^travels$', views.show_user_page, name="show_user_page"), 
        url(r'^login_process$', views.login_process, name="login_process"),
        url(r'^logout$', views.logout, name="logout"),
        url(r'^travels/add$', views.add_plan, name="create_plan"),
        url(r'^create_process$', views.create_plan_process, name="create_process"),
        url(r'^travels/destination/(?P<trip_id>\d+)$', views.trip_info, name="travel_info_page"),
        url(r'^travels/join_trip/(?P<trip_id>\d+)$', views.join_trip, name="join_trip"),           
]