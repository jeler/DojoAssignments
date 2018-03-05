from django.conf.urls import url
from . import views      
urlpatterns = [
    url(r'^main$', views.main, name="main"),
    url(r'^register_user$', views.register_user, name="register_user"),
    url(r'^login_process$', views.login_process, name="login_process"),
    url(r'^logout$', views.logout, name="logout"),
    url(r'^friends$', views.user_dashboard_page, name="dashboard"),
    url(r'^add_friend/(?P<friend_id>\d+)$', views.add_friend, name="add_friend"),
    url(r'^user/(?P<user_id>\d+)$', views.user_info_page, name="user_info_page"),
    url(r'^delete/(?P<friend_id>\d+)$', views.delete_friend, name="delete_friend"),
          
]