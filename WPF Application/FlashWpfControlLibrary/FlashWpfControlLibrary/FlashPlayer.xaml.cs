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

namespace FlashWpfControlLibrary
{
    /// <summary>
    /// Interaction logic for FlashPlayer.xaml
    /// </summary>
    public partial class FlashPlayer : UserControl
    {
        public Uri Source { get; set; }
        public FlashPlayer()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
