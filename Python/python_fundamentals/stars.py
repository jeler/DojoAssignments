def drawStars(arr):
    for i in range(0, len(arr)-1):
        print "This is arr[i[",arr[i]
        print "This is arr[i]* star",arr[i]* "*"
drawStars([4, 6, 1, 3, 5, 7, 25])

def stringStats(arr):
    for i in range (0, len(arr)):
        if isinstance(arr[i],str):
            new = arr[i].lower()
            arr[i] = new
            first_letter = new[0]
            # print "new =", new
            # print "new[0]*i=",new[0] * len(new)
            arr[i] = new[0]*i
        elif isinstance(arr[i],int):
            # print "This is arr[i[",arr[i]
            # print "This is arr[i]* star",arr[i]* "*"
            arr[i]= arr[i]* "*"
    print arr
stringStats([4, "Tom", 1, "Michael", 5, 7, "Jimmy Smith"])
