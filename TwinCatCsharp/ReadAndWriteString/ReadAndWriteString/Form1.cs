/*
 * PROGRAM MAIN
    VAR
     text : STRING[30] := 'hello';
    END_VAR

    https://infosys.beckhoff.com/english.php?content=../content/1033/tcsample/html/tcsample_intro.htm&id=2105283098444985027
 */

using System;
using System.Diagnostics;
using System.Windows.Forms;
using TwinCAT.Ads;

namespace ReadAndWriteString
{
    public partial class Form1 : Form
    {
        private TcAdsClient adsClient;
        private int varHandle;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                adsClient = new TcAdsClient();
                adsClient.Connect(851);
                varHandle = adsClient.CreateVariableHandle("MAIN.text");
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
            }
        }


        private void btnRead_Click(object sender, EventArgs e)
        {
            try
            {
                AdsStream adsStream = new AdsStream(30);
                AdsBinaryReader reader = new AdsBinaryReader(adsStream);
                adsClient.Read(varHandle, adsStream);
                textBox1.Text = reader.ReadPlcString(30);
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
            }
        }

        private void btnWrite_Click(object sender, EventArgs e)
        {
            try
            {
                AdsStream adsStream = new AdsStream(30);
                AdsBinaryWriter writer = new AdsBinaryWriter(adsStream);
                writer.WritePlcString(textBox1.Text, 30);
                adsClient.Write(varHandle, adsStream);
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            adsClient.Dispose();
        }
    }
}
