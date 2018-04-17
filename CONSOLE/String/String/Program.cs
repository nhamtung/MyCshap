using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace String
{
    class Program
    {
        static void Main(string[] args)
        {
            string Str1;
            string Str2;
            int num=0;
            int alpha=0, digit=0, symbol=0;

            Console.WriteLine("enter the string 1: ");
            Str1 = Console.ReadLine();
            Console.WriteLine("enter the string 2: ");
            Str2 = Console.ReadLine();

            foreach (char chr in Str1)
            {
                num++;
                Console.Write("{0} ", chr);
            }
            Console.WriteLine("\nLength of String is: {0}", num);

            for(int i=Str1.Length-1; i>=0; i--)
            {
                Console.Write("{0} ", Str1[i]);
                if ((Str1[i] >= 'A') && (Str1[i] <= 'Z') || (Str1[i] >= 'a') && (Str1[i] <= 'z'))
                    alpha++;
                else if((Str1[i] >= '0')&&(Str1[i]<='9'))
                    digit++;
                else symbol++;
            }
            Console.WriteLine("\nIt has {0} alphabet, {1} digit, {2} Symbol", alpha, digit, symbol);

            if (Str1 == Str2)
            {
                Console.WriteLine("\nThis is same!");
            }
            else Console.WriteLine("\nThis is not same!");


            Console.ReadKey();
        }
    }
}
