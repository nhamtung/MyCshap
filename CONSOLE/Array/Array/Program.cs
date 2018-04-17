using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Array
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr1 = new int[10];
            int[] arr2 = new int[10];
            int[] arr  = new int[10];

            int[,] arr3 = new int[10, 10];  //mang 2 chieu

            Console.WriteLine("Enter the element of array 1: ");
            for(int i=0; i<5; i++)
            {
                arr1[i] = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine("Enter the element of array 2: ");
            for(int i=0; i<5; i++)
            {
                arr2[i] = Convert.ToInt32(Console.ReadLine());
            }
            Console.Write("arr1: ");
            for (int i = 0; i < arr1.Length; i++)
            {
                Console.Write("{0} ", arr1[i]);
            }
            Console.Write("\narr2: ");
            for (int i = 0; i < arr2.Length; i++)
            {
                Console.Write("{0} ", arr2[i]);
            }



            for (int j=0; j<10; j++)
            {
                if ((j%2) == 0)
                    arr[j] = arr1[(j/2)];
                else arr[j] = arr2[(j/2)];
            }

            Console.Write("\narr: ");
            for(int i=0; i<arr.Length; i++)
            {
                Console.Write("{0} ", arr[i]);
            }
            Console.ReadKey();
        }
    }
}
