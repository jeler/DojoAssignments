class bike(object):
    
    def __init__(self, price, max_speed):
        self.price = price #instance variables
        self.max_speed = max_speed
        self.miles = 0
        
    def ride(self):
        self.miles+=10
        print "Riding", self.miles
        return self

    def displayinfo(self):
        print "The price is", self.price, "The miles are", self.miles, "The speed is", self.max_speed
        return self

    def reverse(self):
        self.miles-=5
        print "Reversing", self.miles
        return self

bike1 = bike(200, "25mph")
bike2 = bike(200, "50mph")
bike3 = bike(150, "50mph")
bike1.ride().ride().ride().reverse().displayinfo()
bike2.ride().ride().reverse().reverse().displayinfo()
bike3.reverse().reverse().displayinfo()
