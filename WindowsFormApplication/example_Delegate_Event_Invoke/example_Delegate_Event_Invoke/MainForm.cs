using System;
using System.Windows.Forms;
using static Devices.Sensor;
using Frameworks;
using System.Collections.Generic;

/// <summary>
/// 
/// </summary>
namespace example_Delegate_Event_Invoke
{
    public partial class MainForm : Form
    {
        RoboFrameworks frameworks;
        CheckBox[] cbSensor;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            cbSensor = new CheckBox[] { null, cbSensor1, cbSensor2 };
            EnableCheckBox(false);
        }
        private void EnableCheckBox(bool state)
        {
            foreach (CheckBox cb in cbSensor)
            {
                if (cb != null)
                    cb.Enabled = state;
            }
        }

        private void OnSensorChanged(int value)
        {
            if(this.IsDisposed)
            {
                return; }
            Invoke((MethodInvoker)delegate
            {
                try
                {
                    for (byte i = 1; i < cbSensor.Length; i++)
                    {
                        cbSensor[i].Text = "S" + i + ": " + value;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            });
        }


        private void btnStart_Click(object sender, EventArgs e)
        {
            frameworks = RoboFrameworks.getInstance();
            EnableCheckBox(true);
        }

        private void cbSensorChanged(CheckBox cbSensor, byte id)
        {
            if(cbSensor.Checked == true)
            {
                frameworks.AddSensor(id);
                frameworks.CreateListSensor(id);
            }
            else
            {
                frameworks.RemoveSensor(id);
            }
            frameworks.SwitchSensor((OnSensorChanged)OnSensorChanged);
            foreach(var sensor in frameworks.listSensor)
            {
                sensor.changeHandler += OnSensorChanged;
            }
        }

        private void cbSensor1_CheckedChanged(object sender, EventArgs e)
        {
            cbSensorChanged(cbSensor1, 1);
        }
        private void cbSensor2_CheckedChanged(object sender, EventArgs e)
        {
            cbSensorChanged(cbSensor2, 2);
        }
    }
}
