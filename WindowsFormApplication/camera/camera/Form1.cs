using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using WinFormCharpWebCam;

namespace camera
{
    public partial class Form1 : Form
    {
        WebCam webcam;
        public Form1()
        {
            InitializeComponent();
            webcam = new WebCam();
            webcam.InitializeWebCam(ref pictureBox1);
            pictureBox1.BorderStyle = BorderStyle.Fixed3D;
            pictureBox2.BorderStyle = BorderStyle.Fixed3D;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            webcam.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            pictureBox2.Image = pictureBox1.Image;
            pictureBox2.Height = 300;
            pictureBox2.Width = pictureBox1.Image.Width * 300 / pictureBox1.Image.Height;

            this.Width = pictureBox2.Width + 400;
            this.Height = pictureBox2.Height + 150;

            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
        }
    }
}
