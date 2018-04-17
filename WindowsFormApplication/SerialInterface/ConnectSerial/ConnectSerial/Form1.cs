using System;
using System.IO.Ports;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConnectSerial
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            getAvailablePorts();

            progressBar.Value = 0;
            btnRead.Enabled = false;
            btnSend.Enabled = false;
            btnClose.Enabled = false;
            btnOpen.Enabled = true;
        }

        void getAvailablePorts()
        {
            String[] ports = SerialPort.GetPortNames();
            comboBoxCOM.Items.AddRange(ports);
        }
        

        //private void ReceiveSerial()
        //{

        //    try
        //    {
        //        this.Invoke(new MethodInvoker(delegate
        //        {
        //            txtReceive.Text = serialPort1.ReadLine();
        //        }));
        //        MessageBox.Show(serialPort1.ReadLine());
        //    }
        //    catch (Exception ex)
        //    {
        //        this.Invoke(new MethodInvoker(delegate
        //        {
        //            txtReceive.Text = Convert.ToString(ex);
        //        }));
        //    }
        //}

        private void btnSend_Click(object sender, EventArgs e)
        {
            serialPort1.WriteLine(txtSend.Text);
            txtSend.Text = "";
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            try
            {
                txtReceive.Text = serialPort1.ReadLine();
            }
            catch (Exception ex)
            {
                txtReceive.Text = Convert.ToString(ex);
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxCOM.Text == "" || comboBoxBaudrate.Text == "")
                {
                    txtReceive.Text = "Please choose the setting!";
                }
                else
                {
                    serialPort1.PortName = comboBoxCOM.Text;
                    serialPort1.BaudRate = Convert.ToInt32(comboBoxBaudrate.Text);
                    serialPort1.Open();
                    progressBar.Value = 100;
                    btnSend.Enabled = true;
                    txtSend.Enabled = true;
                    btnRead.Enabled = true;
                    btnOpen.Enabled = false;
                    btnClose.Enabled = true;

                    //Task.Run(() =>
                    //{
                    //    while (true)
                    //    {
                    //        ReceiveSerial();
                    //    }
                    //});
                }
            }
            catch (UnauthorizedAccessException)
            {
                txtReceive.Text = "Unauthorized access!";
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            serialPort1.Close();
            progressBar.Value = 0;
            btnSend.Enabled = false;
            btnRead.Enabled = false;
            btnClose.Enabled = false;
            btnOpen.Enabled = true;
        }
    }
}
