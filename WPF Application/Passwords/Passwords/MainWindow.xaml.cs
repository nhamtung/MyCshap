using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Passwords
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string _UserName = "nhamtung";
        private string _Password = "12051994";

        private bool _hidePassword = true;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if(CheckInformation())
                MessageBox.Show("Welcome to heaven!");
        }

        private bool CheckInformation()
        {
            if (txtBoxUser.Text != _UserName)
            {
                MessageBox.Show("Wrong Username!");
                txtBoxUser.Text = "";
                return false;
            }
            if (txtPasswordBox.Password != _Password)
            {
                MessageBox.Show("Wrong Passwords!");
                txtPasswordBox.Password = "";
                return false;
            }
            return true;
        }

        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            _hidePassword = !_hidePassword;
            ChangeHidePassword(_hidePassword);
        }

        private void ChangeHidePassword(bool state)
        {
            txtBoxPassword.Text = txtPasswordBox.Password;
            txtPasswordBox.Visibility = state ? Visibility.Visible : Visibility.Hidden;
        }
    }
}
