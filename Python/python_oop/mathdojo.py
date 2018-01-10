class MathDojo(object):
    def __init__ (self):
        self.result = 0

    def add(self, *nums):
        self.result+=sum(nums)
        return self

    def subtract(self, *nums):
        self.result-=sum(nums)
        return self
        
    
    def answer(self):
        print self.result
        return self

dojo1 = MathDojo()
dojo1.add(2).add(2,5).subtract(3,2).answer()


