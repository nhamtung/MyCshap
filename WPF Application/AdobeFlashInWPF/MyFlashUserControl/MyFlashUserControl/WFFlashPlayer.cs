using System.Windows.Forms;

namespace MyFlashUserControl
{
    public partial class WFFlashPlayer : UserControl
    {
        public WFFlashPlayer()
        {
            InitializeComponent();
        }

        public new int Width
        {
            get { return axShockwaveFlash.Width; }
            set { axShockwaveFlash.Width = value; }
        }

        public new int Height
        {
            get { return axShockwaveFlash.Height; }
            set { axShockwaveFlash.Height = value; }
        }

        public void LoadMovie(string strPath)
        {
            axShockwaveFlash.LoadMovie(0, strPath);
        }

        public void Play()
        {
            axShockwaveFlash.Play();
        }

        public void Stop()
        {
            axShockwaveFlash.Stop();
        }
    }
}
