import idautils 
import idaapi

def memdump(ea, size, file):
    data = idc.GetManyBytes(ea, size)
    with open(file, "wb") as fp:
        fp.write(data)
        print "Memdump Success!"
        
memdump(0x400000, 0xC0000, "E:\\mem_seg.bin")