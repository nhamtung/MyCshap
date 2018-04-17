using System;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadingTask
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var t = Task.Run(() =>
            {
                for (int i = 0; i < 5; i++)
                {
                    Thread.Sleep(1000);
                    Console.WriteLine("Task!");
                }
            });
            //t.Wait();

            Thread testThread = new Thread(TestThread);
            testThread.Start();

            for (int i=0; i< 5; i++)
            {
                Thread.Sleep(1000);
                Console.WriteLine("Main!");
            }

            Console.ReadKey();
        }

        public static void TestThread()
        {
            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(1000);
                Console.WriteLine("Thread!");
            }
        }

    }
    // The example displays the following output:
    // Application thread ID: 1
    // Task thread ID: 3
}
