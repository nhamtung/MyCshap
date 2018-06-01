/*PLC program

        TYPE TSimpleStruct :
        STRUCT
                lrealVal: LREAL := 1.23;
                dintVal1: DINT := 120000;
        END_STRUCT
        END_TYPE

        TYPE TComplexStruct :
        STRUCT
                intVal : INT:=1200;
                dintArr: ARRAY[0..3] OF DINT:= 1,2,3,4;
                boolVal: BOOL := FALSE;
                byteVal: BYTE:=10;
                stringVal : STRING(5) := 'hallo';
                simpleStruct1: TSimpleStruct;
        END_STRUCT
        END_TYPE

        PROGRAM MAIN
        VAR
                (*primitive Types*)
                Bool1:BOOL := FALSE;
                int1:INT := 30000;
                dint1:DINT:=125000;
                usint1:USINT:=200;
                real1:REAL:= 1.2;
                lreal1:LREAL:=3.5;
        
                (*string Types*)
                str1:STRING := 'this is a test string';
                str2:STRING(5) := 'hallo';
        
                (*struct Types*)
                complexStruct1 : TComplexStruct;
        END_VAR
 * 
 * https://infosys.beckhoff.com/english.php?content=../content/1033/tcsample/html/tcsample_intro.htm&id=2105283098444985027
 * 
 * Function: Read and Write variables of any type with the help of the ReadAny and WriteAny methods.
 */

using System;
using System.Collections;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using TwinCAT.Ads;

namespace ReadAndWriteVariableAnyType
{
    public partial class Form1 : Form
    {
        //PLC variable handles
        private int hdint1;
        private int hbool1;
        private int husint1;
        private int hlreal1;
        private int hstr1;
        private int hstr2;
        private int hcomplexStruct;
        private ArrayList notificationHandles;

