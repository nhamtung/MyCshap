using System;

namespace SyncDelegateCall
{
    class Sync
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Sync Delegate!\n");

            long start = DateTime.Now.Ticks;

            PartyHostSync host = new PartyHostSync("TungHot");                               //initialize host
            OrderHandle restaurantPhone = host.GetRestaurantPhoneNumber();                   //find a restaurant phone number in phone book, it is your delegate
            
            host.CleanUpPlace();   //clean the place
            host.SetupFurniture();    //set up furniture

            string getFood = restaurantPhone.Invoke("sushi");            //call food chef into your apartment to prepare food, the chef will come and will make the food at your place
            Console.WriteLine(getFood + " at " + DateTime.Now.ToLongTimeString() + "\n");   //register when food is done

            host.TakeBathAndDressUp();   //prepare yourself

            long end = DateTime.Now.Ticks;   //mark end time
            Console.WriteLine("Total time {0} seconds", (end - start) / 10000000);          //register total time
            Console.Read();
        }
    }
}
