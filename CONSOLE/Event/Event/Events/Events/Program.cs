using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
    class EventTest
    {
        private int value;
        public delegate void NumManipulationHandler();
        public event NumManipulationHandler ChangeNum;
        protected virtual void OnNumChanged()
        {
            if (ChangeNum == null)
            {
                ChangeNum();
            }
            else
            {
                Console.WriteLine("Kich hoat su kien!");
            }
        }

        public EventTest(int n)
        {
            SetValue(n);
        }

        public void SetValue(int n)
        {
            if (value != n)
            {
                value = n;
                OnNumChanged();
            }
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Vi du minh hoa Su kien (Event) trong C#");
            Console.WriteLine("----------------------------------");

            //tao doi tuong EventTest
            EventTest e = new EventTest(5);
            e.SetValue(7);
            e.SetValue(11);

            Console.ReadKey();
        }
    }
}
