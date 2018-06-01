/*
 * PLC program

    TYPE PLCStruct
    STRUCT
      intVal : INT;
      dintVal    : DINT;
      byteVal    : SINT;
      lrealVal  : LREAL;
      realVal  : REAL;
    END_STRUCT
    END_TYPE

    PROGRAM MAIN
    VAR 
      PLCVar : PLCStruct;
    END_VAR
    
    https://infosys.beckhoff.com/english.php?content=../content/1033/tcsample/html/tcsample_intro.htm&id=2105283098444985027
 */

using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using TwinCAT.Ads;

namespace TransmittingStructurePlc
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
            tcClient.Connect(851);
            try
            {
                hVar = tcClient.CreateVariableHandle("MAIN.PLCVar");
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
            }
        }

        private void btnWrite_Click(object sender, EventArgs e)
        {
            var dataStream = new AdsStream(32);
            var binWrite = new BinaryWriter(dataStream);

            dataStream.Position = 0;
            try
            {
                // Adjust datastream.position for 8 byte-alignment
                binWrite.Write(short.Parse(tbInt.Text));
                dataStream.Position = 4;
                binWrite.Write(int.Parse(tbDint.Text));
                dataStream.Position = 8;
                binWrite.Write(byte.Parse(tbByte.Text));
                dataStream.Position = 16;
                binWrite.Write(double.Parse(tbLReal.Text));
                dataStream.Position = 24;
                binWrite.Write(float.Parse(tbReal.Text));

                tcClient.Write(hVar, dataStream);
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
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
                Debug.WriteLine(err.Message);
            }
            tcClient.Dispose();
        }
    }
}
