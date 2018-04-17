using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractClass
{
    abstract class BaseClass
    {
        protected int x = 100;
        protected int y = 150;

        public abstract void AbstractMethod();
        public abstract int X { get; }
        public abstract int Y { get; }
    }
}
