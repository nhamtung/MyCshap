using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TwinCAT.Ads;

namespace HMI
{
    public partial class Form1 : Form
    {
        TcAdsClient tcPort = new TcAdsClient();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGetValue_Click(object sender, EventArgs e)
        {
            try
            {
                //Connect to TwwinCAT port
                tcPort.Connect(textBoxNetID.Text, Convert.ToInt32(textBoxPort.Text));

                //Specify IndexGroup, IndexOffset and SPSVar
                //Group 0x4020 mean access %M memory in TwinCAT PLC
                var iFlag = (int) tcPort.ReadAny(0x4020, 0x00, typeof (Int32));
                textBoxValue.Text = Convert.ToString(iFlag);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
    }
}
