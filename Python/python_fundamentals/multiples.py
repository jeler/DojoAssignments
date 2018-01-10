
def countrange(num):
    for count in range (0, num): #part 1
        if count % 2 !=0:
            print count
countrange(1000)

for count in range (5, 1000000): #part2
    if(count % 5 == 0):
        print count
numbers = [1, 2, 5, 10, 255, 3]
print sum(numbers)
average = sum(numbers) / len(numbers)
print average



