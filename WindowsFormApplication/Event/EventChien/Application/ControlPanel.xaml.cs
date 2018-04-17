using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using RobotManager;

namespace RecepApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class ControlPanel : Window
    {
        public ControlPanel()
        {
            InitializeComponent();
            robotManagement = new RobotManagement();
            robotManagement.OnChangeName += OnChangeName;
        }

        private void OnChangeName(string name)
        {
            txtName.Text = name;
        }

        private RobotManagement robotManagement;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            robotManagement.Config(txtEnterName.Text);
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            robotManagement.RobotSendToUi();
        }
    }
}
