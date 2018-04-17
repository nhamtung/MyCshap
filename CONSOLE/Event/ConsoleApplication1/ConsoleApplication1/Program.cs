using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    struct so
    {
        public int value;
    }
    class Program
    {
        static void Main(string[] args)
        {
            so s = new so() { value = 7 };
            Console.WriteLine("v = " + s.value.ToString());
            tang(ref s);
            Console.WriteLine("v = " + s.value.ToString());
            Console.ReadKey();
        }

        static void tang(ref so value)
        {
            value.value += 5;
            Console.WriteLine("value = " + value.value.ToString());
        }
    }
}
