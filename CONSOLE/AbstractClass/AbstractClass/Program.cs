using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractClass
{
    class Program : BaseClass
    {
        public override void AbstractMethod()
        {
            x++;
            y++;
        }

        public override int X
        {
            get { return x + 10; }
        }
        public override int Y
        {
            get { return y + 10; }
        }
        static void Main(string[] args)
        {
            Program o = new Program();
            o.AbstractMethod();
            Console.WriteLine("x = {0} , y = {1}", o.X, o.Y);

            Console.ReadKey();
        }
    }
}
