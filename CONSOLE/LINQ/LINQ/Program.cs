using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    class LinqExercise1
    {
        public static void LINQ1()
        {
            //  The first part is Data source.
            int[] n1 = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 14 };

            // The second part is Query creation.
            // nQuery is an IEnumerable<int>
            var nQuery =
                from VrNum in n1
                where (VrNum % 2) == 0
                select VrNum;

            var ds = n1.Where(x => (x % 2) == 0).Select(x => x.ToString("X"));

            // The third part is Query execution.

            Console.Write("\nThe numbers which produce the remainder 0 after divided by 2 are : \n");
            foreach (int VrNum in nQuery)
            {
                Console.Write("{0} ", VrNum);
            }
            Console.Write("\n\n");

            foreach (string x in ds)
            {
                Console.Write("{0} ", x);
            }
            Console.WriteLine("\n\n");
        }
        public static void LINQ2()
        {
            int[] arr = { 1, 3, -2, -4, -7, -3, -8, 12, 19, 6, 9, 10, 14 };

            var Query =
                from x in arr
                where x > 0
                where x < 12
                select x;

            Console.WriteLine(" the number is: ");
            foreach(var x in Query)
            {
                Console.Write(" " + x);
            }
            Console.WriteLine("\n\n");
        }
        public static void LINQ3()
        {
            var arr = new[] {3,9,2,8,6,5};

            var Query = from x in arr
                        let Sqr = x * x
                        where Sqr > 20
                        select new { x, Sqr };
                
            foreach(var x in Query)
            {
                Console.WriteLine(x);
            }
            Console.WriteLine("\n\n");
        }
        public static void LINQ4()
        {
            int[] arr = new int[] { 5, 9, 1, 2, 3, 7, 5, 6, 7, 3, 7, 6, 8, 5, 4, 9, 6, 2 };
            
            var Query = from x in arr
                        group x by x into y
                        select y;
            foreach(var x in Query)
            {
                Console.Write("Number " + x.Key + " appears " + x.Count() + " times!");
                Console.WriteLine("\t=> "+x.Key + " x " + x.Count() + " = " + x.Sum());
            }
            Console.WriteLine("\n\n");
        }
        public static void LINQ5()
        {
            string Start, End;
            string[] Str = {"ROME","LONDON","NAIROBI","CALIFORNIA","ZURICH","NEW DELHI","AMSTERDAM","ABU DHABI", "PARIS"};

            Console.Write("Input starting character for the string : ");
            Start = Convert.ToString(Console.ReadLine());
            Console.Write("Input ending character for the string : ");
            End = Convert.ToString(Console.ReadLine());

            var Query = from x in Str
                        where x.StartsWith(Start)
                        where x.EndsWith(End)
                        select x;

            foreach(var x in Query)
            {
                Console.WriteLine("\nThe city starting with {0} and ending with {1} is : {2}", Start, End, x);
            }
        }
        public static void LINQ6()
        {
            List<int> TempList = new List<int>();
            TempList.Add(55);
            TempList.Add(200);
            TempList.Add(740);
            TempList.Add(76);
            TempList.Add(230);
            TempList.Add(482);
            TempList.Add(95);

            foreach(var x in TempList)
            {
                Console.Write(x + " ");
            }

            List<int> FilterList = TempList.FindAll(x => x > 80 ? true : false);

            Console.WriteLine("\nThe number grater than 80 is: ");
            foreach(var x in FilterList)
            {
                Console.Write(" " + x);
            }
        }
        public static void LINQ7()
        {
            int n,m;
            List<int> _list = new List<int>();

            Console.Write("Enter the number member of List: ");
            n = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i<n; i++)
            {
                Console.Write("Enter the member of List: ");
                _list.Add(Convert.ToInt32(Console.ReadLine()));
            }

            foreach(int x in _list)
            {
                Console.Write(" " + x);
            }

            Console.Write("\nEnter the value of condition: ");
            m = Convert.ToInt32(Console.ReadLine());

            List<int> FilterList = _list.FindAll(x => x > m ? true : false);
            foreach(var x in FilterList)
            {
                Console.Write(" " + x);
            }
        }
        public static void LINQ8()
        {
            int n, m;
            List<int> TempList = new List<int>();

            Console.Write("Enter the number member of List: ");
            n = Convert.ToInt32(Console.ReadLine());

            for(int i=0; i< n; i++)
            {
                Console.Write("Enter the member of list: ");
                TempList.Add(Convert.ToInt32(Console.ReadLine()));
            }

            Console.Write("\nHow many records you want to display?: ");
            m = Convert.ToInt32(Console.ReadLine());

            TempList.Sort();  
            TempList.Reverse();

            Console.WriteLine("\nThe top {0} records from the list are: ", m);
            foreach(int top in TempList.Take(m))
            {
                Console.WriteLine(top);
            }
        }
        public static void LINQ9()
        {
            string Str;

            Console.Write("Enter the string: ");
            Str = Console.ReadLine();

            var Word = WordFilt(Str);

            Console.WriteLine("The UPPER Case words are: ");
            foreach(string x in Word)
            {
                Console.WriteLine(x);
            }
        }
        static IEnumerable<string> WordFilt(String Str)
        {
            var Word = Str.Split(' ').Where(x => String.Equals(x, x.ToUpper(), StringComparison.Ordinal));
            return Word;
        }
        public static void LINQ10()
        {
            int n;
            Console.WriteLine("Enter the number member of array: ");
            n = Convert.ToInt32(Console.ReadLine());
            String[] arr = new string[n];

            for(int i=0; i<n; i++)
            {
                Console.Write("Enter the member of array: ");
                arr[i] = Console.ReadLine();
            }

            String NewString = String.Join(", ", arr.Select(s => s.ToString()).ToArray());

            Console.WriteLine("New string: {0}", NewString);
        }
        public static void LINQ11()
        {
            Students e = new Students();

            Console.Write("Which maximum grade point(1st, 2nd, 3rd, ...) you want to find  : ");
            int Point_Rank = Convert.ToInt32(Console.ReadLine());

            var Student_List = e.Student_Record();
            var Students = (from StuMast in Student_List
                            group StuMast by StuMast.Point into g
                            orderby g.Key descending
                            select new
                            {
                                Strudent_Record = g.ToList()
                            }).ToList();
            Students[Point_Rank - 1].Strudent_Record
                .ForEach(i => Console.WriteLine("ID : {0}, Name : {1}, achieved Grade Point : {2}", i.ID, i.Name, i.Point));
        }
        public static void LINQ12()
        {
            string[] arr1 = { "aaa.frx", "bbb.TXT", "xyz.dbf", "abc.pdf", "aaaa.PDF", "xyz.frt", "abc.xml", "ccc.txt", "zzz.txt" };

            Console.Write("\nHere is the group of extension of the files : \n\n");
            var Group = arr1.Select(file => Path.GetExtension(file).TrimStart('.').ToLower())
                .GroupBy(z => z, (fExt, extCtr) => new
                                                    {
                                                        Extension = fExt,
                                                        Count = extCtr.Count()
                                                    });
            foreach (var m in Group)
                Console.WriteLine("{0} file with {1} extension ", m.Count, m.Extension);

        }

        static void Main()
        {
            //LINQ1();    //Array: tìm số trong mảng là số chẵn
            //LINQ2();    //Array: tìm số x trong mảng arr sao cho 0<x<12
            //LINQ3();    //Array: Tìm số trong mảng sao cho bình phương của chúng >20
            //LINQ4();    //Array: Hien thi so va so lan xuat hien trong mang
            //LINQ5();    //String: Nhap 2 ki tu dac biet, kiem tra co co la ki tu dau or cuoi cua string khong
            //LINQ6();    //List: Hien thi phan tu >80 trong List
            //LINQ7();    //List: nhap phan tu cua List, hien thi phan tu theo dieu kien nhap
            //LINQ8();    //List: Nhap List, nhap so ban ghi muon hien thi, tim nhung so dau, sap xep giam dan
            //LINQ9();    //String: Nhap chuoi string (co chu in hoa), tim va hien thi chu in hoa
            //LINQ10();   //Array - String: nhap 1 mang String, chuyen doi mang string do sang chuoi string
            //LINQ11();   //List: Tim thu tu xep hang diem cua hoc sinh trong list. 
            //LINQ12();   //Array - String: Tach va nhom cac file mo rong

            Console.ReadKey();
        }
    }

    public class Students
    {
        public string Name { get; set; }
        public int Point { get; set; }
        public int ID { get; set; }
        public List<Students> Student_Record()
        {
            List<Students> Student_List = new List<Students>();

            Student_List.Add(new Students { ID = 1, Name = "Joseph", Point = 800 });
            Student_List.Add(new Students { ID = 2, Name = "Alex", Point = 458 });
            Student_List.Add(new Students { ID = 3, Name = "Harris", Point = 900 });
            Student_List.Add(new Students { ID = 4, Name = "Taylor", Point = 900 });
            Student_List.Add(new Students { ID = 5, Name = "Smith", Point = 458 });
            Student_List.Add(new Students { ID = 6, Name = "Natasa", Point = 700});
            Student_List.Add(new Students { ID = 7, Name = "David", Point = 750 });
            Student_List.Add(new Students { ID = 8, Name = "Harry", Point = 700 });
            Student_List.Add(new Students { ID = 9, Name = "Nicolash", Point = 597 });
            Student_List.Add(new Students { ID = 10, Name = "Jenny", Point = 750 });

            return Student_List;
        }
    }
}
