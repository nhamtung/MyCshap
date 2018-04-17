using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestInvoke
{
    public partial class Form1 : Form
    {
        private Sensor sensor;
        public Form1()
        {
            InitializeComponent();
            sensor = new Sensor();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                sensor.SensorValueChanged += SensorValueChangedHandle;
            }
            else
            {
                sensor.SensorValueChanged -= SensorValueChangedHandle;
            }
        }

        private void SensorValueChangedHandle(object sender, int value)
        {
            this.Invoke(new MethodInvoker(delegate
            {
                checkBox1.Text = "Sensor : " + value.ToString();
            }));
        }
    }
}
