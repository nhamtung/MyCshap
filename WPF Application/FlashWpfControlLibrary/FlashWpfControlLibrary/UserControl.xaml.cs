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
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class FlashPlayer : UserControl
    {
        public FlashPlayer()
        {
            InitializeComponent();
        }
        public Uri Source { get; set; }
        private void FlashPlayer_Loaded(object sender, RoutedEventArgs e)
        {
            WindowsFormsHost host = new WindowsFormsHost();
            WFFlashPlayer player = new WFFlashPlayer();
            
            host.Child = player;  //the Windows Forms Host hosts the Flash Player
            
            FlashPlayerGrid.Children.Add(host);  //the WPF Grid hosts the Windows Forms Host
            
            player.Width = (int)Width;  //set size

            player.Height = (int)Height;
            
            player.LoadMovie(Source.AbsoluteUri);  //load & play the movie

            player.Play();

        }

    }
}
