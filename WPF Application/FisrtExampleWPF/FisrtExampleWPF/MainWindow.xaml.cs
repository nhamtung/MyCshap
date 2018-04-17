using System.Windows;

namespace FisrtExampleWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnHello_Click(object sender, RoutedEventArgs e)
        {
            //if (txbTextBox.Visibility == Visibility.Collapsed)
            //{
            //    txbTextBox.Visibility = Visibility.Visible;
            //}
            //else
            //{
            //    txbTextBox.Visibility = Visibility.Collapsed;
            //}

            //Remote.Visibility = Visibility.Collapsed;
            txbTextBox.Text = "Nhâm Tùng hello you!";
        }
    }
}
