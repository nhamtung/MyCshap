using System;
using System.IO.Ports;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeneralSerial
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            GetAvailablePorts();
        }

        private void GetAvailablePorts()
        {
            String[] ports = SerialPort.GetPortNames();
            comboBoxComPort.Items.AddRange(ports);
        }
        private void ReadSerial()
        {
            var t = Task.Run(() =>
            {
                while (true)
                {
                    String data = serialPort1.ReadLine();
                   
                    DisplayReadSerial(data);
                    Thread.Sleep(100);
                }
            });
        }
        private void DisplayReadSerial(String data)
        {
            this.Invoke((MethodInvoker)delegate
            {
                try
                {
                    textBoxReceive.Text = data;
                }
                catch (TimeoutException)
                {
                    textBoxReceive.Text = "Timeout!";
                }
            });
        }

        private void Connect_Click(object sender, EventArgs e)
        {
            try
            {
                if((comboBoxComPort.Text == "") || (comboBoxBaudrate.Text == "")){
                    textBoxReceive.Text = "Please choose port setting!";
                }
                else {
                    serialPort1.PortName = comboBoxComPort.Text;
                    serialPort1.BaudRate = Convert.ToInt32(comboBoxBaudrate.Text);
                    serialPort1.Open();
                    textBoxReceive.Text = "READY!";
                    ReadSerial();

                    //Thread t = new Thread(ReadSerial);
                    //t.Start();

                    //Task task = new Task(() => { ReadSerial(); });
                    //task.Start();
                }
            }
            catch(Exception ex)
            {
                textBoxReceive.Text = Convert.ToString(ex);
            }
        }

        private void Disconnect_Click(object sender, EventArgs e)
        {
            serialPort1.Close();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            serialPort1.WriteLine(textBoxSend.Text);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            textBoxSend.Text = "";
            textBoxReceive.Text = "";
        }
    }
}
