using System;
using System.Diagnostics;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Client
{
    public partial class Client : Form
    {
        TcpClient tcpclnt = new TcpClient();
        Stream stream;
        String data = "";
        bool flagConnected = false;

        public Client()
        {
            InitializeComponent();
        }

        private void btnClient_Click(object sender, EventArgs e)
        {
            ConnectSocket();
        }

        private void ConnectSocket()
        {
            try
            {
                UpdateStateConnect("Connecting to server...");

                tcpclnt.Connect(tbAddress.Text, Int32.Parse(tbPort.Text)); // use the ipaddress as in the server program
                stream = tcpclnt.GetStream();

                byte[] dataReceive = new byte[100];
                int lengthDataReceive = (int)stream?.Read(dataReceive, 0, 100);

                UpdateStateConnect("Connected!");

                flagConnected = true;
                Thread registerReceiveData = new Thread(ReceiveData);
                registerReceiveData.Start();
            }
            catch (Exception ex)
            {
                Disconnect();
                Debug.WriteLine("Error client connect: " + ex.Message) ;
            }
        }
        private void ReceiveData()
        {
            while (flagConnected)
            {
                try
                {
                    byte[] dataReceive = new byte[200];

                    int lengthDataReceive = (int)stream?.Read(dataReceive, 0, 100);
                    ASCIIEncoding asen = new ASCIIEncoding();
                    data = asen.GetString(dataReceive);
                    UpdateDataReceive(data);
                    data = "";
                }
                catch (Exception ex)
                {
                    flagConnected = false;
                    Debug.WriteLine("Error client receive data: " + ex.Message);
                }
            }
        }

        private void UpdateStateConnect(string state)
        {
            Invoke(new MethodInvoker(delegate
            {
                labState.Text = state;
            }));
        }
        private void UpdateDataReceive(string data)
        {
            Invoke(new MethodInvoker(delegate
            {
                tbDataReceive.Text = data;
            }));
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            SendData(tbDataSend.Text);
        }

        private void SendData(string data)
        {
            try
            {
                ASCIIEncoding asen = new ASCIIEncoding();
                byte[] dataSend = asen.GetBytes(data);
                stream?.Write(dataSend, 0, dataSend.Length);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error client send data: " + ex.Message);
            }
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            Disconnect();
        }

        private void Disconnect()
        {
            if(stream != null)
            { 
                try
                { 
                    flagConnected = false;
                    UpdateStateConnect("Disconnect!");
                    stream?.Close();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Error client disconnect: " + ex.Message);
                }
            }
        }

        private void Client_FormClosing(object sender, FormClosingEventArgs e)
        {
            Disconnect();
        }
    }
}
