using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structure
{
    /////////////////////////////////////////////////////////////////
    struct Struct1
    {
        public int x;
        public int y;
    }

    /////////////////////////////////////////////////////////////////
    class NewClass3
    {
        public int x;
        public int y;
    }
    struct NewStruct3
    {
        public int x;
        public int y;
    }
    
    /////////////////////////////////////////////////////////////////
    class NewClass4
    {
        public int n;
    }
    struct NewStruct4
    {
        public int n;
    }

    ///////////////////////////////////////////////////////////////////
    struct NewStruct5
    {
        private int num;

        public int n
        {
            get
            {
                return num;
            }
            set
            {
                if(value < 50)
                {
                    num = value;
                }
            }
        }
        public void Method()
        {
            Console.WriteLine("\nThe stored value is: {0}\n", num);
        }
    }

    //////////////////////////////////////////////////////////////////
    public struct NewStruct6
    {
        public int m, n;
        public NewStruct6(int pt1, int pt2)
        {
            m = pt1;
            n = pt2;
        }
    }

    //////////////////////////////////////////////////////////////////
    struct book7
    {
        public string Title;
        public string Author;
    }

    /////////////////////////////////////////////////////////////////
    public struct NewStruct8
    {
        private double val;
        public double Value
        {
            get { return val; }
            set { val = value; }
        }
        public double Read()
        {
            return double.Parse(Console.ReadLine());
        }
    }
    public struct Square8
    {
        NewStruct8 ln;
        NewStruct8 ht;

        public NewStruct8 Length
        {
            get { return ln; }
            set { ln = value; }
        }
        public NewStruct8 Breadth
        {
            get { return ht; }
            set { ht = value; }
        }
        public void NewSquare()
        {
            NewStruct8 rct = new NewStruct8();

            Console.WriteLine("\nInput the dimensions of the Square (equal length and breadth) : ");
            ln = sqrLength();
            Console.Write("breadth : ");
            ht.Value = rct.Read();
        }
        public NewStruct8 sqrLength()
        {
            NewStruct8 rct = new NewStruct8();

            Console.Write("Length: ");
            rct.Value = rct.Read();
            return rct;
        }
    }

    class Program
    {
        ///////////////////////////////////////////////////////////////
        public static void Structure1()
        {
            Struct1 a = new Struct1();
            a.x = 15;
            a.y = 25;

            int sum = a.x + a.y;
            Console.WriteLine("The sum of x and y is: " + sum);
        }

        /////////////////////////////////////////////////////////////////
        struct Employee2
        {
            public string Name;
            public Birth2 Date;
        }
        struct Birth2
        {
            public int Day;
            public int Month;
            public int Year;
        }
        public static void Structure2()
        {
            int Total = 3;
            Employee2[] Emp = new Employee2[Total];

            Console.Write("\n\nCreate a nested struct and store data in an array :\n");
            Console.Write("-------------------------------------------------------\n");

            for(int i=0; i< Total; i++)
            {
                Console.Write("Name of the employee: ");
                Emp[i].Name = Console.ReadLine();

                Console.Write("Input day of the birth: ");
                Emp[i].Date.Day = Convert.ToInt32(Console.ReadLine());

                Console.Write("Input the month of the birth: ");
                Emp[i].Date.Month = Convert.ToInt32(Console.ReadLine());

                Console.Write("Input the year of the birth: ");
                Emp[i].Date.Year = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine();
            }
        }

        //////////////////////////////////////////////////////////////////
        public static void Structure3()
        {
            Console.Write("\n\nCreate a structure and Assign the Value and call it :\n");
            Console.Write("---------------------------------------------------------\n");

            NewClass3 ClassNum1 = new NewClass3();
            ClassNum1.x = 75;
            ClassNum1.y = 95;

            NewClass3 ClassNum2 = ClassNum1;
            ClassNum1.x = 7500;
            ClassNum1.y = 9500;

            Console.WriteLine("\nAssign in Class:       x:{0},   y:{1}", ClassNum2.x, ClassNum2.y);

            NewStruct3 StructNum1 = new NewStruct3();
            StructNum1.x = 750;
            StructNum1.y = 950;

            NewStruct3 StructNum2 = StructNum1;
            StructNum1.x = 75;
            StructNum1.y = 95;

            Console.WriteLine("Assign in Structure:   x:{0},    y:{1}\n\n", StructNum2.x, StructNum2.y);
        }

        /////////////////////////////////////////////////////////////////////
        public static void TrackStruct(NewStruct4 ns)
        {
            ns.n = 8;
        }
        public static void TrackClass(NewClass4 nc)
        {
            nc.n = 8;
        }
        public static void Structure4()
        {
            Console.Write("\n\nWhen a struct and a class instance is passed to a method :\n");
            Console.Write("--------------------------------------------------------------\n");

            NewStruct4 ns = new NewStruct4();
            NewClass4 nc = new NewClass4();
            ns.n = 5;
            nc.n = 5;

            TrackStruct(ns);  //giá trị trong Struct không thay đổi 
            TrackClass(nc);   //giá trị trong Class thay đổi

            Console.WriteLine("\nns.n = {0}", ns.n);
            Console.WriteLine("nc.n = {0}\n", nc.n);
        }

        /////////////////////////////////////////////////////////////////////
        public static void Structure5()
        {
            Console.Write("\n\nDeclares a struct with a property, a method, and a private field :\n");
            Console.Write("----------------------------------------------------------------------\n");

            NewStruct5 a = new NewStruct5();
            a.n = 15;
            a.Method();
        }

        ///////////////////////////////////////////////////////////////////
        public static void Structure6()
        {
            Console.Write("\n\nStruct declares using default and parameterized constructors :\n");
            Console.Write("-----------------------------------------------------------------\n");

            NewStruct6 Mypoint1 = new NewStruct6();
            NewStruct6 Mypoint2 = new NewStruct6(24,26);

            NewStruct6 Mypoint3;
            Mypoint3.m = 30;
            Mypoint3.n = 40;

            Console.WriteLine("\nNewStruct 1: m = {0}, n = {1}", Mypoint1.m, Mypoint1.n);
            Console.WriteLine("\nNewStruct 2: m = {0}, n = {1}", Mypoint2.m, Mypoint2.n);
            Console.WriteLine("\nNewStruct 3: m = {0}, n = {1}", Mypoint3.m, Mypoint3.n);

            Console.WriteLine("\nPress any key to exit.");
        }

        ////////////////////////////////////////////////////////////////////
        public static void Structure7()
        {
            int NoBook = 1000;
            book7[] book = new book7[NoBook];
            int i, j, n = 1, k = 1;

            Console.Write("\n\nInsert the information of two books :\n");
            Console.Write("-----------------------------------------\n");

            for(j=0; j<=n;j++)
            {

                Console.WriteLine("Information of book {0} :", k);

                Console.Write("Input name of the book : ");
                book[j].Title = Console.ReadLine();

                Console.Write("Input the author : ");
                book[j].Author = Console.ReadLine();
                k++;
                Console.WriteLine();
            }

            for (i = 0; i <= n; i++)
            {
                Console.WriteLine("{0}: Title = {1},  Author = {2}", i + 1, book[i].Title, book[i].Author);
                Console.WriteLine();
            }
        }

        ////////////////////////////////////////////////////////////////////
        public static void Structure8()
        {
            Console.Write("\n\nMethod that returns a structure  :\n");
            Console.Write("--------------------------------------\n");

            var Sqre = new Square8();
            Sqre.NewSquare();

            Console.WriteLine("\nPerimeter and Area of the square :");
            Console.WriteLine("Length: " + Sqre.Length.Value);
            Console.WriteLine("Breadth: " + Sqre.Breadth.Value);
            Console.WriteLine("Perimeter: {0}", (Sqre.Length.Value + Sqre.Breadth.Value) * 2);
            Console.WriteLine("Area: {0}", Sqre.Length.Value * Sqre.Breadth.Value);

        }

        static void Main(string[] args)
        {
            //Structure1();     //simple
            //Structure2();     //nhap du lieu vao struct va luu tru duoi dang mang
            //Structure3();     //Tạo 1 struct, gán giá trị và gọi nó
            //Structure4();     //ví dụ về thay đổi giá trị biến trong class và truct thông qua 1 hàm khác
            //Structure5();     //Miêu tả Struct với thuộc tính, hàm và các thuộc tính riêng
            //Structure6();     //khoi tao struct su dung ca cau truc mac dinh va tham so
            //Structure7();     //nhap du lieu vao mang
            //Structure8();     //goi 1 ham va su dung gia tri ham do

            Console.ReadKey();
        }
    }
}
