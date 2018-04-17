using System;
using SKYPE4COMLib;

namespace ConsoleToSkype
{
    class Program
    {
        static void Main(string[] args)
        {
            Skype skype = new Skype();
            if (!skype.Client.IsRunning)
            {
                skype.Client.Start(true, true);  // start minimized with no splash screen
            }
            
            skype.Attach(6, true);  // wait for the client to be connected and ready
            
            Console.WriteLine("Missed message count: {0}", skype.MissedMessages.Count);  // access skype objects
            
            Console.WriteLine("Enter a skype name to search for: ");
            string username = Console.ReadLine();
            foreach (User user in skype.SearchForUsers(username))
            {
                Console.WriteLine(user.FullName);
            }

            Console.WriteLine(Convert.ToString(skype.CurrentUserStatus));

            Console.WriteLine("Hello");
            //username = Console.ReadLine();
            skype.SendMessage(username, "Hello");

            Console.ReadKey();
        }
    }
}
