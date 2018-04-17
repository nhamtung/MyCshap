using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Date_Time
{
    class Program
    {
        public static void Date_Time1()
        {
            DateTime DT1 = new DateTime(2017, 6, 28, 4, 30, 0);
            Console.WriteLine("Complete date: " + DT1.ToString());     //Hien thi du: 08-Jun-16 11:49:00 AM

            DateTime DateOnly = DT1.Date;

            Console.WriteLine("Short Date: " + DateOnly.ToString("d"));     //Hien thij ngay: 08-Jun-16
            Console.WriteLine("Display date using 24-hour clock format:");     
            Console.WriteLine(DateOnly.ToString("g"));     //dinh dang 12h: 08-Jun-16 12:00 AM
            Console.WriteLine(DateOnly.ToString("MM/dd/yyy HH:mm"));     //Dinh dang 24h: 08-Jun-2016 00:00

            Console.WriteLine("\nThe day of the week for {0:d} is {1}.\n", DT1, DT1.DayOfWeek);
            

            System.DateTime moment = new System.DateTime(2017, 6, 28, 4, 34, 32, 11);

            Console.WriteLine("year = " + moment.Year);
            Console.WriteLine("month = " + moment.Month);
            Console.WriteLine("day = " + moment.Day);
            Console.WriteLine("hour = " + moment.Hour);
            Console.WriteLine("minute = " + moment.Minute);
            Console.WriteLine("second = " + moment.Second);
            Console.WriteLine("millisecond = " + moment.Millisecond);
        }
        public static void Date_Time2()
        {
            DateTime DT2 = new DateTime(2000, 12, 31);

            for(int i=0; i<=20; i++)
            {
                DateTime DateDisplay = DT2.AddYears(i);
                Console.WriteLine("{0:d}: day {1} of {2} {3}", DateDisplay, DateDisplay.DayOfYear, DateDisplay.Year,
                    DateTime.IsLeapYear(DateDisplay.Year) ? "(Leap Year)" : "");
            }
        }
        public static void Date_Time3()
        {
            DateTime LocalDate =  DateTime.Now;  //lay thoi gian hien tai
            DateTime UtcDate = DateTime.UtcNow;
            DateTime thisDay = DateTime.Today;   //Lay ngua hien tai
            System.DateTime today = System.DateTime.Now;

            /////////////////////////////////////////////////////////////////////////////
            Console.WriteLine("Day: {0:d} Time: {1:g}", LocalDate.Date, LocalDate.TimeOfDay);
            Console.WriteLine("Day: {0:d} Time: {0:t}\n", LocalDate);

            ///////////////////////////////////////////////////////////////////////////
            string[] CultureNames = { "en-IE", "en-ZA" };//, "fr-CA", "de-CH", "ro-RO", "en-JM", "en-NZ", "fr-BE", "de-CH", "nl-NL" };
            foreach(var CultureName in CultureNames)
            {
                var Culture = new CultureInfo(CultureName);

                Console.WriteLine("{0}: ",Culture.NativeName);
                Console.WriteLine("   Loca date and time: {0}, {1:G}", LocalDate.ToString(Culture), LocalDate.Kind);
                Console.WriteLine("   UTC date and: {0}, {1:G}\n", UtcDate.ToString(Culture), UtcDate.Kind);
            }//*/

            ////////////////////////////////////////////////////////////////////////////////////
            Console.WriteLine("General format " + thisDay.ToString());
            Console.WriteLine("Display the date in a variety of formats: ");
            Console.WriteLine(thisDay.ToString("d"));
            Console.WriteLine(thisDay.ToString("D"));
            Console.WriteLine(thisDay.ToString("g"));

            /////////////////////////////////////////////////////////////////////////////////////////
            System.Console.WriteLine("\nToday = " + System.DateTime.Now);
            System.TimeSpan duration = new System.TimeSpan(40, 0, 0, 0);
            System.DateTime answer = today.Add(duration);
            System.Console.WriteLine("{0:dddd}", answer);

            DateTime todays = DateTime.Now;
            DateTime answers = todays.AddDays(40);
            Console.WriteLine("\nToday: {0:dddd}", todays);
            Console.WriteLine("40 days from today: {0:dddd}", answers);

        }
        static void Main(string[] args)
        {
            //Date_Time1();     //dinh dang co ban
            //Date_Time2();     //hien thi so ngay cua nam
            Date_Time3();     //hien thi ngay thang hien tai tren may tinh


            Console.WriteLine("\nPress any button to out!");
            Console.ReadKey();
        }
    }
}
