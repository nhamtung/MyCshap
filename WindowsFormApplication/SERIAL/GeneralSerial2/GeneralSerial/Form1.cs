using System;
using System.Diagnostics;
using System.IO.Ports;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeneralSerial
{
    public partial class Form1 : Form
    {
        int preBuffSize;
        int buffSize;

        int num;
        byte[] buffData = new byte[59904];

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
                else
                {
                    buffSize = 0;
                    serialPort1.PortName = comboBoxComPort.Text;
                    serialPort1.BaudRate = Convert.ToInt32(comboBoxBaudrate.Text);
                    serialPort1.ReadTimeout = 2000; // set read time out to 2 seconds
                    serialPort1.Open();
                    textBoxReceive.Text = "READY!";

                    //Enable Event Handler
                    serialPort1.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);
                    
                }
            }
            catch(Exception ex)
            {
                textBoxReceive.Text = Convert.ToString(ex);
            }
        }

        private void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            int intBuffer = serialPort1.BytesToRead;
            byte[] byteBuffer = new byte[intBuffer];
            serialPort1.Read(byteBuffer, 0, intBuffer);

            num++;
            preBuffSize = buffSize;
            buffSize += intBuffer;

            String message = "intBuffer: " + Convert.ToString(intBuffer) + "\r\n";
            message += "buffSize: " + Convert.ToString(buffSize) + "\r\n";
            message += "num: " + Convert.ToString(num) + "\r\n";
            DisplayReadSerial(message);

            for (int i = 0; i < intBuffer; i++)
            {
                try
                {
                    buffData[preBuffSize + i] = (byte)byteBuffer[i];
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }
        }

        private void Disconnect_Click(object sender, EventArgs e)
        {
            serialPort1.Close();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            ResetParameter();
            try { 
                serialPort1.WriteLine(textBoxSend.Text);
            }
            catch(Exception ex)
            {
                Debug.WriteLine("Error: Send", ex);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ResetParameter();
        }

        private void btnDisplayData_Click(object sender, EventArgs e)
        {
            String data = "buffSize: " + Convert.ToString(buffSize) + "\r\n";
            for (int i = 0; i < buffSize; i++)
            {
                try
                {
                    if(cbHex.CheckState == 0)
                    {
                        data += Convert.ToChar(buffData[i]);
                    }
                    else
                    {
                        data += Convert.ToString(buffData[i]) + " ";
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }
            DisplayReadSerial(data);
        }
        private void ResetParameter()
        {
            buffSize = 0;
            num = 0;
            preBuffSize = 0;
            textBoxReceive.Text = "";
        }
    }
}
