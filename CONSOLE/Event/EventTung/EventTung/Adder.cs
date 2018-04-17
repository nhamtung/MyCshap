using System;
using System.Threading;

namespace EventTung
{
    class Adder
    {
        public event EventHandler<EventArgs> OnMultipleOfFiveReached;

        public void Call()
        {
            for(int i=0; i< 10; i++)
            {
                OnMultipleOfFiveReached(null, null);
                Thread.Sleep(1000);
            }
        }
    }
}
