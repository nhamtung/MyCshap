/*
 * PLC program

    PROGRAM MAIN
    VAR 
        Time1:TIME := T#21h33m23s231ms;
        Date1:DT:=DT#1993-06-12-15:36:55.40;
    END_VAR

    https://infosys.beckhoff.com/english.php?content=../content/1033/tcsample/html/tcsample_intro.htm&id=2105283098444985027
 */

using System;
using System.Diagnostics;
using System.Windows.Forms;
using TwinCAT.Ads;

namespace ReadAndWriteDateTime
{
    public partial class Form1 : Form
    {
        private TcAdsClient adsClient;
        private int[] varHandles;

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

                varHandles = new int[2];
                varHandles[0] = adsClient.CreateVariableHandle("MAIN.Time");
                varHandles[1] = adsClient.CreateVariableHandle("MAIN.Date");
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
                AdsStream adsStream = new AdsStream(4);
                AdsBinaryReader reader = new AdsBinaryReader(adsStream);

                adsClient.Read(varHandles[0], adsStream);
                textBox1.Text = reader.ReadPlcTIME().ToString();

                adsStream.Position = 0;
                adsClient.Read(varHandles[1], adsStream);
                textBox2.Text = reader.ReadPlcDATE().ToString();
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
                AdsStream adsStream = new AdsStream(4);
                AdsBinaryWriter writer = new AdsBinaryWriter(adsStream);

                writer.WritePlcType(TimeSpan.Parse(textBox1.Text));
                adsClient.Write(varHandles[0], adsStream);

                adsStream.Position = 0;
                writer.WritePlcType(DateTime.Parse(textBox2.Text));
                adsClient.Write(varHandles[1], adsStream);
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                adsClient.Dispose();
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
            }
        }
    }
}
