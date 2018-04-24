
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Button
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ContextMenu contextMenu = new ContextMenu();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnButton_PreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            lab.Content = "PreviewMouseRightButtonDown";
            EstablishContextMenu();
        }

        private void EstablishContextMenu()
        {
            contextMenu.Items.Add("Del");
            contextMenu.Items.Add("Add");
        }

        private void btnButton_Click(object sender, RoutedEventArgs e)
        {
            lab.Content = "Click";
        }
    }
}
