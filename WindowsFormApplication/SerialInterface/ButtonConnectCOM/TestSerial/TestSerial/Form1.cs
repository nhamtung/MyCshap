using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vn.Ntq.RoboFW.Controllers;

namespace TestSerial
{
    public partial class ConnectCOM : Form
    {
        RoboController controller;
        public ConnectCOM()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (controller != null)
            {
                controller.Stop();
            }
            else
            {
                controller = RoboController.getInstance();
            }
            controller.Start(OnStateChange);
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            controller?.Stop();
        }
        private void OnStateChange(RoboState state)  //Hiển thị trạng thái của state lên Form
        {
            try
            {
                this.Invoke((MethodInvoker)delegate
                {
                    string status = state.ToString();
                    switch (state)
                    {
                        case RoboState.Initializing:
                            btnStart.Enabled = false;
                            status += ": Connecting to Robot ...";
                            break;
                        case RoboState.Ready:
                            EnableButton(true);
                            string portName = controller.PortName;
                            status += controller.GetConnectionStatus();
                            break;
                        case RoboState.Error:
                            status += ": Cannot connect to Robot! Retry...";
                            break;
                        case RoboState.Off:
                            EnableButton(false);
                            break;
                    }
                    label1.Text = status;
                });
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
        }
        private void EnableButton(bool ready)
        {
            btnStart.Enabled = !ready;
            btnStop.Enabled = ready;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            EnableButton(false);
        }
    }
}
