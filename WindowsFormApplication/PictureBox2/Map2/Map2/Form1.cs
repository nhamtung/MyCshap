using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Map2
{
    public partial class Form1 : Form
    {
        float ratioX;
        float ratioY;
        float mapOriginalX;
        float mapOriginalY;

        Bitmap mapZoom;
        Bitmap overViewMap;

        int posPictureX = 0;
        int posPictureY = 0;
        private const int MOVE_PICTURE = 30;

        public Form1()
        {
            InitializeComponent();
            overViewMap = (Bitmap)Properties.Resources.Map.Clone();

            ratioX = (float)(Properties.Resources.MapZoom.Width / 46.2);
            ratioY = (float)(Properties.Resources.MapZoom.Height / 19.685);
            mapOriginalX = (float)(16.78 * ratioX);
            mapOriginalY = (float)(9.56 * ratioY);
        }

        private void btnZone_Click(object sender, EventArgs e)
        {
            mapZoom = (Bitmap)Properties.Resources.MapZoom.Clone();
            if ((comboBoxZone.Text == "OriginToVip") || (comboBoxZone.Text == "VipToOrigin"))
            {
                DisplayMapOriginVIP();
            }
            else if ((comboBoxZone.Text == "OriginToFuji") || (comboBoxZone.Text == "FujiToOrigin"))
            {
                DisplayMapOriginFuji();
            }
            else
            {
                MessageBox.Show("Choose the zone!");
            }
        }

        private void DisplayMapOriginVIP()
        {
            posPictureX = 0;
            posPictureY = 300;

            var g = Graphics.FromImage(mapZoom);
            g.DrawEllipse(new Pen(Color.Red, 4f), mapOriginalX - 2, mapOriginalY - 2, 4, 4);   //goc toa do
            
            pictureBoxMap.Image = mapZoom.Clone(new Rectangle(posPictureX, posPictureY, pictureBoxMap.Width, pictureBoxMap.Height), Properties.Resources.MapZoom.PixelFormat);
        }
        private void DisplayMapOriginFuji()
        {
            posPictureX = 530;
            posPictureY = 300;

            var g = Graphics.FromImage(mapZoom);
            g.DrawEllipse(new Pen(Color.Red, 4f), mapOriginalX - 2, mapOriginalY - 2, 4, 4);   //goc toa do

            pictureBoxMap.Image = mapZoom.Clone(new Rectangle(posPictureX, posPictureY, pictureBoxMap.Width, pictureBoxMap.Height), Properties.Resources.MapZoom.PixelFormat);
        }

        private void btnOverView_Click(object sender, EventArgs e)
        {
            overViewMap = (Bitmap)Properties.Resources.Map.Clone();
            OverViewMap();
            comboBoxZone.Text = null;
        }
        private void OverViewMap()
        {
            posPictureX = 0;
            posPictureY = 0;
            var g = Graphics.FromImage(overViewMap);
            g.DrawEllipse(new Pen(Color.Red, 4f), mapOriginalX - 2, mapOriginalY - 2, 4, 4);
            pictureBoxMap.Image = overViewMap.Clone(new Rectangle(posPictureX, posPictureY, Properties.Resources.Map.Width, Properties.Resources.Map.Height), Properties.Resources.Map.PixelFormat);
        }

        private void pictureBoxMap_MouseClick(object sender, MouseEventArgs e)
        {
            if ((comboBoxZone.Text == "OriginToVip") || (comboBoxZone.Text == "VipToOrigin"))
            {
                var g = Graphics.FromImage(mapZoom);
                g.DrawEllipse(new Pen(Color.Green, 4f), e.X + posPictureX, e.Y + posPictureY, 4, 4);

                pictureBoxMap.Image = mapZoom.Clone(new Rectangle(posPictureX, posPictureY, pictureBoxMap.Width, pictureBoxMap.Height), Properties.Resources.MapZoom.PixelFormat);
            }
            else if ((comboBoxZone.Text == "OriginToFuji") || (comboBoxZone.Text == "FujiToOrigin"))
            {
                var g = Graphics.FromImage(mapZoom);
                g.DrawEllipse(new Pen(Color.Green, 4f), e.X + posPictureX, e.Y + posPictureY, 4, 4);

                pictureBoxMap.Image = mapZoom.Clone(new Rectangle(posPictureX, posPictureY, pictureBoxMap.Width, pictureBoxMap.Height), Properties.Resources.MapZoom.PixelFormat);
            }
            else
            {
                posPictureX = 0;
                posPictureY = 0;

                var g = Graphics.FromImage(overViewMap);
                g.DrawEllipse(new Pen(Color.Green, 4f), (e.X * Properties.Resources.Map.Width) / pictureBoxMap.Width, (e.Y * Properties.Resources.Map.Height) / pictureBoxMap.Height, 4, 4);

                pictureBoxMap.Image = overViewMap.Clone(new Rectangle(posPictureX, posPictureY, Properties.Resources.Map.Width, Properties.Resources.Map.Height), Properties.Resources.Map.PixelFormat);//*/
            }//*/
        }

        private void pictureBoxMap_MouseMove(object sender, MouseEventArgs e)
        {
 /*           posPictureX = 0;
            posPictureY = 300;

            var g = Graphics.FromImage(mapOriginToVIP);
            g.DrawEllipse(new Pen(Color.Yellow, 4f), (e.X * Properties.Resources.MapOriginToVIP.Width) / pictureBoxMap.Width, (e.Y * Properties.Resources.MapOriginToVIP.Height) / pictureBoxMap.Height, 4, 4);

            pictureBoxMap.Image = mapOriginToVIP.Clone(new Rectangle(posPictureX, posPictureY, pictureBoxMap.Width, pictureBoxMap.Height), Properties.Resources.MapOriginToVIP.PixelFormat);
    //*/    }




/// <summary>
/// ///////////////////
/// </summary>
        private void MovePictureUp()
        {
            if (posPictureY > MOVE_PICTURE)
            {
                posPictureY -= MOVE_PICTURE;
            }
            else
            {
                posPictureY = 0;
            }
        }
        private void MovePictureDown()
        {
            if (posPictureY + MOVE_PICTURE + pictureBoxMap.Height > Properties.Resources.MapZoom.Height)
            {
                posPictureY = Properties.Resources.MapZoom.Height - pictureBoxMap.Height;
            }
            else
            {
                posPictureY += MOVE_PICTURE;
            }
        }
        private void MovePictureRight()
        {
            if (posPictureX + MOVE_PICTURE + pictureBoxMap.Width > Properties.Resources.MapZoom.Width)
            {
                posPictureX = Properties.Resources.MapZoom.Width - pictureBoxMap.Width;
            }
            else
            {
                posPictureX += MOVE_PICTURE;
            }
        }
        private void MovePictureLeft()
        {
            if (posPictureX > MOVE_PICTURE)
            {
                posPictureX -= MOVE_PICTURE;
            }
            else
            {
                posPictureX = 0;
            }
        }

        private void btnMapUp_Click(object sender, EventArgs e)
        {
            MovePictureUp();
            pictureBoxMap.Image = mapZoom.Clone(new Rectangle(posPictureX, posPictureY, pictureBoxMap.Width, pictureBoxMap.Height), Properties.Resources.MapZoom.PixelFormat);
        }
        private void btnMapRight_Click(object sender, EventArgs e)
        {
            MovePictureRight();
            pictureBoxMap.Image = mapZoom.Clone(new Rectangle(posPictureX, posPictureY, pictureBoxMap.Width, pictureBoxMap.Height), Properties.Resources.MapZoom.PixelFormat);
        }
        private void btnMapDown_Click(object sender, EventArgs e)
        {
            MovePictureDown();
            pictureBoxMap.Image = mapZoom.Clone(new Rectangle(posPictureX, posPictureY, pictureBoxMap.Width, pictureBoxMap.Height), Properties.Resources.MapZoom.PixelFormat);
        }
        private void btnMapLeft_Click(object sender, EventArgs e)
        {
            MovePictureLeft();
            pictureBoxMap.Image = mapZoom.Clone(new Rectangle(posPictureX, posPictureY, pictureBoxMap.Width, pictureBoxMap.Height), Properties.Resources.MapZoom.PixelFormat);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Up:
                    MovePictureUp();
                    break;
                case Keys.Down:
                    MovePictureDown();
                    break;
                case Keys.Left:
                    MovePictureLeft();
                    break;
                case Keys.Right:
                    MovePictureRight();
                    break;
            }
            if (keyData == Keys.Up || keyData == Keys.Down || keyData == Keys.Left || keyData == Keys.Right)
            {
                pictureBoxMap.Image = mapZoom.Clone(new Rectangle(posPictureX, posPictureY, pictureBoxMap.Width, pictureBoxMap.Height), Properties.Resources.MapZoom.PixelFormat);
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }//*/
    }
}
