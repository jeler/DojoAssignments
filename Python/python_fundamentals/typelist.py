def typeList(x): 
    sum = 0
    myString =""
    count=0
    strCount = 0
    for i in x:
        if type(i) == int or type(i)==float:
            sum+=i
            count+=1
        elif type(i) == str:
           myString+=i + " "
           strCount+=1
    if count > 0 and strCount > 0:
        print "The list you entered is of mixed type"
    elif count > 0 and strCount == 0:
        print "The list you entered is of integer type"
    elif count == 0 and strCount > 0:
        print "The list you entered is of string type"
    print "String:", myString
    print "Sum:", sum
typeList(['magical unicorns',19,'hello',98.98,'world'])