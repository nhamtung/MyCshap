using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventTung
{
    class Program
    {
        static void Main(string[] args)
        {

            Adder a = new Adder();
            a.OnMultipleOfFiveReached += a_MultipleOfFiveReached;

            a.Call();
            ////dgPointer pAdder = new dgPointer(a.Add);
            //int iAnswer = pAdder(4, 3);
            //Console.WriteLine("iAnswer = {0}", iAnswer);
            //iAnswer = pAdder(4, 6);
            //Console.WriteLine("iAnswer = {0}", iAnswer);
            Console.ReadKey();
        }
        static void a_MultipleOfFiveReached(object sender, EventArgs e)
        {
            Console.WriteLine("Multiple of five reached!");
        }
    }
}
