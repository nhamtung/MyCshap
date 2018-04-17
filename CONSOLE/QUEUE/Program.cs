using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUEUE
{
    class Program
    {
        private static Queue<char> q;

        private static void Main(string[] args)
        {
            q = new Queue<char>();
            q.Enqueue('A');
            q.Enqueue('M');
            q.Enqueue('G');
            q.Enqueue('W');

            Console.WriteLine("Current queue: ");
            foreach (char c in q) Console.Write(c + " ");

            Console.WriteLine();
            q.Enqueue('V');
            q.Enqueue('H');
            Console.WriteLine("Current queue: ");
            foreach (char c in q) Console.Write(c + " ");

            Console.WriteLine();
            Console.WriteLine("Removing some values ");
            char ch = (char) q.Dequeue();
            Console.WriteLine("The removed value: {0}", ch);
            ch = (char) q.Dequeue();
            Console.WriteLine("The removed value: {0}", ch);

            Console.ReadKey();

        }
    }
    }
