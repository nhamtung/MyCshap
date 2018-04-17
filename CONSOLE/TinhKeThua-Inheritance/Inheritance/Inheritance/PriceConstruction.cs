using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    class PriceConstruction : Rectangle
    {
        private double cost;
        public PriceConstruction(double l, double w) : base(l, w)
        { }

        public double CaculatePrice()
        {
            double price;
            price = CaculateArea() * 70;
            return price;
        }

        public void DisplayInformation()
        {
            base.Display();
            Console.WriteLine("Price = {0}", CaculatePrice());
        }
    }
}