        private TcAdsClient adsClient;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            adsClient = new TcAdsClient();
            notificationHandles = new ArrayList();
            try
            {
                adsClient.Connect(851);
                adsClient.AdsNotificationEx += new AdsNotificationExEventHandler(adsClient_AdsNotificationEx);
                btnDeleteNotifications.Enabled = false;
                //create handles for the PLC variables;
                hbool1 = adsClient.CreateVariableHandle("MAIN.bool1");
                hdint1 = adsClient.CreateVariableHandle("MAIN.dint1");
                husint1 = adsClient.CreateVariableHandle("MAIN.usint1");
                hlreal1 = adsClient.CreateVariableHandle("MAIN.lreal1");
                hstr1 = adsClient.CreateVariableHandle("MAIN.str1");
                hstr2 = adsClient.CreateVariableHandle("MAIN.str2");
                hcomplexStruct = adsClient.CreateVariableHandle("MAIN.ComplexStruct1");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            adsClient.Dispose();
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            try
            {
                //read by handle
                //the second parameter specifies the type of the variable
                tbDint1.Text = adsClient.ReadAny(hdint1, typeof(int)).ToString();
                tbUsint1.Text = adsClient.ReadAny(husint1, typeof(Byte)).ToString();
                tbBool1.Text = adsClient.ReadAny(hbool1, typeof(Boolean)).ToString();
                tblreal1.Text = adsClient.ReadAny(hlreal1, typeof(Double)).ToString();
                //with strings one has to additionally pass the number of characters
                //specified in the PLC project(default 80). 
                //This value is passed is an int array.             
                tbStr1.Text = adsClient.ReadAny(hstr1, typeof(String), new int[] { 80 }).ToString();
                tbStr2.Text = adsClient.ReadAny(hstr2, typeof(String), new int[] { 5 }).ToString();
                FillStructControls((ComplexStruct)adsClient.ReadAny(hcomplexStruct, typeof(ComplexStruct)));
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private void btnWrite_Click(object sender, EventArgs e)
        {
            try
            {
                //write by handle
                //the second parameter is the object to be written to the PLC variable
                adsClient.WriteAny(hdint1, int.Parse(tbDint1.Text));
                adsClient.WriteAny(husint1, Byte.Parse(tbUsint1.Text));
                adsClient.WriteAny(hbool1, Boolean.Parse(tbBool1.Text));
                adsClient.WriteAny(hlreal1, Double.Parse(tblreal1.Text));
                //with strings one has to additionally pass the number of characters
                //the variable has in the PLC(default 80).            
                adsClient.WriteAny(hstr1, tbStr1.Text, new int[] { 80 });
                adsClient.WriteAny(hstr2, tbStr2.Text, new int[] { 5 });
                adsClient.WriteAny(hcomplexStruct, GetStructFromControls());
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private void btnAddNotifications_Click(object sender, EventArgs e)
        {
            notificationHandles.Clear();
            try
            {
                //register notification            
                notificationHandles.Add(adsClient.AddDeviceNotificationEx("MAIN.dint1", AdsTransMode.OnChange, 100, 0, tbDint1, typeof(int)));
                notificationHandles.Add(adsClient.AddDeviceNotificationEx("MAIN.usint1", AdsTransMode.OnChange, 100, 0, tbUsint1, typeof(Byte)));
                notificationHandles.Add(adsClient.AddDeviceNotificationEx("MAIN.bool1", AdsTransMode.OnChange, 100, 0, tbBool1, typeof(Boolean)));
                notificationHandles.Add(adsClient.AddDeviceNotificationEx("MAIN.lreal1", AdsTransMode.OnChange, 100, 0, tblreal1, typeof(Double)));
                notificationHandles.Add(adsClient.AddDeviceNotificationEx("MAIN.str1", AdsTransMode.OnChange, 100, 0, tbStr1, typeof(String), new int[] { 80 }));
                notificationHandles.Add(adsClient.AddDeviceNotificationEx("MAIN.str2", AdsTransMode.OnChange, 100, 0, tbStr2, typeof(String), new int[] { 5 }));
                notificationHandles.Add(adsClient.AddDeviceNotificationEx("MAIN.complexStruct1", AdsTransMode.OnChange, 100, 0, tbDint1, typeof(ComplexStruct)));
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            btnDeleteNotifications.Enabled = true;
            btnAddNotifications.Enabled = false;
        }

        private void btnDeleteNotifications_Click(object sender, EventArgs e)
        {
            //delete registered notifications.
            try
            {
                foreach (int handle in notificationHandles)
                    adsClient.DeleteDeviceNotification(handle);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            notificationHandles.Clear();
            btnAddNotifications.Enabled = true;
            btnDeleteNotifications.Enabled = false;
        }
        private void adsClient_AdsNotificationEx(object sender, AdsNotificationExEventArgs e)
        {
            TextBox textBox = (TextBox)e.UserData;
            Type type = e.Value.GetType();
            if (type == typeof(string) || type.IsPrimitive)
                textBox.Text = e.Value.ToString();
            else if (type == typeof(ComplexStruct))
                FillStructControls((ComplexStruct)e.Value);
        }

        private void FillStructControls(ComplexStruct structure)
        {
            tbComplexStruct_IntVal.Text = structure.intVal.ToString();
            tbComplexStruct_dintArr.Text = String.Format("{0:d}, {1:d}, {2:d}, {3:d}", structure.dintArr[0],
                structure.dintArr[1], structure.dintArr[2], structure.dintArr[3]);
            tbComplexStruct_boolVal.Text = structure.boolVal.ToString();
            tbComplexStruct_ByteVal.Text = structure.byteVal.ToString();
            tbComplexStruct_stringVal.Text = structure.stringVal;
            tbComplexStruct_SimpleStruct1_lrealVal.Text = structure.simpleStruct1.lrealVal.ToString();
            tbComplexStruct_SimpleStruct_dintVal.Text = structure.simpleStruct1.dintVal1.ToString();
        }

        private ComplexStruct GetStructFromControls()
        {
            ComplexStruct structure = new ComplexStruct();
            String[] stringArr = tbComplexStruct_dintArr.Text.Split(new char[] { ',' });
            structure.intVal = short.Parse(tbComplexStruct_IntVal.Text);
            for (int i = 0; i < stringArr.Length; i++)
                structure.dintArr[i] = int.Parse(stringArr[i]);

            structure.boolVal = Boolean.Parse(tbComplexStruct_boolVal.Text);
            structure.byteVal = Byte.Parse(tbComplexStruct_ByteVal.Text);
            structure.stringVal = tbComplexStruct_stringVal.Text;
            structure.simpleStruct1.dintVal1 = int.Parse(tbComplexStruct_SimpleStruct_dintVal.Text);
            structure.simpleStruct1.lrealVal = double.Parse(tbComplexStruct_SimpleStruct1_lrealVal.Text);
            return structure;
        }
    }


    [StructLayout(LayoutKind.Sequential, Pack = 0)]
    public class SimpleStruct
    {
        public double lrealVal;
        public int dintVal1;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 0)]
    public class ComplexStruct
    {
        public short intVal;
        //specifies how .NET should marshal the array
        //SizeConst specifies the number of elements the array has.
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public int[] dintArr = new int[4];
        [MarshalAs(UnmanagedType.I1)]
        public bool boolVal;
        public byte byteVal;
        //specifies how .NET should marshal the string
        //SizeConst specifies the number of characters the string has.
        //'(inclusive the terminating null ). 
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 6)]
        public string stringVal = "";
        public SimpleStruct simpleStruct1 = new SimpleStruct();
    }
}
