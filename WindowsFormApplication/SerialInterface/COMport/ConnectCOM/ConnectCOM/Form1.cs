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

namespace ConnectCOM
{
    public partial class ConnectCOM : Form
    {
        RoboController controller;
        public ConnectCOM()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            controller = RoboController.getInstance();
            controller.Start();
        }
    }
}