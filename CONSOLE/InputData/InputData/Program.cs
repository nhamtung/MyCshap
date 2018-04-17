using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InputData
{
    class Excercise
    {
        static void Main(string[] args)
        {

            int Num, Num1, Num2;
            char d;

            Console.Write("input the first number: ");
            Num1 = Convert.ToInt16(Console.ReadLine());
            Console.Write("Input the second number: ");
            Num2 = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("Input the letter:");
            d = Convert.ToChar(Console.ReadLine());

            Num = Num1;
            Num1 = Num2;
            Num2 = Num;

            Console.WriteLine("Num1 = {0}", Num1);
            Console.WriteLine("Num2 = {0}", Num2);
            Console.WriteLine("Letter: {0}", d);
            Console.ReadKey();
        }
    }
}