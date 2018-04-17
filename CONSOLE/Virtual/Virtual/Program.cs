using System;

namespace Virtual
{
    class Program
    {
        static void Main(string[] args)
        {
            BaseClass obj = new DerivedClass();
            obj.Name = "Tung";
            obj.Number = 10;

            Console.WriteLine("Name = {0}", obj.Name);
            Console.WriteLine("Number = {0}", obj.Number);

            Console.ReadKey();
        }
    }
}
