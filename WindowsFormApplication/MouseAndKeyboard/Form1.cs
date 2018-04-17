using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using EZDefense;

namespace MouseAndKeyboard
{
    public partial class Form1 : Form
    {
        MouseKeyboardInput _mouseAndKeyboard = new MouseKeyboardInput();
        private Thread _checkMouseAndKeyboard;

        private bool _flagCheck { get; set; }
        public Form1()
        {
            InitializeComponent();

            //_checkMouseAndKeyboard = new Thread(CheckMouseAndKeyboard);
            //_checkMouseAndKeyboard.Start();

            _mouseAndKeyboard.InputReceive += Display;

        }

        private void Display()
        {
            label1.Text = "Event";
            _flagCheck = true;
            Debug.WriteLine("GetIdleTimer: " + _mouseAndKeyboard.GetIdleTime());
        }

        //private void CheckMouseAndKeyboard()
        //{
        //    while (true)
        //    {
        //        try
        //        {
        //            if (_flagCheck)
        //            {
        //                Thread.Sleep(3000);
        //                if (_flagCheck)
        //                {
        //                    Invoke((MethodInvoker) delegate
        //                    {
        //                        _flagCheck = false;
        //                        label1.Text = "Lam gi di";
        //                    });
        //                }
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show(ex.Message);
        //        }
        //    }
        //}
    }
}
