using System.Windows.Forms;
using TwinCAT.Ads;
using System.IO;
/// <summary>
/// http://tbe.vn/chia-se-kien-thuc/9604-ket-noi-twincat-voi-visual-studio-net-visual-basic.html
/// </summary>


namespace TwinCAT
{
    public partial class Form1 : Form
    {
        private TcAdsClient tcAds;
        private MemoryStream ds;
        private BinaryReader br;
        private BinaryWriter bw;

        public Form1()
        {
            InitializeComponent();
            Connect();
        }

        /// <summary>
        /// Create instance and connect to class TcAdsClient
        /// </summary>
        private void Connect()
        {
            tcAds = new TcAdsClient();
            tcAds.Connect("1.2.3.4.1.1", 801);
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
            tcAds.Read(&H4020, 0, ds);
            ds.Position = 0;
            txtBox.Text = br.ReadInt32().ToString();
        }

        private void WriteDataPLC()
        {
            int x = 100;
            ds.Position = 0;
            bw.Write(x);

            tcAds.Write(&H4020, 0, ds);
        }
    }
}
