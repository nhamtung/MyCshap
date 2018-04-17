using System;
using System.IO;

namespace StreamReaders
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Vi du minh hoa doc va ghi File trong C#");
            Console.WriteLine("---------------------------------");

            //string[] names = { "Nham Van Tung", "Phan Thi Nhan" };
            //using (StreamWriter sw = new StreamWriter("textfile.txt"))
            //{
            //    foreach (string s in names)
            //    {
            //        sw.WriteLine(s);
            //    }
            //}
            
            var line = "";
            using (StreamReader sr = new StreamReader("textfile.txt"))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    switch (line)
                    {
                        case "Nham Van Tung":
                            Console.WriteLine(line);
                            break;
                        case "Phan Thi Nhan":
                            Console.WriteLine(line);
                            break;
                        case "I Love You":
                            Console.WriteLine(line);
                            break;
                    }
                }
            }
            Console.ReadKey();
        }
    }
}