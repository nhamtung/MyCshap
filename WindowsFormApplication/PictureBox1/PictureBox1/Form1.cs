using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PictureBox1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.BorderStyle = BorderStyle.Fixed3D;

            Image Anhnen = Properties.Resources.Anh_3;

            pictureBox1.Image = Anhnen;
            
            pictureBox1.Height = 300;
            pictureBox1.Width = Anhnen.Width * 300 / Anhnen.Height;

            this.Width = pictureBox1.Width + 35;
            this.Height = pictureBox1.Height + 115;

            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
        }
    }
}
