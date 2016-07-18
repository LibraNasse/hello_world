class vectorList():
    def __init__(self):
        self.vector = []
        
    def setVectorTo(self,vector):
        self.vector = vector
    def add(self,addVector):
        return self.vector + addVector
    def append(self,value):
        return self.vector + [value]
    def count(self, value):
        counter = 0
        for i in self.vector:
            if i == value:
                counter += 1
        return counter


x=vectorList()
x.setVectorTo([1,2,3,3])


print x.app(7)

print x.add([3,5,8])

print x.append(7)

print x.count(3)
