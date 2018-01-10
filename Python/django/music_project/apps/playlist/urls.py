from django.conf.urls import url
from . import views  
urlpatterns = [
    url(r'^main$', views.main, name="main"),
    url(r'^register_account$', views.register_account, name="register_account"),
    url(r'^login_process$', views.login, name="login_process"),    
    url(r'^dashboard$', views.dashboard, name="dashboard"),
    url(r'^logout$', views.logout, name="logout"),
    url(r'^add_song$', views.add_song, name="add_song"),            

]