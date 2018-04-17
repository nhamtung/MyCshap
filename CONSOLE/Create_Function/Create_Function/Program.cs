using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Create_Function
{
    class Program
    {
        public static void function1()
        {
            Console.WriteLine("Call Function 1");
        }
        public void function2()
        {
            Console.WriteLine("Call Function 2");
        }
        public static void Function_Parameter(string x)
        {
            Console.WriteLine("Hello " + x);
        }
        public static void tang(int x)   // tham trị, không thể thay đổi giá trị x
        {
            x++;
        }
        public static void tang2(ref int x)  // tham chiếu, có thể thay đổi giá trị x
        {
            x++;
        }

        public static decimal Factorial(int num)
        {
            if (num == 0)
                return 1;
            else
            {
                return num * Factorial(num - 1);
            }
        }

        static void Main(string[] args)
        {
            Program f2 = new Program();

            function1();
            f2.function2();

            // parameter
            Function_Parameter("Tung");

            //tham trị và tham chiếu
            int a = 0;
            tang(a);
            Console.WriteLine("a = " + a.ToString());
            tang2(ref a);
            Console.WriteLine("a = " + a.ToString());

            ////////////////////
            int num;
            Console.Write("Enter the number: ");
            num = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("Factorial is "+ Factorial(num));

            Console.ReadKey();
        }
    }
}
