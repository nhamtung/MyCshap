/* Reference
 * PLC program

PROGRAM MAIN
VAR
  PLCVar : ARRAY [0..99] OF INT;
  Index: BYTE;
END_VAR

FOR Index := 0 TO 99 DO
  PLCVar[Index] := 3500 + INDEX;
END_FOR

https://infosys.beckhoff.com/english.php?content=../content/1033/tcsample/html/tcsample_intro.htm&id=2105283098444985027

*/


using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using TwinCAT.Ads;

namespace AccessArrayPlc
{
    public partial class Form1 : Form
    {
        private int hVar;
        private TcAdsClient tcClient;

        public Form1()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            tcClient = new TcAdsClient();
            tcClient.Connect("127.0.0.1.1.1", 851);

            try
            {
                hVar = tcClient.CreateVariableHandle("MAIN.PLCVar");
            }
            catch (Exception err)
            {
                Debug.WriteLine("Error Form load: " + err.Message);
            }
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            try
            {
                AdsStream dataStream = new AdsStream(100 * 2);
                BinaryReader binRead = new BinaryReader(dataStream);

                //Array komplett auslesen			
                tcClient.Read(hVar, dataStream);

                listBoxArray.Items.Clear();
                dataStream.Position = 0;
                for (int i = 0; i < 100; i++)
                {
                    listBoxArray.Items.Add(binRead.ReadInt16().ToString());
                }
            }
            catch (Exception err)
            {
                Debug.WriteLine("Error Read: " + err.Message);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Resourcen wieder freigeben
            try
            {
                tcClient.DeleteVariableHandle(hVar);
            }
            catch (Exception err)
            {
                Debug.WriteLine("Error Form Colsing: " + err.Message);
            }
            tcClient.Dispose();
        }
    }
}
