using MyFlashUserControl;
using System.Threading;
using System.Windows;

namespace PlayFlashInWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static FlashPlayer flashPlayer = FlashPlayer.getInstance();
        private Thread checkFlash;

        public MainWindow()
        {
            InitializeComponent();

            checkFlash = new Thread(CheckFlash);
            checkFlash.Start();
        }

        private void CheckFlash()
        {
            while(flashPlayer.flagStopFlash != true) { }
            MessageBox.Show("Stop Flash");
        }

        private void btnClick_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Click Button");
        }
    }
}
