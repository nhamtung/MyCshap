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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BindingControlWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DistanceSensor sensor1;
        private DistanceSensor sensor2;
        public MainWindow()
        {
            InitializeComponent();
            sensor1 = new DistanceSensor();
            sensor2 = new DistanceSensor();
            SensorValue.DataContext = sensor1;
            label.DataContext = sensor2;
        }

        private void checkBox_Checked(object sender, RoutedEventArgs e)
        {
            sensor1.Start();
        }

        private void checkBox_Unchecked(object sender, RoutedEventArgs e)
        {
            sensor1.Stop();
        }

        private void checkBox1_Checked(object sender, RoutedEventArgs e)
        {
            sensor2.Start();
        }

        private void checkBox1_Unchecked(object sender, RoutedEventArgs e)
        {
            sensor2.Stop();
        }
    }
}
