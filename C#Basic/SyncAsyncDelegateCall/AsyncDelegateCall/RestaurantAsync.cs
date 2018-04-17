using System;
using System.Threading;

namespace AsyncDelegateCall
{
    class RestaurantAsync
    {
        public static string MakeFood(string order)
        {
            //register start:
            Console.WriteLine("Making {0} started at {1}", order, DateTime.Now.ToLongTimeString());   //food preparation:
            Thread.Sleep(4000);   //register finish

            Console.WriteLine("Making {0} finished at {1}", order,  DateTime.Now.ToLongTimeString());   //deliver:
            return order.ToUpper() + " made";
        }
    }
}
