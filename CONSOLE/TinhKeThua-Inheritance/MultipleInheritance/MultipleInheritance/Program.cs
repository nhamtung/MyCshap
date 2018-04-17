using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultipleInheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Tinh da ke thua trong C#!\n");

            Rectangle rec = new Rectangle();
            int area;
            rec.SetWidth(5);
            rec.SetHeight(7);
            area = rec.CaculateArea();

            Console.WriteLine("Tong dien tich = {0}", rec.CaculateArea());
            Console.WriteLine("Tong chi phi son = {0}", rec.CaculatePrice(area));

            Console.ReadKey();
        }
    }
}
