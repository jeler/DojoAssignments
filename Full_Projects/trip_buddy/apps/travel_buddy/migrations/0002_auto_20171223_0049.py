# -*- coding: utf-8 -*-
# Generated by Django 1.10 on 2017-12-23 00:49
from __future__ import unicode_literals

from django.db import migrations, models


class Migration(migrations.Migration):

    dependencies = [
        ('travel_buddy', '0001_initial'),
    ]

    operations = [
        migrations.AlterField(
            model_name='trip',
            name='travel_plan',
            field=models.ManyToManyField(related_name='travel_plan', to='travel_buddy.User'),
        ),
    ]