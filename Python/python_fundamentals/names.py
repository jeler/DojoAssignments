# def names ():
#     students = [
#      {'first_name':  'Michael', 'last_name' : 'Jordan'},
#      {'first_name' : 'John', 'last_name' : 'Rosales'},
#      {'first_name' : 'Mark', 'last_name' : 'Guillen'},
#      {'first_name' : 'KB', 'last_name' : 'Tonel'}
# ]
#     for student in students:
#         nameCombo = ""
#         for key, data in student.items():
#             nameCombo+=data + " "
#         print nameCombo

# names()

def names2():
    users = {
    'Students': [
        {'first_name':  'Michael', 'last_name' : 'Jordan'},
        {'first_name' : 'John', 'last_name' : 'Rosales'},
        {'first_name' : 'Mark', 'last_name' : 'Guillen'},
        {'first_name' : 'KB', 'last_name' : 'Tonel'}
    ],
    'Instructors': [
        {'first_name' : 'Michael', 'last_name' : 'Choi'},
        {'first_name' : 'Martin', 'last_name' : 'Puryear'}
    ]
    }
    
    for level, row in users.items(): #accesses users level = key in this case
        print level #accesses students/instructors
        count = 0
        for person in row: # print "s=", students #accesses names within students
            count+=1
            ln = "" #concatenate first_name + last_name
            length = 0
            for key, value in person.items():
                # print "v=", value
                ln+=value + " "
                length += len(value)
            print count,ln,length         
names2()