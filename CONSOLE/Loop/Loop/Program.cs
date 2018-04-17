using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loop
{
    class Program
    {
        static void Main(string[] args)
        {
            for(int i=0; i<10; i++)
            {
                for(int j=0; j<5; j++)
                {
                    if ((j == 0) || ((j == 1) && ((i == 0) || (i == 5) || (i == 6))) || ((j == 2) && ((i == 0) || (i == 5) || (i == 7))) || ((j == 3) && ((i == 1) || (i == 4) || (i == 8))) || ((j == 4) && ((i == 2) || (i == 3) || (i == 9))))
                    {
                        Console.Write(" *");
                    }
                    else Console.Write("  ");
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
