using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualAreaShape
{
    class Circle : Shape
    {
        public Circle(double r) : base(r,0)
        { }

        public override double Area()
        {
            return PI * x * x;
        }
    }
}
