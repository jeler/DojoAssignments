class product(object):
    def __init__(self, price, item_name, weight, brand):
        self.price = price
        self.item_name = item_name
        self.weight = weight
        self.brand = brand
        self.status = "for sale"

    def sell(self):
        self.status = "sold"
        return self

    def addTaxes(self, tax):
        self.new_price = (tax * self.price) + self.price
        return self

    def returnProduct(self, reason):
        if reason == "defective":
            self.status = "defective"
            self.new_price = 0
        elif reason == "in_box":
            self.status = "for sale"
        elif reason == "box_opened":
            self.status = "used"
            discount = (0.20 * self.new_price)
            self.new_price = self.new_price - discount
        return self

    def displayinfo(self):
        print "Price is:", self.new_price
        print "Item Name is:", self.item_name
        print "Weight is:", self.weight
        print "Brand is:", self.brand
        print "Self Status is:", self.status

product1 = product(1000, "tampon", "5 grams", "Golden Tampon")
product2 = product(1000, "car", "1000 pounds", "Rustbucket" )
product3 = product(10, "teddy bear", "2 pounds", "Worthless Ty Beanie Baby")
# product1.sell().addTaxes(0.15).displayinfo()
product1.addTaxes(0.10).returnProduct("box_opened").displayinfo()
product2.addTaxes(0.10).returnProduct("in_box").displayinfo()
product3.addTaxes(0.10).returnProduct("defective").displayinfo()

