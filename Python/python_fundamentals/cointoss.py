import random

def coinToss(reps):
    heads = 0
    tails = 0
    for i in range (1,reps):
        random_num = random.random()
        random_rounded = round(random_num)
        print "Random number is",random_num
        print "Random rounded number is:",random_rounded
        if random_rounded > 0.5:
            heads+=1
            reps-=1
            print "Attempt:", str(i),"....Throwing a coin....It's a head!", "Got:", str(heads), "heads so far and", str(tails),"tails so far" 
            # print "Number of attempts is", i
            # print "Number of heads is", heads
            # print "Nunber of tails is", tails
            # print "Number of reps remaining is", reps
        else:
            if random_rounded < 0.5:
                tails+=1
                reps-=1
                print "Attempt:", str(i),"....Throwing a coin....It's a tail!", "Got:", str(heads), "heads so far and", str(tails),"tails so far" 
                # print "Number of attempts is", i
                # print "Number of heads is", heads
                # print "Nunber of tails is", tails
                # print "Number of reps remaining is", reps
coinToss(6)