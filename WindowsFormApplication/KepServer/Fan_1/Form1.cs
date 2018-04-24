using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OPCAutomation;  // dùng thư viện OPCautomation
// using System.Collections.Generic;

namespace Fan_1
{
    public partial class Form1 : Form
    {
        public static int item = 0;

        // tạo sever và kết nối. Copy đoạn này cũng được rồi hiểu dần.
        public OPCAutomation.OPCServer AnOPCServer;
        public OPCAutomation.OPCServer ConnectedOPCServer;
        public OPCAutomation.OPCGroups ConnectedServerGroup;
        public OPCAutomation.OPCGroup ConnectedGroup;

        public string Groupname;

        int ItemCount;
        Array OPCItemIDs = Array.CreateInstance(typeof(string), 10);
        Array ItemServerHandles = Array.CreateInstance(typeof(Int32), 10);
        Array ItemServerErrors = Array.CreateInstance(typeof(Int32), 10);
        Array ClientHandles = Array.CreateInstance(typeof(Int32), 10);
        Array RequestedDataTypes = Array.CreateInstance(typeof(Int16), 10);
        Array AccessPaths = Array.CreateInstance(typeof(string), 10);
        Array WriteItems = Array.CreateInstance(typeof(string), 10);

        public object OpcSystemsData { get; private set; }
        public object ConnectedOPCGroup { get; private set; }
        public object Simulater { get; private set; }
        public object TextBox3 { get; private set; }



        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            string IOServer = "Kepware.KEPServerEX.V4";  // phiên bản opc kepwware cần kết nối.
            string IOGroup = "OPCGroup1";
            //Create a new OPC Server object
            ConnectedOPCServer = new OPCAutomation.OPCServer();      //
                                                                     //Attempt to connect with the server
                                                                     // ConnectedOPCServer.Connect(labelOPC.Text);
            ConnectedOPCServer.Connect(IOServer, "");
            ConnectedGroup = ConnectedOPCServer.OPCGroups.Add(IOGroup);
            ConnectedGroup.DataChange += new DIOPCGroupEvent_DataChangeEventHandler(ObjOPCGroup_DataChange);
            ConnectedGroup.UpdateRate = 10;
            ConnectedGroup.IsSubscribed = ConnectedGroup.IsActive;

