class Animal(object):
    def __init__(self, name, health):
        self.name = name
        self.health = health
    
    def walk(self):
        self.health-=1
        return self

    def run(self):
        self.health-=5
        return self

    def displayHealth(self):
        print "Health is:", self.health
        return self

class Dog(Animal):
    def __init__(self, name):
        super(Dog, self).__init__(name, 150) #defaults health to 150
    
    def pet(self):
        self.health+=5
        return self

class Dragon(Animal):
    def __init__(self,name):
        super(Dragon, self).__init__(name, 170)

    def fly(self):
        self.health+=10
        return self

    def displayHealth(self):
        print "This is a dragon"
        super(Dragon,self).displayHealth()

# dragon1 = Dragon("Pookey")
# dragon1.fly().displayHealth()

dog1= Dog("Fido")
dog1.pet().displayHealth()

animal1 = Animal("Buddy", 200) #will not run: throws Attribute error
animal1.pet().fly().displayHealth()