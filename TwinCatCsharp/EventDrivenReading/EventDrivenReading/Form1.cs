/*
 * PLC program

    PROGRAM MAIN
    VAR
     boolVal          : BOOL;
     intVal    : INT;
     dintVal   : DINT;
     sintVal   : SINT;
     lrealVal  : LREAL;
     realVal   : REAL;
     stringVal : STRING(10);
    END_VAR

    PROGRAM MAIN
    VAR
        ;
    END_VAR

    https://infosys.beckhoff.com/english.php?content=../content/1033/tcsample/html/tcsample_intro.htm&id=2105283098444985027
 */

using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using TwinCAT.Ads;

namespace EventDrivenReading
{
    public partial class Form1 : Form
    {
        private TcAdsClient tcClient;
        private int[] hConnect;
        private AdsStream dataStream;
        private BinaryReader binRead;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataStream = new AdsStream(31);
            //Encoding wird auf ASCII gesetzt, um Strings lesen zu können
            binRead = new BinaryReader(dataStream, System.Text.Encoding.ASCII);
            // Instanz der Klasse TcAdsClient erzeugen
            tcClient = new TcAdsClient();
            // Verbindung mit Port 801 auf dem lokalen Computer herstellen
            tcClient.Connect(851);

            hConnect = new int[7];

            try
            {
                hConnect[0] = tcClient.AddDeviceNotification("MAIN.boolVal", dataStream, 0, 1, AdsTransMode.OnChange, 100, 0, tbBool);
                hConnect[1] = tcClient.AddDeviceNotification("MAIN.intVal", dataStream, 1, 2, AdsTransMode.OnChange, 100, 0, tbInt);
                hConnect[2] = tcClient.AddDeviceNotification("MAIN.dintVal", dataStream, 3, 4, AdsTransMode.OnChange, 100, 0, tbDInt);
                hConnect[3] = tcClient.AddDeviceNotification("MAIN.sintVal", dataStream, 7, 1, AdsTransMode.OnChange, 100, 0, tbSint);
                hConnect[4] = tcClient.AddDeviceNotification("MAIN.lrealVal", dataStream, 8, 8, AdsTransMode.OnChange, 100, 0, tbLreal);
                hConnect[5] = tcClient.AddDeviceNotification("MAIN.realVal", dataStream, 16, 4, AdsTransMode.OnChange, 100, 0, tbReal);
                hConnect[6] = tcClient.AddDeviceNotification("MAIN.stringVal", dataStream, 20, 11, AdsTransMode.OnChange, 100, 0, tbString);

                tcClient.AdsNotification += new AdsNotificationEventHandler(OnNotification);
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
            }
        }

        private void OnNotification(object sender, AdsNotificationEventArgs e)
        {
            DateTime time = DateTime.FromFileTime(e.TimeStamp);
            e.DataStream.Position = e.Offset;
            string strValue = "";

            if (e.NotificationHandle == hConnect[0])
                strValue = binRead.ReadBoolean().ToString();
            else if (e.NotificationHandle == hConnect[1])
                strValue = binRead.ReadInt16().ToString();
            else if (e.NotificationHandle == hConnect[2])
                strValue = binRead.ReadInt32().ToString();
            else if (e.NotificationHandle == hConnect[3])
                strValue = binRead.ReadSByte().ToString();
            else if (e.NotificationHandle == hConnect[4])
                strValue = binRead.ReadDouble().ToString();
            else if (e.NotificationHandle == hConnect[5])
                strValue = binRead.ReadSingle().ToString();
            else if (e.NotificationHandle == hConnect[6])
            {
                strValue = new String(binRead.ReadChars(11));
            }

            ((TextBox)e.UserData).Text = String.Format("DateTime: {0},{1}ms; {2}", time, time.Millisecond, strValue);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                for (int i = 0; i < 7; i++)
                {
                    tcClient.DeleteDeviceNotification(hConnect[i]);
                }
                tcClient.Dispose();
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
            }
        }
    }
}
