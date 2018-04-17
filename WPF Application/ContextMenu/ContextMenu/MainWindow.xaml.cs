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

namespace ContextMenu
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

        private void mItem_Bold_OnChecked(object sender, RoutedEventArgs e)
        {
            txt_Message.FontWeight = FontWeights.Bold;
        }

        private void mItem_Bold_Unchecked(object sender, RoutedEventArgs e)
        {
            txt_Message.FontWeight = FontWeights.Normal;
        }

        private void mItem_Italic_OnChecked(object sender, RoutedEventArgs e)
        {
            txt_Message.FontStyle = FontStyles.Italic;
        }

        private void mItem_Italic_OnUnchecked(object sender, RoutedEventArgs e)
        {
            txt_Message.FontStyle = FontStyles.Normal;
        }

        private void mItem_20pt_Checked(object sender, RoutedEventArgs e)
        {
            txt_Message.FontSize = 20;
        }

        private void mItem_15pt_Checked(object sender, RoutedEventArgs e)
        {
            txt_Message.FontSize = 15;
        }

        private void mItem_10pt_Checked(object sender, RoutedEventArgs e)
        {
            txt_Message.FontSize = 10;
        }
    }
}
