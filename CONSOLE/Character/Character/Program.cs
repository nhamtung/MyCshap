using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Character
{
    class Program
    {
        static void Main(string[] args)
        {
            char ch;

            Console.Write("Please enter character: ");
            ch = Convert.ToChar(Console.ReadLine());

            if((ch >= '0') && (ch <= '9'))
            {
                Console.WriteLine("This is digit!");
                Console.ReadKey();
            }
        }
    }
}
