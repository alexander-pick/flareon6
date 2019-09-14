from z3 import *

#0x5E=x^0x31
x = BitVec('x1', 32)  # declaration

#40
formula = ((0x73 == x ^ 0x40),
           (x > 32), (x < 126))
#41
formula = ((0x2e == x ^ 0x66),
           (x > 32), (x < 126))

# #42
# formula = ((0x9 == x ^ 0x72),
#            (x > 32), (x < 126))

#44
formula = ((0x16 == x ^ 0x72),
           (x > 32), (x < 126))

#46
formula = ((0x49 == x ^ 0x2d),
           (x > 32), (x < 126))
#47
formula = ((0x22 == x ^ 0x6f),
           (x > 32), (x < 126))

formula = ((0x1 == x ^ 0x6e),
           (x > 32), (x < 126))

formula = ((0x40 == x ^ 0x2e),
           (x > 32), (x < 126))

formula = ((0x8 == x ^ 0x63),
           (x > 32), (x < 126))

formula = ((0xA == x ^ 0x6f),
           (x > 32), (x < 126))

formula = ((0x14 == x ^ 0x6d),
           (x > 32), (x < 126))

formula = ((0x73 == x ^ 0x40),
           (x > 32), (x < 126))

s = Solver()
s.add(formula)
s.check()
print(s.model())
