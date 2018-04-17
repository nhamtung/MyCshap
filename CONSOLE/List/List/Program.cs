using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> colors = new List<string>();

            //add items in a List collection
            colors.Add("Red");
            colors.Add("Blue");
            colors.Add("Green");

            //insert an item in the list
            //colors.Insert(1, "violet");

            //retrieve items using foreach loop
            //foreach (string color in colors)
            //{
            //    Console.WriteLine("Color: {0}", colors);
            //}

            //remove an item from list
            //colors.Remove("violet");

            //retrieve items using for loop
            for (int i = 0; i < colors.Count; i++)
            {
                Console.WriteLine("Color[{0}] = {1}", i, colors[i]);
            }

            //if (colors.Contains("Blue"))
            //{
            //    Console.WriteLine("Blue color exist in the list");
            //}
            //else
            //{
            //    Console.WriteLine("Not exist");
            //}

            //copy array to list
            //string[] strArr = new string[3];
            //strArr[0] = "Red";
            //strArr[1] = "Blue";
            //strArr[2] = "Green";
            //List<string> arrlist = new List<string>(strArr);

            //foreach (string str in strArr)
            //{
            //    Console.WriteLine(str);
            //}

            ////call clear method
            //arrlist.Clear();

            //Console.WriteLine(arrlist.Count.ToString());

            Console.ReadKey();
        }
    }
}
