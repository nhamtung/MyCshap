using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace Client
{
    public partial class Client : Form
    {
        TcpClient tcpclnt = new TcpClient();

        public Client()
        {
            InitializeComponent();
        }

        private void btnClient_Click(object sender, EventArgs e)
        {
            try
            {
                //MessageBox.Show("Client: Connecting.....");
                tcpclnt.Connect("192.168.6.228", 8001); // use the ipaddress as in the server program


                Stream stream = tcpclnt.GetStream();
                byte[] dataReceive = new byte[100];
                int lengthDataReceive = stream.Read(dataReceive, 0, 100);
                MessageBox.Show("Client: OK");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Client: Error....." + ex.StackTrace) ;
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                String data = comboBox.Text;
                Stream stream = tcpclnt.GetStream();

                ASCIIEncoding asen = new ASCIIEncoding();
                byte[] dataSend = asen.GetBytes(data);
                //MessageBox.Show("Client: Transmitting.....");
                stream.Write(dataSend, 0, dataSend.Length);



                //for (int i = 0; i < lengthDataReceive; i++)
                //    MessageBox.Show("Client: " + Convert.ToChar(dataReceive[i]));

                //tcpclnt.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex));
            }
        }
    }
}
