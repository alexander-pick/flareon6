from z3 import *

x = BitVec('x1', 32)  # declaration
y = BitVec('x2', 32)  # declaration

formula = ((65 == x ^ y),
           (x > 32), (x < 126),
           (y > 32), (y < 126))

s = Solver()
s.add(formula)
s.check()
print(s.model())