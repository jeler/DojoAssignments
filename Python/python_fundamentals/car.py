class Car(object):
    
    def __init__(self, price, speed, fuel, mileage):
        self.price = price
        self.speed = speed
        self.fuel = fuel
        self.mileage = mileage
        if self.price > 10000:
            self.tax = 0.15
        elif self.price < 10000:
            self.tax = 0.12

    def displayall(self):
            print "Price:", self.price
            print "Speed:", self.speed
            print "Fuel:", self.fuel
            print "Mileage:", self.mileage
            print "Tax:", self.tax
            return self

Car1 = Car(8000, "15mph", "Full", "60mpg")
Car1.displayall()
            