using System;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Server
{
    public partial class Server : Form
    {
        Socket socket;
        String data = "";

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
                string address = tbAddress.Text;
                int port = Int32.Parse(tbPort.Text);

                IPAddress ipAd = IPAddress.Parse(address); //use local m/c IP address, and use the same in the client
                TcpListener myList = new TcpListener(ipAd, port); // Initializes the Listener 
                myList.Start();  // Start Listeneting at the specified port 

                socket = myList.AcceptSocket();
                MessageBox.Show("Server: Connection accepted from " + socket.RemoteEndPoint);
                
                ASCIIEncoding asen = new ASCIIEncoding();
                socket.Send(asen.GetBytes("Connected!"));

                Thread registerReceiveData = new Thread(ReceiveData);
                registerReceiveData.Start();
            }
            catch (Exception ex){
                MessageBox.Show("Server: Error..... " + ex.StackTrace);
            }
        }
        private void ReceiveData()
        {
            while (true)
            {
                try
                {
                    byte[] dataReceive = new byte[200];

                    int lengthDataReceive = socket.Receive(dataReceive);
                    ASCIIEncoding asen = new ASCIIEncoding();
                    data = asen.GetString(dataReceive);

                    labData.Invoke(new MethodInvoker(delegate
                    {
                        labData.Text = "data: " + data;
                        data = "";
                    }));
                }
                catch (Exception ex)
                {
                    socket.Close();
                    ConnectClient();
                }
            }
        }
    }
}
