from z3 import *

#0x5E=x^0x31
x = BitVec('x1', 32)  # declaration

formula = ((94 == x ^ 49),
           (x > 32), (x < 126))

s = Solver()
s.add(formula)
s.check()
print(s.model())

