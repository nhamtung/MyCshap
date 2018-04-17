using System;
using System.Windows.Forms;

using log4net;
using log4net.Config;

namespace Log4net
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //https://www.youtube.com/watch?v=LD7PNKEW8cc
            XmlConfigurator.Configure();
            BasicConfigurator.Configure();
            ILog log = log4net.LogManager.GetLogger("Form1");

            log.Debug("Debug");
            log.Info("Info");
            log.Warn("Warn");
            log.Error("Error");
        }
    }
}
