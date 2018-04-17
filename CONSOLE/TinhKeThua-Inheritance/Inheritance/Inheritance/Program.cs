using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Tinh ke thua trong C#!");
            Console.WriteLine("Khoi tao lop co so!\n");

            PriceConstruction t = new PriceConstruction(4.5, 7.5);
            t.DisplayInformation();

            Console.ReadKey();
        }
    }
}