            pictureBox1.Visible = true;   // hiển thị ảnh động cơ khi ấn nút connect
                                          // lấy giá trị Tag từ OPC lên sever để tạo giao diện
            ItemCount = 3;
            OPCItemIDs.SetValue("Channel_1.Device_1.Tag_1", 1);
            ClientHandles.SetValue(1, 1);
            OPCItemIDs.SetValue("Channel_1.Device_1.Tag_2", 2);
            ClientHandles.SetValue(2, 2);
            OPCItemIDs.SetValue("Channel_1.Device_1.Tag_3", 3);
            ClientHandles.SetValue(3, 3);
            //'Set the desire active state for the Items " đây là đoạn kết nối mình cứ thế thêm vào thôi"
            ConnectedGroup.OPCItems.DefaultIsActive = true;
            ConnectedGroup.OPCItems.AddItems(ItemCount, ref OPCItemIDs, ref ClientHandles, out ItemServerHandles, out ItemServerErrors, RequestedDataTypes, AccessPaths);

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.ToString());
            //}
        }

        private void Btn_Connect_Click(object sender, EventArgs e)
        {
            ////try
            ////{
            //// 


            //string IOServer = "Kepware.KEPServerEX.V4";  // phiên bản opc kepwware cần kết nối.
            //string IOGroup = "OPCGroup1";
            ////Create a new OPC Server object
            //ConnectedOPCServer = new OPCAutomation.OPCServer();      //
            //                                                         //Attempt to connect with the server
            //                                                         // ConnectedOPCServer.Connect(labelOPC.Text);
            //ConnectedOPCServer.Connect(IOServer, "");
            //ConnectedGroup = ConnectedOPCServer.OPCGroups.Add(IOGroup);
            //ConnectedGroup.DataChange += new DIOPCGroupEvent_DataChangeEventHandler(ObjOPCGroup_DataChange);
            //ConnectedGroup.UpdateRate = 10;
            //ConnectedGroup.IsSubscribed = ConnectedGroup.IsActive;

            //pictureBox1.Visible = true;   // hiển thị ảnh động cơ khi ấn nút connect
            //                              // lấy giá trị Tag từ OPC lên sever để tạo giao diện
            //ItemCount = 3;
            //OPCItemIDs.SetValue("Channel_1.Device_1.Tag_1", 1);
            //ClientHandles.SetValue(1, 1);
            //OPCItemIDs.SetValue("Channel_1.Device_1.Tag_2", 2);
            //ClientHandles.SetValue(2, 2);
            //OPCItemIDs.SetValue("Channel_1.Device_1.Tag_3", 3);
            //ClientHandles.SetValue(3, 3);
            ////'Set the desire active state for the Items " đây là đoạn kết nối mình cứ thế thêm vào thôi"
            //ConnectedGroup.OPCItems.DefaultIsActive = true;
            //ConnectedGroup.OPCItems.AddItems(ItemCount, ref OPCItemIDs, ref ClientHandles, out ItemServerHandles, out ItemServerErrors, RequestedDataTypes, AccessPaths);

            ////}
            ////catch (Exception ex)
            ////{
            ////    MessageBox.Show(ex.ToString());
            ////}

        }

        private void Btn_Disconnect_Click(object sender, EventArgs e)
        {
            ConnectedOPCServer.Disconnect();  // đây là disconnect sevr khi mình ấn nút Disconnect
            pictureBox1.Visible = false;     // khi ấn disconnect thì bức ảnh động cơ sẽ k dc hiển thị
        }

        //   public  Dictionary<Color, string> colorStrings = new Dictionary<Color, string>();


        // dưới đây là đoạn code để đưa giá trị vào ID để hiển thị hình ảnh.
        private void ObjOPCGroup_DataChange(int TransactionID, int NumItems, ref Array ClientHandles, ref Array ItemValues, ref Array Qualities, ref Array TimeStamps)
        {



            //try
            //{

            // int clientID;
            for (int i = 1; i <= NumItems; i++)
            {


                if (Convert.ToInt32(ClientHandles.GetValue(i)) == 1)
                {
                    form3.textBox1.Text = ItemValues.GetValue(i).ToString();

                    textBox1.Text = ItemValues.GetValue(i).ToString();
                    form2.textBox1.Text = ItemValues.GetValue(i).ToString();

                    textBox1.Text = ItemValues.GetValue(i).ToString();



                    if ((Convert.ToInt32(ItemValues.GetValue(i)) == 1))
                    {



                        pictureBox1.Image = new Bitmap(@"E:\18. Learn VS2015\Fan_1\Fan_1\Resources\1h9orm.gif");
                    }


                    else
                    {
                        pictureBox1.Image = new Bitmap(@"E:\18. Learn VS2015\Fan_1\Fan_1\Resources\Stop.png");

                    }
                    //if ((Convert.ToInt32(ItemValues.GetValue(i)) == 2))
                }

                //    }
            }
            //}
            //catch (Exception ex)
            //{
            //   MessageBox.Show(ex.ToString());
            /////// }
        }

        private void Btn_Start_Click(object sender, EventArgs e)
        {

            // nút ấn start để thêm giá trị vào trong ID

            //try
            //{
            OPCItem newOPC = ConnectedGroup.OPCItems.AddItem("Channel_1.Device_1.Tag_1", 1);
            newOPC.Write(Convert.ToInt16(1));
            // item = 1;
           
            //}
            //catch
            //{
            //    MessageBox.Show("No Connect");
            //}



        }
        //public Dictionary<string, ITag> _Tags = new Dictionary<string, ITag>()
    
        //Itag{
        //      opcitem;
        //      tagname;
        //     clientID;
        //      value;
        //      timestamp;
        //      setvalue();
        //     }
    

        //
        //public Dictionary<string, ITag> _tags = new Dictionary<string, ITag>();
        //khai bao tag kieu nay
        //lay gia tri thì tag.value là xong
        //ghi xuong thì cũng vạy thôi
        //tag.write(123);
        //Itag{
        //      opcitem;
        //      tagname;
        //      clientID;
        //      value;
        //      timestamp;
        //      setvalue();
        //     }
        //_tags: key là tagname, itag là cai itag kia
        //cho opc update
        //private void ObjOPCGroup_DataChange(int TransactionID, int NumItems, ref Array ClientHandles, ref Array ItemValues, ref Array Qualities, ref Array TimeStamps)
        //{
        //try
        //{

        // int clientID;
        //for (int i = 1; i <= NumItems; i++)
        //{
        //      List<ITag> itag = _tags.Where(p => p.Value.clientID == ClientHandles.GetValue(i)).Select(kvp => kvp.Value).ToList();
        //foreach(Itag a in itag){a.setvalue(ItemValues[i])}
        //}
        //}
        //đại khái là như thế

        private void Btn_Stops_Click(object sender, EventArgs e)
        {
            //  /      //////
            //try
            //{
               // kiểm tra connect và tạo OPC chưa.
                OPCItem newOPC = ConnectedGroup.OPCItems.AddItem("Channel_1.Device_1.Tag_1", 1);
                newOPC.Write(Convert.ToInt16(0));

            //}
            //catch
            //{
            //                    MessageBox.Show("No Connect");
            //}
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
         
        }

        private void Btn_Start_KeyPress(object sender, KeyPressEventArgs e)
        {
        }
        Form2 form2 = new Form2();
        Form3 form3 = new Form3();
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();


            form2.ShowDialog();
            this.Opacity = 0;
        }

        private void Bt_Write_Click(object sender, EventArgs e)
        {
            //try
            //{

                OPCItem newOPC = ConnectedGroup.OPCItems.AddItem("Channel_1.Device_1.Tag_2", 2);

                newOPC.Write(Convert.ToInt16(Tb_Write.Text));

           // }
            //catch
            //{
             //   MessageBox.Show("No Connect");
            //}
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();


            form3.ShowDialog();
            this.Opacity = 1;

        }

        private void Tb_Write_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
