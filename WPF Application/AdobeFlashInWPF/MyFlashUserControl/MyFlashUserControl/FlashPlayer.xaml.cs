using System;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms.Integration;

namespace MyFlashUserControl
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class FlashPlayer : UserControl
    {
        private static FlashPlayer instance = null;
        private Thread waitFlash;
        WFFlashPlayer player = new WFFlashPlayer();

        public FlashPlayer()
        {
            InitializeComponent();
        }
        public Uri Source { get; set; }

        public static FlashPlayer getInstance()
        {
            if (instance == null)
                instance = new FlashPlayer();
            return instance;
        }

        public bool flagStopFlash { get; set; }

        private void FlashPlayer_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {

            WindowsFormsHost host = new WindowsFormsHost();

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
            flagStopFlash = true;

            waitFlash = new Thread(StopFlash);
            waitFlash.Start();
        }

        private void StopFlash()
        {
            Thread.Sleep(4000);
            player.Stop();
            flagStopFlash = true;
        }
    }
}
