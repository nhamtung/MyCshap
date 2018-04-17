using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursion  // tự gọi chính hàm của nó
{
    class Program
    {
        public static int Recursion1(int num)
        {
            if (num > 0)
            {
                Console.Write(" " + num);
                return num + Recursion1(num - 1);
            }
            else
            {
                Console.WriteLine();
                return num;
            }
        }

        public static int Recursion2(int i,int num)
        {
            if(num < 10)
            {
                Console.WriteLine(" " + num);
                return i+1;
            }
            else
            {
                i++;
                Console.Write(" " + num % 10);
                return Recursion2(i,num / 10);
            }
        }

        public static int Recursion3(int i, int num)
        {
            if(i == 1)
                return 1;
            else
            {
                if((num % i) == 0)
                    return 0;
                else 
                    return Recursion3(--i, num);
            }

        }

        static void Main(string[] args)
        {
            int num = 0;
            int i = 0;
            Console.Write("Enter the number: ");
            num = Convert.ToInt32(Console.ReadLine());

            //Console.WriteLine("The sum is: "+Recursion1(num));  // num = 20
            //Console.WriteLine("Individual digit: " + Recursion2(i,num)); // num = 12345

            int check;
            i = num/2;
            check = Recursion3(i, num);  //prime number (num = 37)
            if (check == 1)
                Console.WriteLine("This is prime number!");
            else Console.WriteLine("This is not prime number!");

            Console.ReadKey();
        }
    }
}
