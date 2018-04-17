using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestSerial
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();  //Visual styles are the colors, fonts, and other visual elements that form an operating system theme
            Application.SetCompatibleTextRenderingDefault(false);  //
            Application.Run(new MainForm());  //Begins running a standard application message loop on the current thread
        }
    }
}
