using System;
using System.Windows.Forms;
using System.IO.Ports;
using System.Timers;
using API_Moving;

namespace MovingKiosk
{
    public partial class Form1 : Form     ////KHOI TAO class Form1
    {
        private System.Timers.Timer timer;     //khai bao su dung timer
        private class1 robot;

        private bool bForward = false;   //khai bao bien kieu bool
        private bool bBackward = false;
        private bool bTurnLeft = false;
        private bool bTurnRight = false;

        public Form1()  //public LA CHE DO CONG KHAI, class KHAC CUNG CO THE GOI TOI HAM NAY
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)   ///khoi tao ban dau
        {
            LoadCom();
            LoadSpeed();

            robot = new class1();

            //bat timer de tao chu ki truyen UART
            timer = new System.Timers.Timer(50);    //chu ki ngat timer la 50ms
            timer.AutoReset = true;
            timer.Elapsed += OnTimerEvent;    //goi ham OnTimerEvent khi co ngat timer
            timer.Enabled = true;
        }

        private void btConnect_Click(object sender, EventArgs e)
        {
            if (robot.IsConnect)
            {
                btConnect.Text = "Connect";
                robot.Disconnect();
            }
            else
            {
                if (robot.Connect(cboCom.Text))
                {
                    btConnect.Text = "Disconnect";
                }
                else
                {
                    btConnect.Text = "Connect";
                }
            }//*/
        }

        private void OnTimerEvent(object source, ElapsedEventArgs e)
        {
            
            try   //su dung ham try...catch de bat loi, neu co loi xay ra se gui messageBox
            {
                if(bForward )
                {
                    robot.Forward();
                }
                if(bBackward )
                {
                    robot.Backward();
                }
                if(bTurnLeft )
                {
                    robot.TurnLeft();
                }
                if(bTurnRight)
                {
                    robot.TurnRight();
                }
            }
            catch(Exception ex)
            {
                bForward = false;
                bBackward = false;
                bTurnLeft = false;
                bTurnRight = false;
                MessageBox.Show(ex.ToString());
            }
        }

        private void btForward_MouseDown(object sender, MouseEventArgs e)
        {
            bForward = true;
        }

        private void btForward_MouseUp(object sender, MouseEventArgs e)
        {
            bForward = false;
        }

        private void btBackward_MouseDown(object sender, MouseEventArgs e)
        {
            bBackward = true;
        }

        private void btBackward_MouseUp(object sender, MouseEventArgs e)
        {
            bBackward = false;
        }

        private void btTurnLeft_MouseDown(object sender, MouseEventArgs e)
        {
            bTurnLeft = true;
        }

        private void btTurnLeft_MouseUp(object sender, MouseEventArgs e)
        {
            bTurnLeft = false;
        }

        private void btTurnRight_MouseDown(object sender, MouseEventArgs e)
        {
            bTurnRight = true;
        }

        private void btTurnRight_MouseUp(object sender, MouseEventArgs e)
        {
            bTurnRight = false;
        }

        private void cboSpeed_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //kiem tra lua chon 
                switch (cboSpeed.Text)    //lấy tên phép toán
                {
                    case "Fast":
                        robot.FastSpeed();
                        break;
                    case "Slow":
                        robot.SlowSpeed();
                        break;
                }//*/
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void LoadCom()
        {
            cboCom.Items.Clear();
            cboCom.Items.AddRange(SerialPort.GetPortNames());
            if (cboCom.Items.Count > 0)
            {
                cboCom.SelectedIndex = 0;
            }
        }

        private void cboCom_DropDown(object sender, EventArgs e)
        {
            cboCom.Items.Clear();
            cboCom.Items.AddRange(SerialPort.GetPortNames());
        }

        private void LoadSpeed()
        {
            if (cboSpeed.Items.Count > 0)
            {
                cboSpeed.SelectedIndex = 0;
            }
        }
    }
}
