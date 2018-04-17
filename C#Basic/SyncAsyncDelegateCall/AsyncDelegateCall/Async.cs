using System;

namespace AsyncDelegateCall
{
    class Async
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Async Delegate!\n");

            long start = DateTime.Now.Ticks;                                                //initialize host:
            PartyHostAsync host = new PartyHostAsync("TungHot");                            //find a restaurant phone number in phone book, it is your delegate
            OrderHandle restaurantPhone = host.GetRestaurantPhoneNumber();                  //call the restaurant to order food and get a token from them 

            IAsyncResult asyncResult = restaurantPhone.BeginInvoke("sushi", null, null);    //identifying your order. they immediately start preparing food

            host.CleanUpPlace();    //clean up
            host.SetupFurniture();   //set furniture
            
            string getFood;
            getFood = restaurantPhone.EndInvoke(asyncResult);                               //call the restaurant, provide the token, get the food
            Console.WriteLine(getFood + " at " + DateTime.Now.ToLongTimeString() + "\n");   //take care of yourself:

            host.TakeBathAndDressUp();

            long end = DateTime.Now.Ticks;   //mark the end:
            Console.WriteLine("Total time {0} seconds", (end - start) / 10000000);          //register total time
            Console.Read();
        }
    }
}
