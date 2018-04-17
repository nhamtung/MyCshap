using System;
using System.Windows.Forms;
using System.IO.Ports;    //TRUYEN TIN HIEU UART QUA CONG COM
using System.Timers;    //THU VIEN TIMER

namespace MOVING
{
    public partial class Form1 : Form     //KHOI TAO class Form1
    {
        SerialPort mySerialPort = new SerialPort("COM4", 115200);  //TRUYEN TIN HIEU UART QUA CONG COM4
        private System.Timers.Timer timer;   //KHAI BAO TIMER

        private bool btForward = false;     //KHAI BAO BIEN btForward KIEU BOOLEN
        private bool btBackward = false;
        private bool btTurnleft = false;
        private bool btTurnright = false;

        public Form1()   //public LA CHE DO CONG KHAI, class KHAC CUNG CO THE GOI TOI HAM NAY
        {
            InitializeComponent();
            mySerialPort.Open();    //TRUYEN TIN HIEU UART QUA CONG COM
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer = new System.Timers.Timer(50);   //CHU KI NGAT TIMER LAF 100ms
            timer.AutoReset = true;
            timer.Elapsed += OnTimedEvent;    //GOI TOI HAM OnTimedEvent KHI CO NGAT TIMER
            timer.Enabled = true;
        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            if (btForward)
            {
                Forward();
            }
            if (btBackward)
            {
                Backward();
            }
            if (btTurnleft)
            {
                Turnleft();
            }
            if (btTurnright)
            {
                Turnright();
            }//*/
        }

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            btForward = true;
        }

        private void button1_MouseUp(object sender, MouseEventArgs e)
        {
            btForward = false;
        }

        private void Forward()
        {
            mySerialPort.Write(new byte[] { 0x41}, 0, 1);  //gui gia tri trong mang byte, bat dau tu vi tri 0 va gui 1 phan tu
        }

        private void button2_MouseDown(object sender, MouseEventArgs e)
        {
            btBackward = true;
        }

        private void button2_MouseUp(object sender, MouseEventArgs e)
        {
            btBackward = false;
        }

        private void Backward()
        {
            mySerialPort.Write("B");
        }

        private void button3_MouseDown(object sender, MouseEventArgs e)
        {
            btTurnleft = true;
        }

        private void button3_MouseUp(object sender, MouseEventArgs e)
        {
            btTurnleft = false;
        }

        private void Turnleft()
        {
            mySerialPort.Write("C");
        }

        private void button4_MouseDown(object sender, MouseEventArgs e)
        {
            btTurnright = true;
        }

        private void button4_MouseUp(object sender, MouseEventArgs e)
        {
            btTurnright = false;
        }
        private void Turnright()
        {
            mySerialPort.Write("D");
        }//*/
    }
}
