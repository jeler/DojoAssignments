def compare(list_one,list_two):
    if list_one == list_two:
        print "The lists are the same"
    else:
        print "The lists are not the same"
    # for i in list_one:
    #     for j in list_two:
    #         if list_one[i] != list_two[j]:
    #             print "The lists are not the same"
    #         else:
    #             print "The lists are the same"
compare ([1,2,5,6,2], [1,2,5,6,2])
compare (['celery','carrots','bread','milk'], ['celery','carrots','bread','cream'])
compare ([1,2,5,6,5], [1,2,5,6,5,3])