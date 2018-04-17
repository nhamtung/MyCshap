using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

delegate int NumberChanger(int n);

namespace Delegate_Simple
{
    class Program
    {
        static int num = 10;
        public static int AddNum(int p)
        {
            num += p;
            return num;
        }

        public static int MultNum(int q)
        {
            num *= q;
            return num;
        }

        public static int getNum()
        {
            return num;
        }

        public static void Delegate1()
        {
            Console.WriteLine("Vi du minh hoa Delegate trong C#");
            Console.WriteLine("----------------------------------");

            //tao cac doi tuong tong delegate
            NumberChanger nc1 = new NumberChanger(AddNum);
            NumberChanger nc2 = new NumberChanger(MultNum);

            //goi cac phuong thuc su dung cac doi tuong delegate
            nc1(25);
            Console.WriteLine("Gia tri cua num la: {0}", getNum());
            nc2(5);
            Console.WriteLine("Gia tri cua num la: {0}", getNum());
        }
        public static void Delegate2()
        {
            Console.WriteLine("Vi du minh hoa Delegate trong C#");
            Console.WriteLine("----------------------------------");

            //tao cac doi tuong delegate
            NumberChanger nc;
            NumberChanger nc1 = new NumberChanger(AddNum);
            NumberChanger nc2 = new NumberChanger(MultNum);
            //  nc = nc1;
            //   nc += nc2;
            nc = nc1 + nc2;
            
            nc(5);     //goi multicast
            Console.WriteLine("Gia tri cua num la: {0}", getNum());
        }


////////////////////////////////////////////////////////////////////////////////
        static FileStream fs;
        static StreamWriter sw;

        // khai bao delegate
        public delegate void printString(string s);

        // phuong thuc de in tren console
        public static void WriteToScreen(string str)
        {
            Console.WriteLine("Chuoi la: {0}", str);
        }

        //phuong thuc nay de ghi du lieu vao file
        public static void WriteToFile(string s)
        {
            fs = new FileStream("c:\\message.txt", FileMode.Append, FileAccess.Write);
            sw = new StreamWriter(fs);
            sw.WriteLine(s);
            sw.Flush();
            sw.Close();
            fs.Close();
        }

        // phuong thuc nay nhan delegate lam tham so va su dung no de goi cac phuong thuc neu can
        public static void sendString(printString ps)
        {
            ps("Hello world!");
        }

        public static void Delegate3()
        {
            Console.WriteLine("Vi du minh hoa Delegate trong C#");
            Console.WriteLine("----------------------------------");

            printString ps1 = new printString(WriteToScreen);
            printString ps2 = new printString(WriteToFile);
            sendString(ps1);
            sendString(ps2);
        }

        static void Main(string[] args)
        {
            //Delegate1();
            //Delegate2();

            Delegate3();

            Console.ReadKey();
        }
    }
}
