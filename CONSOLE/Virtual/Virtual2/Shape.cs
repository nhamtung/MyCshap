using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualAreaShape
{
    class Shape
    {
        public const double PI = Math.PI;
        protected double x, y;

        public Shape()
        { }

        public Shape(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public virtual double Area()
        {
            return x * y;
        }
    }
}
