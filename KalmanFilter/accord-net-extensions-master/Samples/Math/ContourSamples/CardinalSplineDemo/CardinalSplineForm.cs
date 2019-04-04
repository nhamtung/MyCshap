#region Licence and Terms
// Accord.NET Extensions Framework
// https://github.com/dajuric/accord-net-extensions
//
// Copyright © Darko Jurić, 2014-2015 
// darko.juric2@gmail.com
//
//   This program is free software: you can redistribute it and/or modify
//   it under the terms of the GNU Lesser General Public License as published by
//   the Free Software Foundation, either version 3 of the License, or
//   (at your option) any later version.
//
//   This program is distributed in the hope that it will be useful,
//   but WITHOUT ANY WARRANTY; without even the implied warranty of
//   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//   GNU Lesser General Public License for more details.
// 
//   You should have received a copy of the GNU Lesser General Public License
//   along with this program.  If not, see <https://www.gnu.org/licenses/lgpl.txt>.
//
#endregion

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Accord.Extensions.Imaging;
using Accord.Extensions.Math.Geometry;
using DotImaging;
using DotImaging.Primitives2D;
using LineSegment2DF = AForge.Math.Geometry.LineSegment;

namespace CardinalSplineDemo
{
    public partial class CardinalSplineForm : Form
    {
        PointF[] modelPts = null;

        public CardinalSplineForm()
        {
            InitializeComponent();

            var resourceDir = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).FullName, "Resources");
            var pts = readCoordinates(Path.Combine(resourceDir, "handControlPoints.txt"));
            /*var pts = new PointF[] //rectangle
            {
                new PointF(0, 0),
                new PointF(0, 1),
                new PointF(1, 1),
                new PointF(1, 0)
            }.ToList(); 
            CardinalSpline.AddTensionPoints(pts); */

            modelPts = pts.Normalize().ToArray();

            timer.Enabled = true;
        }

        /// <summary>
        /// Read MATLAB text file. Two columns of Single values.
        /// </summary>
        private static IEnumerable<PointF> readCoordinates(string fileName)
        {
            using (TextReader txtReader = new StreamReader(fileName))
            {
                string line;
                while ((line = txtReader.ReadLine()) != null)
                {
                    var coord = line
                                .Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                                .Select(x => Single.Parse(x, System.Globalization.CultureInfo.InvariantCulture));

                    yield return new PointF
                    {
                        X = coord.First(),
                        Y = coord.Last()
                    };
                }
            }
        }

        #region Drawing

        private static void drawContour(IList<PointF> controlPoints, Bgr<byte>[,] image)
        {
            const float CONTOUR_TENSION = 0;

            /********************  contour and control points *********************/
            var pointIndices = CardinalSpline.GetEqualyDistributedPointIndices(controlPoints, CONTOUR_TENSION, 500);
            var points = CardinalSpline.InterpolateAt(controlPoints, CONTOUR_TENSION, pointIndices);

            var normals = new List<LineSegment2DF>();
            var normalIndices = CardinalSpline.GetEqualyDistributedPointIndices(controlPoints, CONTOUR_TENSION, 100);
            foreach (var idx in normalIndices)
            {
                var pt = CardinalSpline.InterpolateAt(controlPoints, CONTOUR_TENSION, idx);
                var normalDirection = CardinalSpline.NormalAt(controlPoints, CONTOUR_TENSION, idx);
                var orientation = (int)Angle.ToDegrees(System.Math.Atan2(normalDirection.Y, normalDirection.X));
                var normal = getLine(orientation, pt, 20);
                normals.Add(normal);
            }
            /********************  contour and control points *********************/

            image.Draw(points.Select(x=>x.Round()).ToArray(),
                       Bgr<byte>.Blue,
                       3);

            image.Draw(controlPoints.Select(x => new Circle(x.Round(), 3)), Bgr<byte>.Red, 3);
            //image.Draw(normals, Bgr<byte>.Green, 3, false);
        }

        private static LineSegment2DF getLine(int derivativeOrientation, PointF centerPoint, float length)
        {
            Vector2D vec = new Vector2D(Angle.ToRadians(derivativeOrientation)).Multiply(length / 2);
            var p1 = vec.Add(centerPoint);
            var p2 = vec.Negate().Add(centerPoint);

            return new LineSegment2DF(p1.ToPoint(), p2.ToPoint());
        }

        #endregion

        int scale = 300, angle = 0;
        int dScale = 1, dAngle = -1;
        private void timer_Tick(object sender, EventArgs e)
        {
            const int BORDER_OFFSET = 20;

            scale += 10 * dScale; if (scale > 300) dScale = -1; if (scale < 100) dScale = 1;
            angle += 5 * dAngle;  if (angle > 360) dAngle = -1; if (dAngle < 0) dAngle = 1;

            var transformation = Transforms2D.Combine
               (
                    Transforms2D.Rotation((float)Angle.ToRadians(angle)),
                    Transforms2D.Scale(scale, scale)
               );

            IEnumerable<PointF> pts = modelPts.Transform(transformation);

            var box = pts.BoundingRect(); //maybe apply it to bounding box instead of points (expensive)
            pts = pts.Transform(Transforms2D.Translation(-box.X + BORDER_OFFSET, -box.Y + BORDER_OFFSET));

            var image = new Bgr<byte>[scale + BORDER_OFFSET * 2, scale + BORDER_OFFSET * 2];
            drawContour(pts.ToList(), image);
            pictureBox.Image = image.ToBitmap();
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            timer.Enabled = !timer.Enabled;
        }
    }
}
