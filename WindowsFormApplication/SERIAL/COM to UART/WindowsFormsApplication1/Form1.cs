using System;
using System.Windows.Forms;
using System.IO.Ports;   //goi thu vien port Serial

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        SerialPort mySerialPort = new SerialPort("COM4", 9600);    //Khai bao su dung cong COM4, toc do baud = 9600
            
        public Form1()
        {
            InitializeComponent();
            mySerialPort.Open();    //kich hoat mySerialPort
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mySerialPort.Write("1");    //gui du lieu dang tring qua UART
        }

        private void button2_Click(object sender, EventArgs e)
        {
            mySerialPort.Write(new byte[] { 0x41 }, 0, 1);  //gui gia tri (ASCII) trong mang byte, bat dau tu vi tri 0 va gui 1 phan tu
        }
    }
}
