using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operator
{
    class Ex1
    {
        static void Main(string[] args)
        {
            int Num1 = -1;
            int Num2 = 4;
            int Num3 = 6;
            int Result;

            Result = Num1 + Num2 * Num3;

            Console.WriteLine("Result = {0}", Result);
            Console.ReadLine();
        }
    }
}
