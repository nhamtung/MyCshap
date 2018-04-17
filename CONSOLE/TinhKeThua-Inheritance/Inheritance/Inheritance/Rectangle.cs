using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    class Rectangle
    {
        //Cac bien thanh vien
        protected double length;
        protected double width;

        //constructor
        public Rectangle(double l, double w)
        {
            length = l;
            width = w;
        }

        public double CaculateArea()
        {
            return length * width;
        }

        public void Display()
        {
            Console.WriteLine("Length: {0}", length);
            Console.WriteLine("Width: {0}", width);
            Console.WriteLine("Area = {0}", CaculateArea());
        }
    }
}
