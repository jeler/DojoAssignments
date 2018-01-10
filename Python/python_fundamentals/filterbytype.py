def testList(user_input):
    if type(user_input) == list:
        if len(user_input) > 50:
            print "Big List!"
        else:
            print "Short List!"
    elif type(user_input) == int:
        if user_input >= 100:
            print "That's a big number"
        else:
            print "That's a small number"
    else:
        type(user_input) == str
        if len(user_input) >= 50:
            print "Long sentence"
        else:
            print "Short sentence"
testList(45)
testList(100)
testList(455)
testList(0)
testList(-23)
testList("Rubber baby buggy bumpers")
testList("Experience is simply the name we give our mistakes")
testList("Tell me and I forget. Teach me and I remember. Involve me and I learn.")
testList("")
spI = -23
sS = "Rubber baby buggy bumpers"
mS = "Experience is simply the name we give our mistakes"
bS = "Tell me and I forget. Teach me and I remember. Involve me and I learn."
eS = ""
aL = [1,7,4,21]
mL = [3,5,7,34,3,2,113,65,8,89]
lL = [4,34,22,68,9,13,3,5,7,9,2,12,45,923]
eL = []
spL = ['name','address','phone number','social security number']