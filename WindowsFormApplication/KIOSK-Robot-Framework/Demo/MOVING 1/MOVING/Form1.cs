using System;
using System.Windows.Forms;
using System.IO.Ports;    //TRUYEN TIN HIEU UART QUA CONG COM
using System.Timers;    //THU VIEN TIMER
using Kiosk;

namespace MOVING
{
    public partial class Form1 : Form     //KHOI TAO class Form1
    {
        private System.Timers.Timer timer;   //KHAI BAO TIMER
        private Robot robot;

        private bool btForward = false;     //KHAI BAO BIEN btForward KIEU BOOLEN
        private bool btBackward = false;
        private bool btTurnleft = false;
        private bool btTurnright = false;

        public Form1()   //public LA CHE DO CONG KHAI, class KHAC CUNG CO THE GOI TOI HAM NAY
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] COMport = SerialPort.GetPortNames();
            cboCom.Items.AddRange(COMport);
            cboCom.SelectedIndex = 0;

            robot = new Robot();

            timer = new System.Timers.Timer(50);   //CHU KI NGAT TIMER LAF 50ms
            timer.AutoReset = true;
            timer.Elapsed += OnTimedEvent;    //GOI TOI HAM OnTimedEvent KHI CO NGAT TIMER
            timer.Enabled = true;
        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            try
            {
                if (btForward)
                {
                    robot.Forward();
                }
                if (btBackward)
                {
                    robot.Backward();
                }
                if (btTurnleft)
                {
                    robot.TurnLeft();
                }
                if (btTurnright)
                {
                    robot.TurnRight();
                }//*/
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            btForward = true;
        }

        private void button1_MouseUp(object sender, MouseEventArgs e)
        {
            btForward = false;
        }

        private void button2_MouseDown(object sender, MouseEventArgs e)
        {
            btBackward = true;
        }

        private void button2_MouseUp(object sender, MouseEventArgs e)
        {
            btBackward = false;
        }

        private void button3_MouseDown(object sender, MouseEventArgs e)
        {
            btTurnleft = true;
        }

        private void button3_MouseUp(object sender, MouseEventArgs e)
        {
            btTurnleft = false;
        }

        private void button4_MouseDown(object sender, MouseEventArgs e)
        {
            btTurnright = true;
        }

        private void button4_MouseUp(object sender, MouseEventArgs e)
        {
            btTurnright = false;
        }

        private void cboSpeed_SelectedIndexChanged(object sender, EventArgs e)
        {
            //kiem tra lua chon 
            /*switch(cboSpeed.Text)    //lấy tên phép toán
            {
                case "FAST":
                    mySerialPort.Write(new byte[] { 0x46 }, 0, 1);
                    break;
                case "SLOW":
                    mySerialPort.Write(new byte[] { 0x45 }, 0, 1);
                    break;
          }//*/
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (robot.IsConnect)
            {
                button5.Text = "Connect";
                robot.Disconnect();
            }
            else
            {
                if (robot.Connect(cboCom.Text))
                {
                    button5.Text = "Disconnect";
                }
                else
                {
                    button5.Text = "Connect";
                }
            }
        }
    }
}
