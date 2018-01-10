def accessDictionary():
    x = {
        "first name": "Anna", "age": 101, "birth": "United States", "language": "Python"
    }
    for key, value in x.items():
        # if key == "first_name":
        #     print "My name is",value
        # elif key == "age":
        #     print "My age is", value
        # elif key == "birth":
        #     print "My country of birth is", value
        # elif key == "language":
        #     print "My favorite language is", value
        print "My ", key, "is ", value 
accessDictionary()