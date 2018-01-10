# def odd_even():
#     for i in range (0, 2001):
#         if (i % 2 == 0):
#             print "Number is " + str(i) + ". This is an even number."
#         else:
#             print "Number is " + str(i) + ". This is an odd number" 
# odd_even()

def multiples(a,num):
    for i in a:
        a[i]*=num
        print a
multiples([2,4,10,16],5) #[2,4 ,10,16] sholud return [10,20,50,80]