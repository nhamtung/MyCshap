using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Password
{
    class Program
    {
        static void Main(string[] args)
        {
            String User,Str1;
            String Password, Str2;
            int Num = 0;

            Console.Write("Sign in the User: ");
            User = Convert.ToString(Console.ReadLine());
            Console.Write("Sign in the Password: ");
            Password = Convert.ToString(Console.ReadLine());

            for(int i=0; i<3; i++)
            {
                Console.Write("Please enter the User: ");
                Str1 = Convert.ToString(Console.ReadLine());
                Console.Write("Please enter the Password: ");
                Str2 = Convert.ToString(Console.ReadLine());

                if ((Str1 == User) && (Str2 == Password))
                {
                    Console.WriteLine("Sign in was success!");
                    Num = 1;
                    break;
                }
                else Console.WriteLine("User or Password was wrong!");
            }
            if(Num == 0)
            {
                Console.WriteLine("Your access was denied!");
            }
            Console.ReadKey();
        }
    }
}
