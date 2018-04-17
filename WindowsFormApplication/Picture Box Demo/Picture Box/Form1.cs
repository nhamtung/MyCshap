using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Picture_Box
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.BorderStyle = BorderStyle.FixedSingle; // Fixed3D;   //tao border: dùng thuộc tính BorderStyle, dạng 1 đường viền/dạng 3D
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Image anhnen = Properties.Resources.Nen;
            pictureBox1.BackgroundImage = anhnen;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Image anh = Properties.Resources.Anh;
            pictureBox1.Image = anh;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;     /// AutoSize   StretchImage   Zoom;   
        }

        private void button5_Click(object sender, EventArgs e)
        {
            pictureBox1.ImageLocation = "Anh.jpg";
        }
    }
}