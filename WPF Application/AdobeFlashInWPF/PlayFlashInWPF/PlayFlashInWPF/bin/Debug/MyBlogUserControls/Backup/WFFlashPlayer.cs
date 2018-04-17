//Windows Forms Flash Player User Control
//written by Janiv Ratson
//September 20, 2009 , 15:28:23

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MyBlogUserControls
{
    public partial class WFFlashPlayer : UserControl
    {
        public WFFlashPlayer()
        {
            InitializeComponent();
        }

        public new int Width 
        {
            get{ return axShockwaveFlash.Width; }
            set{ axShockwaveFlash.Width = value; }
        }

        public new int Height 
        {
            get{ return axShockwaveFlash.Height; }
            set{ axShockwaveFlash.Height = value; }
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
