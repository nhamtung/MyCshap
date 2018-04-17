using System;
using System.Windows.Forms;

namespace EmbedFlashToForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            String link = @"D:\TUNG\C Sharp\WindowsFormApplication\EmbedFlashToForm\welcome_kiosk.swf";
            flash.LoadMovie(0, link);
        }
    }
}
