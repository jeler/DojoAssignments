def findCharacters(word_list,char):
    new_list = []
    for i in word_list:
        print i.find(char)
        if i.find(char) > 0:
           new_list.append(i)   
    print new_list
findCharacters(['hello','world','my','name','is','Anna'],"o") #new_list = ["hello", "world"]