using System;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Diagnostics;

namespace Server
{
    public partial class Server : Form
    {
        TcpListener myList;
        Socket socket;
        String data = "";
        bool flagConnected = false;

        public Server()
        {
            InitializeComponent();
        }

        private void btnServer_Click(object sender, EventArgs e)
        {
            ConnectClient();
        }

        private void ConnectClient()
        {
            try
            {
                IPAddress ipAd = IPAddress.Parse(tbAddress.Text); //use local m/c IP address, and use the same in the client
                int port = Int32.Parse(tbPort.Text);

                UpdateStateConnect("Connecting to client...");

                if(myList == null)
                { 
                    myList = new TcpListener(ipAd, port); // Initializes the Listener 
                    myList.Start();  // Start Listeneting at the specified port 
                    socket = myList.AcceptSocket();   // Wait Connection from client
                }

                UpdateStateConnect("Connected!");

                SendData("Connected!");

                flagConnected = true;
                Thread registerReceiveData = new Thread(ReceiveData);
                registerReceiveData.Start();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error server connect: " + ex.Message);
            }
        }
        private void ReceiveData()
        {
            while (flagConnected)
            {
                try
                {
                    byte[] dataReceive = new byte[200];
                    int lengthDataReceive = (int)socket?.Receive(dataReceive);
                    ASCIIEncoding asen = new ASCIIEncoding();
                    data = asen.GetString(dataReceive);
                    UpdateDataReceive(data);
                    data = "";
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Error server receive data: " + ex.Message);
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

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            Disconnect();
        }

        private void Disconnect()
        {
            try
            {
                flagConnected = false;
                //UpdateStateConnect("Disconnect!");
                socket?.Close();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error server disconnect: " + ex.Message);
            }
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
                socket?.Send(asen.GetBytes(data));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error server send data: " + ex.Message);
            }
        }

        private void Server_FormClosing(object sender, FormClosingEventArgs e)
        {
            Disconnect();
        }
    }
}
