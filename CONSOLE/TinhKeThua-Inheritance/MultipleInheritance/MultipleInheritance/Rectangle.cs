using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultipleInheritance
{
    class Rectangle: Shape, PricePaint
    {
        public int CaculateArea()
        {
            return (width * height);
        }
        public int CaculatePrice(int area)
        {
            return area * 70;
        }
    }
}
