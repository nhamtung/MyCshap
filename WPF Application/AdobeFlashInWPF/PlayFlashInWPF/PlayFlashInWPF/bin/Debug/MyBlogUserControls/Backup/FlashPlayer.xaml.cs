//WPF Flash Player User Control
//written by Janiv Ratson
//September 20, 2009 , 15:28:23

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Forms.Integration;

namespace MyBlogUserControls
{
    /// <summary>
    /// Interaction logic for FlashPlayer.xaml
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
                        
            //the Windows Forms Host hosts the Flash Player
            host.Child = player;

            //the WPF Grid hosts the Windows Forms Host
            FlashPlayerGrid.Children.Add(host);

            //set size
            player.Width = (int)Width;
            player.Height = (int)Height;

            //load & play the movie
            player.LoadMovie(Source.AbsoluteUri);
            player.Play();
        }
    }
}
