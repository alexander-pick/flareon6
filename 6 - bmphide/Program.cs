using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace NETLoader
{
    class Program
    {

        static Type t;
        static Type tA;

        public static byte[] decode(Bitmap bm, Type t)
        {
            byte[] data = new byte[2076907];
            //6 mb for now as fixed buffer :) - for real 6291456

            //2076907

            MethodInfo m = t.GetMethod("j");

            // m3.Invoke(null, new object[] { num++ });
            int num = (int)m.Invoke(null, new object[] { (byte)103 });
            for (int i = (int)m.Invoke(null, new object[] { (byte)103 }); i < bm.Width; i++)
            {
                for (int j = (int)m.Invoke(null, new object[] { (byte)103 }); j < bm.Height; j++)
                {
                    bool flag = num > (bm.Width * bm.Height) - (int)m.Invoke(null, new object[] { (byte)231 });
                    if (flag)
                    {
                        break;
                    }

                    Color pixel = bm.GetPixel(i, j);

                    string binaryNumberString = "";

                    //Console.WriteLine((int)m.Invoke(null, new object[] { (byte)228 })+"|"+ (int)m.Invoke(null, new object[] { (byte)223 }));

                    int red = (int)pixel.R;
                    red = red & (int)m.Invoke(null, new object[] { (byte)228 }); //7
                    binaryNumberString += Convert.ToString(red, 2) + "|";

                    int green = (int)pixel.G;
                    green = green & (int)m.Invoke(null, new object[] { (byte)228 }); // 7
                    binaryNumberString += Convert.ToString(green, 2) + "|";

                    int blue = (int)pixel.B;
                    blue = blue & (int)m.Invoke(null, new object[] { (byte)230 }); //3
                    binaryNumberString += Convert.ToString(blue, 2) + "\n";

                    //Console.Write(binaryNumberString);
                    //Console.ReadLine();

                    int result = (red | (green << (int)m.Invoke(null, new object[] { (byte)230 })) | (blue << (int)m.Invoke(null, new object[] { (byte)100 })));

                    //Console.WriteLine(Convert.ToString(result, 2));
                    //Console.ReadLine();

                    data[num] = (byte)result;

                    num += 1;
                }
            }

            return data;
        }

        public static byte ori_a(byte b, int r)
        {
            return (byte)(((int)b + r ^ r) & 255);
        }

        public static byte ori_f(int idx)
        {
            int index = 0;
            int num2 = 0;
            byte num3 = 0;
            int num4 = 0;
            int[] numArray = new int[] {
                0x79, 0xff, 0xd6, 60, 0x6a, 0xd8, 0x95, 0x59, 0x60, 0x1d, 0x51, 0x7b, 0xb6, 0x18, 0xa7, 0xfc,
                0x58, 0xd4, 0x2b, 0x55, 0xb5, 0x56, 0x6c, 0xd5, 50, 0x4e, 0xf7, 0x53, 0xc1, 0x23, 0x87, 0xd9,
                0, 0x40, 0x2d, 0xec, 0x86, 0x66, 0x4c, 0x4a, 0x99, 0x22, 0x27, 10, 0xc0, 0xca, 0x47, 0xb7,
                0xb9, 0xaf, 0x54, 0x76, 9, 0x9e, 0x42, 0x80, 0x74, 0x75, 4, 13, 0x2e, 0xe3, 0x84, 240,
                0x7a, 11, 0x12, 0xba, 30, 0x9d, 1, 0x9a, 0x90, 0x7c, 0x98, 0xbb, 0x20, 0x57, 0x8d, 0x67,
                0xbd, 12, 0x35, 0xde, 0xce, 0x5b, 20, 0xae, 0x31, 0xdf, 0x9b, 250, 0x5f, 0x1f, 0x62, 0x97,
                0xb3, 0x65, 0x2f, 0x11, 0xcf, 0x8e, 0xc7, 3, 0xcd, 0xa3, 0x92, 0x30, 0xa5, 0xe1, 0x3e, 0x21,
                0x77, 0x34, 0xf1, 0xe4, 0xa2, 90, 140, 0xe8, 0x81, 0x72, 0x4b, 0x52, 190, 0x41, 2, 0x15,
                14, 0x6f, 0x73, 0x24, 0x6b, 0x43, 0x7e, 80, 110, 0x17, 0x2c, 0xe2, 0x38, 7, 0xac, 0xdd,
                0xef, 0xa1, 0x3d, 0x5d, 0x5e, 0x63, 0xab, 0x61, 0x26, 40, 0x1c, 0xa6, 0xd1, 0xe5, 0x88, 130,
                0xa4, 0xc2, 0xf3, 220, 0x19, 0xa9, 0x69, 0xee, 0xf5, 0xd7, 0xc3, 0xcb, 170, 0x10, 0x6d, 0xb0,
                0x1b, 0xb8, 0x94, 0x83, 210, 0xe7, 0x7d, 0xb1, 0x1a, 0xf6, 0x7f, 0xc6, 0xfe, 6, 0x45, 0xed,
                0xc5, 0x36, 0x3b, 0x89, 0x4f, 0xb2, 0x8b, 0xeb, 0xf9, 230, 0xe9, 0xcc, 0xc4, 0x71, 120, 0xad,
                0xe0, 0x37, 0x5c, 0xd3, 0x70, 0xdb, 0xd0, 0x4d, 0xbf, 0xf2, 0x85, 0xf4, 0xa8, 0xbc, 0x8a, 0xfb,
                70, 150, 0x91, 0xf8, 180, 0xda, 0x2a, 15, 0x9f, 0x68, 0x16, 0x25, 0x48, 0x3f, 0xea, 0x93,
                200, 0xfd, 100, 0x13, 0x49, 5, 0x39, 0xc9, 0x33, 0x9c, 0x29, 0x8f, 0x44, 8, 160, 0x3a
            };
            for (int i = 0; i <= idx; i++)
            {
                index = (index + 1) % 0x100;
                num2 = (num2 + numArray[index]) % 0x100;
                num4 = numArray[index];
                numArray[index] = numArray[num2];
                numArray[num2] = num4;
                num3 = (byte)numArray[(numArray[index] + numArray[num2]) % 0x100];
            }
            return num3;
        }

        /*
        public static int yy = 2738;
        public static string ww = "1F7D1482";
        public static string zz = "MzQxOTk=";

        public static int ori_j(byte z)
        {
            byte b = 5;
            uint num = 0u;
            string value = "";
            byte[] bytes = new byte[8];
            for (; ; )
            {
                bool flag = b == 1;
                if (flag)
                {
                    num += 4u;
                    b += 2;
                }
                else
                {
                    bool flag2 = b == 2;
                    if (flag2)
                    {
                        num = (uint)((ulong)num * (ulong)((long)Program.yy));
                        b += 8;
                    }
                    else
                    {
                        bool flag3 = b == 3;
                        if (flag3)
                        {
                            MethodInfo m = t.GetMethod("f");
                            num += Convert.ToUInt32(m.Invoke(null, new object[] { 6 }));
                            //num += ori_g(6); // (uint)Program.f(6);
                            b += 1;
                        }
                        else
                        {
                            bool flag4 = b == 4;
                            if (flag4)
                            {
                                MethodInfo m = t.GetMethod("b");
                                z = (byte)m.Invoke(null, new object[] { z, 1 });
                                //z = Program.b(z, 1);
                                b += 2;
                            }
                            else
                            {
                                bool flag5 = b == 5;
                                if (flag5)
                                {
                                    num = Convert.ToUInt32(Program.ww, 16);
                                    b -= 3;
                                }
                                else
                                {
                                    bool flag6 = b == 6;
                                    if (flag6)
                                    {
                                        break;
                                    }
                                    bool flag7 = b == 7;
                                    if (flag7)
                                    {
                                        num += Convert.ToUInt32(value);
                                        b -= 6;
                                    }
                                    else
                                    {
                                        bool flag8 = b == 10;
                                        if (flag8)
                                        {
                                            bytes = Convert.FromBase64String(Program.zz);
                                            b += 4;
                                        }
                                        else
                                        {
                                            bool flag9 = b == 14;
                                            if (flag9)
                                            {
                                                value = Encoding.Default.GetString(bytes);
                                                b -= 7;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return (int)ori_e(z, (byte)num);
        }

        public static byte[] decode_2(Bitmap bm, Type t)
        {
            byte[] data = new byte[6291456]; //6 mb for now as fixed buffer :) - for real 2076907

            //2076907

            // m3.Invoke(null, new object[] { num++ });
            int num = ori_j((byte)103 );
            for (int i = ori_j((byte)103); i < bm.Width; i++)
            {
                for (int j = ori_j((byte)103); j < bm.Height; j++)
                {
                    bool flag = num > (bm.Width * bm.Height) - 1;
                    if (flag)
                    {
                        break;
                    }

                    Color pixel = bm.GetPixel(i, j);

                    string binaryNumberString = "";

                    int red = (int)pixel.R;
                    red = red & ori_j((byte)228); //7
                    binaryNumberString += Convert.ToString(red, 2) + "|";

                    int green = (int)pixel.G;
                    green = green & ori_j((byte)228); // 7
                    binaryNumberString += Convert.ToString(green, 2) + "|";

                    int blue = (int)pixel.B;
                    blue = blue & ori_j((byte)223); //3
                    binaryNumberString += Convert.ToString(blue, 2) + "\n";

                    //Console.Write(binaryNumberString);
                    //Console.ReadLine();

                    int result = (red | (green << ori_j((byte)223) | (blue << ori_j((byte)100))));

                    //Console.WriteLine(Convert.ToString(result, 2));
                    //Console.ReadLine();

                    data[num] = (byte)result;

                    num += 1;
                }
            }

            return data;
        }*/

        // with runtime patches from A.IncrementMaxStack

        // Marshal.WriteInt32((IntPtr)((void*)info->ILCode), 6, 309030853);
        // Marshal.WriteInt32((IntPtr)((void*) info->ILCode), 18, 209897853);

        public static byte ori_e(byte b, byte k)
        {
            for (int i = 0; i < 8; i++)
            {
                bool flag = (b >> i & 1) == (k >> i & 1);
                if (flag)
                {
                    b = (byte)((int)b & ~(1 << i) & 255);
                }
                else
                {
                    b = (byte)((int)b | (1 << i & 255));
                }
            }
            return b;
        }

        public static byte ori_g(int idx)
        {
            byte b = (byte)((long)(idx + 1) * (long)(309030853)); //-306674912
            byte k = (byte)((idx + 2) * 209897853);  //1669101435

            MethodInfo e = t.GetMethod("e");

            return ori_e(b,k);

           // return (byte)e.Invoke(null, new object[] { b, k });
        }

        public static int salt_a = 0xFF;
        public static int salt_b = 0xFF;
        public static int salt_c = 0xFF;
        public static int salt_d = 0xFF;
        public static byte salt_e = 0xFF;

        public static byte[,] a = new byte[byte.MaxValue, 2];
        public static byte[,] b = new byte[byte.MaxValue, 2];
        public static byte[,] c = new byte[byte.MaxValue, 2];
        public static byte[,] d = new byte[byte.MaxValue, 2];
        public static byte[,] e = new byte[byte.MaxValue, 2];
        public static byte[,] f = new byte[byte.MaxValue, 2];
        public static byte[,] g = new byte[byte.MaxValue, 2];

        public static byte[,] reverseaction(MethodInfo m, int param2, byte param3)
        {
            //Console.WriteLine("calculating table for " + m.Name + "(" + param2 + "/" + param3 + ")");

            byte[,] results = new byte[256, 2];

            for (int i = 0; i < 256; i++)
            {
                object[] paramo = null;

                if (m.Name == "e")
                {
                    paramo = new object[] { (byte)i, param3 };
                }
                else if (m.Name == "f" | m.Name == "g")
                {
                    paramo = new object[] { (byte)i };
                }
                else
                {
                    paramo = new object[] { (byte)i, param2 };
                }

                byte r = (byte)m.Invoke(null, paramo);
                results[i, 0] = r;
                results[i, 1] = (byte)i;
            }

            return results;

        }

        //param3 for byte byte
        public static byte reversefunction(string name, byte param1, int param2, byte param3 = 0)
        {
            byte result = 0x00;

            MethodInfo m = t.GetMethod(name);

            byte[,] results = new byte[255, 2];

            // iterate across all and build result table
            switch (name)
            {
                case "a":
                    if (a[12, 1] == 0 | param2 != salt_a)
                    {
                        results = reverseaction(m, param2, param3);
                        a = results;
                        salt_a = param2;
                    }
                    else
                    {
                        results = a;
                    }

                    break;
                case "b":
                    if (b[12, 1] == 0 | param2 != salt_b)
                    {
                        results = reverseaction(m, param2, param3);
                        b = results;
                        salt_b = param2;
                    }
                    else
                    {
                        results = b;
                    }
                    break;
                case "c":
                    if (c[12, 1] == 0 | param2 != salt_c)
                    {
                        results = reverseaction(m, param2, param3);
                        c = results;
                        salt_c = param2;
                    }
                    else
                    {
                        results = c;
                    }
                    break;
                case "d":
                    if (d[12, 1] == 0 | param2 != salt_d)
                    {
                        results = reverseaction(m, param2, param3);
                        d = results;
                        salt_d = param2;
                    }
                    else
                    {
                        results = d;
                    }
                    break;
                case "e":
                    if (e[12, 1] == 0 | param3 != salt_e)
                    {
                        results = reverseaction(m, param2, param3);
                        e = results;
                        salt_e = param3;
                    }
                    else
                    {
                        results = e;
                    }
                    break;
                case "f":
                    if (f[12, 1] == 0)
                    {
                        results = reverseaction(m, param2, param3);
                        f = results;
                    }
                    else
                    {
                        results = f;
                    }
                    break;
                case "g":
                    if (g[12, 1] == 0)
                    {
                        results = reverseaction(m, param2, param3);
                        g = results;
                    }
                    else
                    {
                        results = g;
                    }
                    break;
            }


            // lookup value in array
            for (int i = 0; i < 0xff; i++)
            {
                //Console.WriteLine(results[i, 0]);

                if (results[i, 0] == param1)
                {
                    result = results[i, 1];
                    break;
                }
            }
            //Console.ReadLine();
            return result;
        }

        public static byte[] decrypt(byte[] data, string me)
        {
            // g is the opposite of f ;-)
            MethodInfo f = t.GetMethod(me);

            int fl = data.Length;
            // for testing!
            // fl = 100;

            byte[] array = new byte[fl];
            int num = 0;

            for (int i = 0; i < fl; i++) //data.Length
            {

                byte databyte = data[i];

                //num3 = (int)Program.c((byte)num3, 3);
                databyte = reversefunction("c", databyte, 3); //c

                int num4;

                if (me == "ori_g")
                {
                    num4 = ori_g(num + 1);
                }
                else
                {
                    num4 = Convert.ToInt32(f.Invoke(null, new object[] { (num + 1) }));
                }

                //databyte = (int)Program.e((byte)databyte, (byte)num4);
                databyte = reversefunction("e", databyte, 0, (byte)num4);

                //databyte = (int)Program.b((byte)databyte, 7);
                databyte = reversefunction("b", databyte, 7);  //7

                int num2;

                if (me == "ori_g")
                {
                    num2 = ori_g(num);
                }
                else
                {
                    num2 = Convert.ToInt32(f.Invoke(null, new object[] { num }));
                }
                //databyte = (int)Program.e((byte)databyte, (byte)num2);
                //databyte = reversefunction("e", databyte, 0, (byte)num2);

                databyte = ori_e(databyte, (byte)num2);

                num = num + 2;

                if (i % 1000 == 0)
                {
                    Console.WriteLine("Offset: " + (data.Length - i));
                }
                //Console.WriteLine(data.Length-i);

                array[i] = databyte;
            }

            return array;
        }

        // used for testing and to make sure I not messed something up this time ...
        // can confirm 100% this does the same as h, my mistake must be withing decrypt...
        public static byte[] encrypt(byte[] data)
        {
            // a is now also b
            // c is now also d
            // g differs - why?
            MethodInfo f = t.GetMethod("g");
            MethodInfo e = t.GetMethod("e");
            MethodInfo a = t.GetMethod("a");
            MethodInfo c = t.GetMethod("c");

            byte[] array = new byte[data.Length];
            int num = 0;
            for (int i = 0; i < data.Length; i++)
            {
                int num2 = Convert.ToInt32(f.Invoke(null, new object[] { num++ }));
                int num3 = (int)data[i];
                num3 = Convert.ToInt32(e.Invoke(null, new object[] { (byte)num3, (byte)num2 }));
                num3 = Convert.ToInt32(a.Invoke(null, new object[] { (byte)num3, 7 }));
                int num4 = Convert.ToInt32(f.Invoke(null, new object[] { num++ }));
                num3 = Convert.ToInt32(e.Invoke(null, new object[] { (byte)num3, (byte)num4 }));
                num3 = Convert.ToInt32(c.Invoke(null, new object[] { (byte)num3, 3 }));
                array[i] = (byte)num3;
            }
            return array;
        }
        public static int ori_c(int b, int r)
        {
            int b2 = 1;
            for (int i = 0; i < 8; i++)
            {
                bool flag = (b & 1) == 1;
                if (flag)
                {
                    b2 = (b2 * 2 + 1 & byte.MaxValue);
                }
                else
                {
                    b2 = (b2 - 1 & byte.MaxValue);
                }
            }
            return b2;
        }

        static void invokeProgram()
        {
  #if false
            /************************* Test decrypt ****************************/
            
            MethodInfo m = t.GetMethod("h");
            
            byte[] data = File.ReadAllBytes(".\\testfile.hex");

            //public static byte[] h(byte[] data)
            byte[] res = (byte[])m.Invoke(null, new object[] { data });
            //File.WriteAllBytes(".\\encrypt_test.hex", res);

            data = File.ReadAllBytes(".\\testfile.hex");

            byte[] res3 = encrypt(data);
            //File.WriteAllBytes(".\\encrypt_test_local.hex", res3);

            //why does this not work correctly?
            if (!res.SequenceEqual(res3))
            {
                Console.WriteLine("Encrypt mismatch!");
            }


            Console.WriteLine("decrypt test");

            byte[] data_decrypt = decrypt(res, "ori_g");
            //File.WriteAllBytes(".\\test_decrypt.hex", data_decrypt);
            
            Console.WriteLine("Reflection: "+System.Text.Encoding.Default.GetString(data_decrypt));


            data_decrypt = decrypt(res3, "ori_g");
            //File.WriteAllBytes(".\\test_decrypt_local.hex", data_decrypt);

            Console.WriteLine("Local: " + System.Text.Encoding.Default.GetString(data_decrypt));

            /************************* Test decode ****************************/

            m = t.GetMethod("i");

            Bitmap tbitmap = new Bitmap(".\\clean.bmp");
            data = File.ReadAllBytes(".\\testfile.hex");

            //public static byte[] h(byte[] data)
            m.Invoke(null, new object[] { tbitmap, data });

            byte[] test_decode = decode(tbitmap, t);

            Array.Resize(ref test_decode, 572);

            if (!data.SequenceEqual(test_decode))
            {
                Console.WriteLine("Encode mismatch!");
            }

            Console.WriteLine("decode test");
            Console.WriteLine(System.Text.Encoding.Default.GetString(test_decode));
            File.WriteAllBytes(".\\test_decode.hex", test_decode);

            /************************* Test functions ****************************/

            m = t.GetMethod("a");

            for (int i = 0; i < 255; i++)
            {
                //Console.WriteLine("a: "+ i + " " + (byte)m.Invoke(null, new object[] { (byte)i, 3 }));
                byte res1 = (byte)m.Invoke(null, new object[] { (byte)i, 3 });
                byte res2 = reversefunction("a", res1, 3);
                if (i != res2)
                {
                    Console.WriteLine("a mismatch: " + i + " " + res2);
                }
            }

            m = t.GetMethod("b");
            for (int i = 0; i < 255; i++)
            {
                //Console.WriteLine(i + " " + (byte)m.Invoke(null, new object[] { (byte)i, 3 }));
                byte res1 = (byte)m.Invoke(null, new object[] { (byte)i, 3 });
                byte res2 = reversefunction("b", res1, 3);
                if (i != res2)
                {
                    Console.WriteLine("b mismatch: " + i + " " + res2);
                }
            }


            m = t.GetMethod("c");
            for (int i = 0; i < 255; i++)
            {
                //Console.WriteLine("c: "+ i + " " + (byte)m.Invoke(null, new object[] { (byte)i, 3 }));
                byte res1 = (byte)m.Invoke(null, new object[] { (byte)i, 3 });
                byte res2 = reversefunction("c", res1, 3);
                if (i != res2)
                {
                    Console.WriteLine("b mismatch: " + i + " " + res2);
                }
            }

            m = t.GetMethod("d");
            for (int i = 0; i < 255; i++)
            {
                //Console.WriteLine(i + " " + (byte)m.Invoke(null, new object[] { (byte)i, 3 }));
                byte res1 = (byte)m.Invoke(null, new object[] { (byte)i, 3 });
                byte res2 = reversefunction("d", res1, 3);
                if (i != res2)
                {
                    Console.WriteLine("d mismatch: " + i + " " + res2);
                }
            }

            m = t.GetMethod("e");
            for (int i = 0; i < 255; i++)
            {
                //Console.WriteLine("e: " + i + " " + (byte)m.Invoke(null, new object[] { (byte)i, (byte)3 }));
                byte res1 = (byte)m.Invoke(null, new object[] { (byte)i, (byte)3 });
                byte res2 = reversefunction("e", res1, 0, (byte)3);
                if (i != res2)
                {
                    Console.WriteLine("e mismatch: " + i + " " + res2);
                }
                //Console.WriteLine("i:"+i+" e:"+res1);
            }

            for (int i = 0; i < 255; i++)
            {
                //Console.WriteLine(i + " " + (byte)m.Invoke(null, new object[] { (byte)i, (byte)3 }));
                int res1 = Convert.ToInt32(m.Invoke(null, new object[] { (byte)i, (byte)3 }));
                int res2 = ori_e((byte)i, (byte)3);
                if (res1 != res2)
                {
                    Console.WriteLine("e/ori_e mismatch: " + i + " " + res1 + " " + res2);
                }
            }

            //seems not manipulated
            m = t.GetMethod("f");
            for (int i = 0; i < 255; i++)
            {
                //Console.WriteLine(i + " " + (byte)m.Invoke(null, new object[] { (byte)i, (byte)3 }));
                int res1 = Convert.ToInt32(m.Invoke(null, new object[] { i }));
                int res2 = ori_f(i);
                if (res1 != res2)
                {
                    Console.WriteLine("f/ori_f mismatch: " + i + " " + res1 + " " + res2);
                }
            }

            //seems not manipulated
            m = t.GetMethod("g");
            for (int i = 0; i < 255; i++)
            {
                //Console.WriteLine(i + " " + (byte)m.Invoke(null, new object[] { (byte)i, (byte)3 }));
                int res1 = Convert.ToInt32(m.Invoke(null, new object[] { i }));
                int res2 = ori_g(i);
                if (res1 != res2)
                {
                    Console.WriteLine("g/ori_g mismatch: " + i + " " + res1 + " " + res2);
                }
            }
#endif
            Console.WriteLine("Doing the real deal...");

            Bitmap bitmap = new Bitmap(".\\flag2-1.bmp"); //test_result.bmp

            Console.WriteLine("decoding real file ...");

            byte[] real_data = decode(bitmap, t);
            //File.WriteAllBytes(".\\final.hex", real_data);

           //byte[] real_data = File.ReadAllBytes(".\\0909_decoded.hex");

            Console.WriteLine("decrypting real file ...");

            byte[] real_data_decrypt = decrypt(real_data, "ori_g");
            File.WriteAllBytes(".\\final.bmp", real_data_decrypt);

            //Console.WriteLine(System.Text.Encoding.Default.GetString(real_data_decrypt));

            Console.WriteLine("- Done --------------------------------");

        }

        static void Main(string[] args)
        {

            //this is correctly renamed bmphide
            Assembly a = Assembly.Load("ConsoleApp1"); //ConsoleApp1

            object[] parameters = new object[] { new string[] { "clean.bmp", "crap.bmp", "test_result.bmp" } };

            a.EntryPoint.Invoke(null, parameters);

            Type[] at = a.GetTypes();
            foreach (Type gt in at)
            {
                //Console.WriteLine("TYPE: " + gt.Name);

                MethodInfo[] methods2 = gt.GetMethods();

                foreach (MethodInfo methodInfo in methods2)
                {
                    //Console.WriteLine(methodInfo.Name);
                }

                if (gt.Name == "Program")
                {
                    //set global type ;
                    t = gt;
                    //Console.WriteLine("Found Program");
                    MethodInfo[] methods = t.GetMethods();
                    foreach (MethodInfo methodInfo in methods)
                    {
                    //    Console.WriteLine("Program: " + methodInfo.Name);

                    }
                }

                if (gt.Name == "A")
                {
                    //set global type ;
                    tA = gt;
                    //Console.WriteLine("Found A");
                    MethodInfo[] methods = tA.GetMethods();
                    foreach (MethodInfo methodInfo in methods)
                    {
                      //  Console.WriteLine("A: " + methodInfo.Name);
                    }

                }

                    //Console.WriteLine("======================================================================");
                }

                invokeProgram();

            Console.ReadKey();
        }
    }
}
