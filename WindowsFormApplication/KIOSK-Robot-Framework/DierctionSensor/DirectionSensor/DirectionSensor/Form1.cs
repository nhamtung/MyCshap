using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Ports;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Vn.Ntq.RoboFW;
using Vn.Ntq.RoboFW.Controllers;
using Vn.Ntq.RoboFW.Response;
using Vn.Ntq.RoboFW.RoboCommunicator;
using Vn.Ntq.RoboFW.RoboCommunicator.IOs;
using Vn.Ntq.RoboFW.RoboCommunicator.Messages;
using Vn.Ntq.RoboFW.Sensors;

namespace DisrectionSensor
{
    public partial class Form1 : Form, IMessageListener
    {
        //IMessageTransporter messageTransporter3;
        RoboController controller;
        CheckBox[] cbSensors;
        public Form1()
        {
            InitializeComponent();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            cbSensors = new CheckBox[] { null, cbDirectionSensor };
            EnableButton(false);
        }
        public virtual void OnReceive(RoboMessage message)
        {
        }
        private void EnableButton(bool ready)  //Enable or Disable button
        {
            btnStart.Enabled = !ready;
            btnStop.Enabled = ready;
            foreach (CheckBox cb in cbSensors)
            {
                if (cb != null)
                {
                    cb.Enabled = ready;  //kích hoạt checkbox
                }
            }
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            controller?.Stop();
        }
        private void OnStateChange(RoboState state)  //Hiển thị trạng thái hoạt động lên Form
        {
            try
            {
                this.Invoke((MethodInvoker)delegate  //Invoke: đẩy hoạt động sang Form Thread
                {
                    string status = state.ToString();
                    switch (state)
                    {
                        case RoboState.Initializing:
                            btnStart.Enabled = false;  //tắt button Start
                            status += ": Connecting...";
                            break;
                        case RoboState.Ready:
                            EnableButton(true);  //gọi hàm bật các button trừ button Start
                            string portName = controller.PortName;  //khởi tạo biến portName bằng biến PortName trong RoboContrller
                            status += controller.GetConnectionStatus();  //gọi hàm GetConnectionStatus (trạng thái cổng COM đang kết nối)
                            break;
                        case RoboState.Error:
                            status += ": Not connect!";
                            break;
                        case RoboState.Off:
                            EnableButton(false);  //gọi hàm EnableButton() (tắt tất cả button trừ Start)
                            break;
                    }
                    label1.Text = status;  //hiển thị trang thái hoạt động lên lable6
                });
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (controller != null)  //kiem tra đối tượng controller đã được khởi tạo chưa
            {
                controller.Stop();
            }
            else  //nếu chưa được khởi tạo thì khởi tạo đối tượng controller trong class RobotContrller
            {
                controller = RoboController.getInstance();
            }
            controller.Start(OnStateChange);  //gọi hàm Start với tham biến là hàm OnStateChange
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            controller?.Stop();  //nếu đối tượng Controller đã được khởi tạo thì gọi hàm Stop trong StateController
        }

        SortedSet<byte> onSensorIds = new SortedSet<byte>();
        private void cbSensorChanged(CheckBox cbSensor, byte id) //Kiểm tra ID cảm biến
        {
            if (cbSensor.Checked)  //hàm trong system(kiểm tra đã check chưa)
            {
                onSensorIds.Add(id);  //onSensorIds là 1 đối tượng trong class SortedSet, gọi hàm Add với tham biến là id (thêm id vào list)
            }
            else
            {
                onSensorIds.Remove(id);  //nếu chưa check thì remove ID đó
            }
            SwitchSensor(onSensorIds);
        }
        private void OnDirectionChange(Dictionary<byte, int> angle)  //Hiển thị góc từng sesor lên Form
        {
            if (this.IsDisposed)
            {
                return;
            }
            Invoke((MethodInvoker)delegate
            {
                if (angle != null)
                {
                    for (byte i = 1; i < cbSensors.Length; i++)
                    {
                        if (angle.ContainsKey(i))
                        {
                            cbSensors[i].Text = "Angle = " + i + ": " + (angle[i]) * 0.01 + " degree";
                        }
                    }
                }
                else
                {
                    labSensorStatus.Text = "error";
                }
            });
        }
        private void SwitchSensor(SortedSet<byte> onSensorIds)
        {
            try
            {
                controller.SwitchDirectionSensor(onSensorIds);  //gọi hàm SwitchDistanceSensor với tham biến onSensorIds
                controller.RegisterDirectionChangeHandler(OnDirectionChange);
            }
            catch (ConnectionException ex)
            {
                labSensorStatus.Text = "connection error: " + ex.Message;
            }
        }

        private void cbDirectionSensor_CheckedChanged(object sender, EventArgs e)
        {
            cbSensorChanged(cbDirectionSensor, 1);
        }

    }
}
