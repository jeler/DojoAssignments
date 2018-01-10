import random
def grades(reps):
    for i in range(reps):
        random_num = random.randint(0,100)
        # print random_num
        if (random_num >=60) & (random_num <=69):
            print "Score " + str(random_num) + ": Your grade is D"
        elif (random_num >=70) & (random_num <=79):
            print "Score " + str(random_num) + ": Your grade is C"
        elif (random_num >=80) & (random_num <=89):
            print "Score " + str(random_num) + ": Your grade is B"
        elif (random_num >=90) & (random_num <=100):
            print "Score " + str(random_num) + ": Your grade is A"
        else:
            print "You failed!"
    print "End of the Program! Bye!"
grades(10)