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

namespace ZoomImageWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            INIT();
        }

        private Point firstPoint = new Point();

        public void INIT()
        {
            imgKiosk.MouseLeftButtonDown += (ss, ee) =>
            {
                firstPoint = ee.GetPosition(this);
                imgKiosk.CaptureMouse();
            };

            //rotate image
            imgKiosk.MouseWheel += (ss, ee) =>
            {
                Matrix mat = imgKiosk.RenderTransform.Value;
                Point mouse = ee.GetPosition(imgKiosk);

                if (ee.RightButton == MouseButtonState.Pressed)
                {   //rotate image
                    if (ee.Delta > 0)
                        mat.RotateAtPrepend(2, mouse.X, mouse.Y);
                    else
                        mat.RotateAtPrepend(-2, mouse.X, mouse.Y);
                }
                else
                {   //Zoom image
                    if (ee.Delta > 0)
                        mat.ScaleAtPrepend(1.15, 1.15, mouse.X, mouse.Y);
                    else
                        mat.ScaleAtPrepend(1 / 1.15, 1 / 1.15, mouse.X, mouse.Y);
                }

                MatrixTransform mtf = new MatrixTransform(mat);
                imgKiosk.RenderTransform = mtf;
            };

            imgKiosk.MouseMove += (ss, ee) =>
            {   //Move Image
                if (ee.LeftButton == MouseButtonState.Pressed)
                {
                    Point temp = ee.GetPosition(this);
                    Point res = new Point(firstPoint.X - temp.X, firstPoint.Y - temp.Y);

                    Canvas.SetLeft(imgKiosk, Canvas.GetLeft(imgKiosk) - res.X);
                    Canvas.SetTop(imgKiosk, Canvas.GetTop(imgKiosk) - res.Y);

                    firstPoint = temp;
                }
            };

            imgKiosk.MouseUp += (ss, ee) => { imgKiosk.ReleaseMouseCapture(); };
        }
    }
}
