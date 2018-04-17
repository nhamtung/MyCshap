using System;
using System.Windows.Forms;

namespace PlayVideoFile
{
    public partial class Form1 : Form
    {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click_1(object sender, EventArgs e)
        {
            openFileDialog.Filter = "(mp3,wav,mp4,mov,wmv,mpg)|*.mp3;*.wav;*.mp4;*.mov;*.wmv;*.mpg|all files|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
                axWindowsMediaPlayer1.URL = openFileDialog.FileName;
        }
    }
}
