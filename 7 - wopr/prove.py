from z3 import *

x = 16 * [None]

x[0] = BitVec('x1', 32)  # declaration
x[1] = BitVec('x2', 32)  # declaration
x[2] = BitVec('x3', 32)  # declaration
x[3] = BitVec('x4', 32)  # declaration
x[4] = BitVec('x5', 32)  # declaration
x[5] = BitVec('x6', 32)  # declaration
x[6] = BitVec('x7', 32)  # declaration
x[7] = BitVec('x8', 32)  # declaration
x[8] = BitVec('x9', 32)  # declaration
x[9] = BitVec('x10', 32)  # declaration
x[10] = BitVec('x11', 32)  # declaration
x[11] = BitVec('x12', 32)  # declaration
x[12] = BitVec('x13', 32)  # declaration
x[13] = BitVec('x14', 32)  # declaration
x[14] = BitVec('x15', 32)  # declaration
x[15] = BitVec('x16', 32)  # declaration

# h = [61, 90, 212, 247, 184, 116, 84, 20, 93, 193, 157, 118, 182, 31, 173, 77]

h = [111, 202, 211, 230, 233, 7, 148, 22, 147, 13, 93, 180, 132, 0, 124, 76]

#h = [30, 254, 225, 26, 229, 131, 35, 120, 29, 18, 211, 112, 227, 1, 101, 119]
h = [115, 29, 32, 68, 106, 108, 89, 76, 21, 71, 78, 51, 75, 1, 55, 102]

formula = ((h[0] == x[2] ^ x[3] ^ x[4] ^ x[8] ^ x[11] ^ x[14]),
           (h[1] == x[0] ^ x[1] ^ x[8] ^ x[11] ^ x[13] ^ x[14]),
           (h[2] == x[0] ^ x[1] ^ x[2] ^ x[4] ^ x[5] ^ x[8] ^ x[9] ^ x[10] ^ x[13] ^ x[14] ^ x[15]),
           (h[3] == x[5] ^ x[6] ^ x[8] ^ x[9] ^ x[10] ^ x[12] ^ x[15]),
           (h[4] == x[1] ^ x[6] ^ x[7] ^ x[8] ^ x[12] ^ x[13] ^ x[14] ^ x[15]),
           (h[5] == x[0] ^ x[4] ^ x[7] ^ x[8] ^ x[9] ^ x[10] ^ x[12] ^ x[13] ^ x[14] ^ x[15]),
           (h[6] == x[1] ^ x[3] ^ x[7] ^ x[9] ^ x[10] ^ x[11] ^ x[12] ^ x[13] ^ x[15]),
           (h[7] == x[0] ^ x[1] ^ x[2] ^ x[3] ^ x[4] ^ x[8] ^ x[10] ^ x[11] ^ x[14]),
           (h[8] == x[1] ^ x[2] ^ x[3] ^ x[5] ^ x[9] ^ x[10] ^ x[11] ^ x[12]),
           (h[9] == x[6] ^ x[7] ^ x[8] ^ x[10] ^ x[11] ^ x[12] ^ x[15]),
           (h[10] == x[0] ^ x[3] ^ x[4] ^ x[7] ^ x[8] ^ x[10] ^ x[11] ^ x[12] ^ x[13] ^ x[14] ^ x[15]),
           (h[11] == x[0] ^ x[2] ^ x[4] ^ x[6] ^ x[13]),
           (h[12] == x[0] ^ x[3] ^ x[6] ^ x[7] ^ x[10] ^ x[12] ^ x[15]),
           (h[13] == x[2] ^ x[3] ^ x[4] ^ x[5] ^ x[6] ^ x[7] ^ x[11] ^ x[12] ^ x[13] ^ x[14]),
           (h[14] == x[1] ^ x[2] ^ x[3] ^ x[5] ^ x[7] ^ x[11] ^ x[13] ^ x[14] ^ x[15]),
           (h[15] == x[1] ^ x[3] ^ x[5] ^ x[9] ^ x[10] ^ x[11] ^ x[13] ^ x[15]),
           )

s = Solver()
s.add(formula)
str = "";
s.check()
str = chr(s.model()[x[0]].as_long());
str += chr(s.model()[x[1]].as_long());
str += chr(s.model()[x[2]].as_long());
str += chr(s.model()[x[3]].as_long());
str += chr(s.model()[x[4]].as_long());
str += chr(s.model()[x[5]].as_long());
str += chr(s.model()[x[6]].as_long());
str += chr(s.model()[x[7]].as_long());
str += chr(s.model()[x[8]].as_long());
str += chr(s.model()[x[9]].as_long());
str += chr(s.model()[x[10]].as_long());
str += chr(s.model()[x[11]].as_long());
str += chr(s.model()[x[12]].as_long());
str += chr(s.model()[x[13]].as_long());
str += chr(s.model()[x[14]].as_long());
str += chr(s.model()[x[15]].as_long());

print(str)
