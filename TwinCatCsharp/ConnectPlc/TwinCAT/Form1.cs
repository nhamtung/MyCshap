using System.Windows.Forms;
using TwinCAT.Ads;
using System.IO;
using System;
using System.Diagnostics;
/// <summary>
/// http://tbe.vn/chia-se-kien-thuc/9604-ket-noi-twincat-voi-visual-studio-net-visual-basic.html
/// </summary>


namespace ConnectPlc
{
    public partial class Form1 : Form
    {
        private TcAdsClient tcAds;
        private AdsStream ds;
        private BinaryReader br;
        private BinaryWriter bw;

        public Form1()
        {
            InitializeComponent();
            AdsStream();
        }

        /// <summary>
        /// Create instance and connect to class TcAdsClient
        /// </summary>
        private void Connect()
        {
            if(tcAds == null)
                tcAds = new TcAdsClient();
            tcAds.Connect("1.2.3.4.1.1", 801);
        }

        private void Disconnect()
        {
            try
            {
                if(tcAds != null)
                { 
                    tcAds.Dispose();
                    tcAds = null;
                }
            }
            catch(Exception ex) {
                Debug.WriteLine("Disconnect");
            }
        }

        /// <summary>
        /// Transmision data
        /// Creates a stream with a length of 4 bytes
        /// </summary>
        private void AdsStream()
        {
            ds = new AdsStream(4);
            br = new BinaryReader(ds);
            bw = new BinaryWriter(ds);
        }

        /// <summary>
        /// Read a data from PLC
        /// </summary>
        private void ReadDataPLC()
        {
            tcAds.Read(0x4020, 0, ds);
            ds.Position = 0;
            txtBox.Text = br.ReadInt32().ToString();
        }

        private void WriteDataPLC()
        {
            int x = 100;
            ds.Position = 0;
            bw.Write(x);

            tcAds.Write(0x4020, 0, ds);
        }

        private void btnConnect_Click(object sender, System.EventArgs e)
        {
            Connect();
        }

        private void btnDisconnect_Click(object sender, System.EventArgs e)
        {
            Disconnect();
        }
    }
}
//PLC Program:

//PROGRAM MAIN
//VAR
//        test AT%MD0 : DINT;
//END_VAR
//test := test + 1;