using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File_Handling
{
    class Program
    {
        public static void Handling1()
        {
            string FileName = @"MyTest.txt";

            try
            {
                Console.Write("\n\n Create a file named mytest.txt in the disk :\n");
                Console.WriteLine("------------------------------------------------\n");

                using (FileStream FileStr = File.Create(FileName))
                {
                    Console.WriteLine("A file creat with name MyTest.txt!\n");
                }
            }
            catch(Exception MyExcep)
            {
                Console.WriteLine(MyExcep.ToString());
            }
        }

        public static void Handling2()
        {
            string FileName = @"MyTest.txt";

            Console.Write("\n\n Remove a file from the disk (at first create the file ) :\n");
            Console.Write("--------------------------------------------------------------\n");

            if (File.Exists(FileName))
            {
                File.Delete(FileName);
                Console.WriteLine("\nThe file {0} deleted successfully! \n", FileName);
            }
            else
            {
                Console.WriteLine("File does not exist!");
            }
        }

        public static void Handling3()
        {
            string FileName = @"MyTest.txt";

            try
            {
                if(File.Exists(FileName))
                {
                    File.Delete(FileName);
                }

                Console.Write("\n\n Create a file with content in the disk :\n");
                Console.Write("---------------------------------------------\n");
                using (StreamWriter FileStr = File.CreateText(FileName))
                {
                    FileStr.WriteLine("Hello and welcom!");
                    FileStr.WriteLine("it's first content!");
                    FileStr.WriteLine("I'm Nham Van Tung");

                    Console.WriteLine(" A file created with content name mytest.txt\n\n");
                }

                Console.Write("\n\nRead the file  :\n");
                Console.Write("-------------------------------------------------\n");
                using (StreamReader sr = File.OpenText(FileName))
                {
                    string s = "";
                    Console.WriteLine("Here is content of the file MyTest.txt!");
                    while((s = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(s);
                    }
                    Console.WriteLine("");
                }
            }
            catch(Exception MyExcep)
            {
                Console.WriteLine(MyExcep.ToString());
            }
        }

        public static void Handling4()
        {
            string FileName = @"MyTest.txt";
            string[] ArrLines;
            string str;
            int n, i;

            Console.Write("\n\n Create a file and write an array of strings  :\n");
            Console.Write("---------------------------------------------------\n");

            if(File.Exists(FileName))
                File.Delete(FileName);

            Console.Write(" Input the string to ignore the line : ");
            str = Console.ReadLine();

            Console.Write(" Input number of lines to write in the file: ");
            n = Convert.ToInt32(Console.ReadLine());
            ArrLines = new string[n];

            Console.WriteLine(" Input {0} strings below :\n", n);
            for(i=0; i<n; i++)
            {
                Console.Write("Input line {0}: ", i + 1);
                ArrLines[i] = Console.ReadLine();
            }
            //System.IO.File.WriteAllLines(FileName, ArrLines);

            using (System.IO.StreamWriter file =
                    new System.IO.StreamWriter(@"mytest.txt"))
            {
                foreach (string line in ArrLines)
                {
                    if (!line.Contains(str)) // write the line to the file If it doesn't contain the string in str
                    {
                        file.WriteLine(line);
                    }
                }
            }

            using (StreamReader sr = File.OpenText(FileName))
            {
                string s = "";

                Console.Write("\n The content of the file is  :\n", n);
                Console.Write("----------------------------------\n");

                while((s = sr.ReadLine()) != null)
                {
                    Console.WriteLine(" {0}", s);
                }
                Console.WriteLine();
            }
        }

        public static void Handling5()
        {
            string FileName = @"MyTest.txt";

            try
            {
                if (File.Exists(FileName))
                    File.Delete(FileName);

                Console.Write("\n\n Append some text to an existing file  :\n");
                Console.Write("--------------------------------------------\n");
                using (StreamWriter FileStr = File.CreateText(FileName))
                {
                    FileStr.WriteLine("Hello and welcom!");
                    FileStr.WriteLine("it's first content!");
                    FileStr.WriteLine("I'm Nham Van Tung");

                }

                using (StreamReader sr = File.OpenText(FileName))
                {
                    string s = "";
                    Console.WriteLine("Here is the content of the file mytest.txt : ");
                    while ((s = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(s);
                    }
                    Console.WriteLine("");
                }

                //////////////////////////
                using (System.IO.StreamWriter File = new System.IO.StreamWriter(@"MyTest.txt", true))
                    File.WriteLine("This is the line appended at last line!");
                
                using (StreamReader sr = File.OpenText(FileName))
                {
                    string s = "";
                    Console.WriteLine("Here is the content of the file after appending the text: ");
                    while ((s = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(s);
                    }
                    Console.WriteLine("");
                }
            }
            catch (Exception MyExcep)
            {
                Console.WriteLine(MyExcep.ToString());
            }
        }

        public static void Handling6()
        {
            string sfileName = @"mytest.txt";
            string tfileName = @"mynewtest.txt";

            if (File.Exists(sfileName))
                File.Delete(sfileName);

            Console.Write("\n\n Create a file and copy the file  :\n");
            Console.Write("---------------------------------------\n");

            // Create the file.
            using (StreamWriter fileStr = File.CreateText(sfileName))
            {
                fileStr.WriteLine(" Hello and Welcome");
                fileStr.WriteLine(" It is the first content");
                fileStr.WriteLine(" of the text file mytest.txt");
            }

            using (StreamReader sr = File.OpenText(sfileName))
            {
                string s = "";
                Console.WriteLine(" Here is the content of the file {0} : ", sfileName);
                while ((s = sr.ReadLine()) != null)
                {
                    Console.WriteLine(s);
                }
                Console.WriteLine("");
            }

            ////Copy the file
    /*      string sourcefolder = "path";  // you can mention the path of source folder
            string targetfolder =  "path"; // you can mention the path of target folder 
            string sourceFile = System.IO.Path.Combine(sourcefolder, sfileName); // combine the source file with path
            string targetFile = System.IO.Path.Combine(targetfolder, tfileName);   // combine the target file with path */

    /*		Create a new target folder if not exists
            if (!System.IO.Directory.Exists(targetfolder))
            {
                System.IO.Directory.CreateDirectory(targetfolder);
            }
            System.IO.File.Copy(sourceFile, destFile, true); // overwrite the target file if it already exists. */

            System.IO.File.Copy(sfileName, tfileName, true);
            Console.WriteLine(" The file {0} successfully copied to the name {1} in the same directory.", sfileName, tfileName);

            using (StreamReader sr = File.OpenText(tfileName))
            {
                string s = "";
                Console.WriteLine(" Here is the content of the file {0} : ", tfileName);
                while ((s = sr.ReadLine()) != null)
                {
                    Console.WriteLine(s);
                }
                Console.WriteLine("");
            }

            /////////Move a file
            if (File.Exists(tfileName))
                File.Delete(tfileName);

            System.IO.File.Move(sfileName, tfileName); // move a file to another name in same location:
            Console.WriteLine(" The file {0} successfully moved to the name {1} in the same directory.", sfileName, tfileName);

            using (StreamReader sr = File.OpenText(tfileName))
            {
                string s = "";
                Console.WriteLine(" Here is the content of the file {0} : ", tfileName);
                while ((s = sr.ReadLine()) != null)
                {
                    Console.WriteLine(s);
                }
                Console.WriteLine("");
            }
        }

        public static void Handling7()
        {
            string fileName = @"mytest.txt";

            try
            {
                if (File.Exists(fileName))
                    File.Delete(fileName);

                Console.Write("\n\n Read the first line from a file  :\n");
                Console.Write("---------------------------------------\n");

                // Create the file.
                using (StreamWriter fileStr = File.CreateText(fileName))
                {
                    fileStr.WriteLine(" test line 1");
                    fileStr.WriteLine(" test line 2");
                    fileStr.WriteLine(" Test line 3");
                }

                // Read the file
                using (StreamReader sr = File.OpenText(fileName))
                {
                    string s = "";
                    Console.WriteLine(" Here is the content of the file mytest.txt : ");
                    while ((s = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(s);
                    }
                    Console.WriteLine("");
                }

                Console.Write("\n The content of the first line of the file is :\n");
                if (File.Exists(fileName))
                {
                    string[] lines = File.ReadAllLines(fileName);
                    Console.Write(lines[0]);
                }
                Console.WriteLine();
            }
            catch (Exception MyExcep)
            {
                Console.WriteLine(MyExcep.ToString());
            }

        }

        public static void Handling8()
        {
            string fileName = @"mytest.txt";
            string[] ArrLines;
            int n, i, l, m = 1;

            Console.Write("\n\n Read last n number of lines from a file  :\n");
            Console.Write("-----------------------------------------------\n");

            if (File.Exists(fileName))
                if (File.Exists(fileName)) ;

            Console.Write(" Input number of lines to write in the file  :");
            n = Convert.ToInt32(Console.ReadLine());
            ArrLines = new string[n];
            Console.Write(" Input {0} strings below :\n", n);
            for (i = 0; i < n; i++)
            {
                Console.Write(" Input line {0} : ", i + 1);
                ArrLines[i] = Console.ReadLine();
            }
            System.IO.File.WriteAllLines(fileName, ArrLines);

            Console.Write("\n Input last how many numbers of lines you want to display  :");
            l = Convert.ToInt32(Console.ReadLine());
            m = l;
            if (l >= 1 && l <= n)
            {
                Console.Write("\n The content of the last {0} lines of the file {1} is : \n", l, fileName);
                if (File.Exists(fileName))
                {
                    for (i = n - l; i < n; i++)
                    {
                        string[] lines = File.ReadAllLines(fileName);
                        Console.Write(" The last no {0} line is : {1} \n", m, lines[i]);
                        m--;
                    }
                }
            }
            else
            {
                Console.WriteLine(" Please input the correct line no.");
            }

            Console.WriteLine();
        }

        public static void Handling9()
        {
            string fileName = @"mytest.txt";
            int count;

            try
            {
                if (File.Exists(fileName))
                    File.Delete(fileName);

                Console.Write("\n\n Count the number of lines in a file :\n");
                Console.Write("------------------------------------------\n");
                // Create the file.
                using (StreamWriter fileStr = File.CreateText(fileName))
                {
                    fileStr.WriteLine(" test line 1");
                    fileStr.WriteLine(" test line 2");
                    fileStr.WriteLine(" Test line 3");
                    fileStr.WriteLine(" test line 4");
                    fileStr.WriteLine(" test line 5");
                    fileStr.WriteLine(" Test line 6");
                }
                using (StreamReader sr = File.OpenText(fileName))
                {
                    string s = "";
                    count = 0;
                    Console.WriteLine(" Here is the content of the file mytest.txt : ");
                    while ((s = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(s);
                        count++;
                    }
                    Console.WriteLine("");
                }
                Console.Write(" The number of lines in  the file {0} is : {1} \n\n", fileName, count);
            }
            catch (Exception MyExcep)
            {
                Console.WriteLine(MyExcep.ToString());
            }
        }

        static void Main(string[] args)
        {
            //Handling1();     //Tao 1 file trang trong dia
            //Handling2();     //Xoa 1 file tu dia
            //Handling3();     //Tao 1 file co noi dung trong dia va doc file,
            //Handling4();     //Tao 1 file va viet 1 mang chuoi len file
            //Handling5();     //Chen 1 doan text vao file co san
            //Handling6();     //Copy, move the file and display content
            //Handling7();     //read the specific line from a file
            //Handling8();     //create and read last n number of lines of a file
            //Handling9();     //count the number of lines in a file

            Console.ReadKey();
        }
    }
}
