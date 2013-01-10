using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Emgu.CV;
using Emgu.CV.Structure;

namespace ImageProcessing
{
    /// <summary>
    /// Klasa koja računa LBP vrijednosti
    /// </summary>
    public static class LBP
    {
        /// <summary>
        /// Računa LBP vrijednosti slike
        /// 
        /// Dodati standardnu devijaciju!!
        /// </summary>
        /// <param name="source">EmguCV slika</param>
        /// <param name="r">Radijus koji LBP gleda</param>
        /// <param name="width">Širina slike</param>
        /// <param name="height">Visina slike</param>
        /// <returns>Matricu double LBP vrijednosti</returns>
        public static double[,] LBPAlgorithm(Image<Bgr, Byte> source, int r, int width, int height)
        {
            var numRow = source.Height;
            var numCol = source.Width;
            var mat = new double[numCol, numRow];

            for (var i = 0; i < numRow; i++)
            {
                for (var j = 0; j < numCol; j++)
                {
                    mat[j, i] = 0;

                    //define boundary condition, other wise say if you are looking at pixel (0,0), it does not have any suitable neighbors
                    if ((i <= r) || (j <= r) || (i >= (numRow - r)) || (j >= (numCol - r))) continue;

                    var vals = new List<int>();
                    try
                    {
                        for (var i1 = i - r; i1 < (i + r); i1++)
                        {
                            for (var j1 = j - r; j1 < (j + r); j1++)
                            {
                                var acPixel = source[j, i].Red;
                                var nbrPixel = source[j1, i1].Red;

                                vals.Add(nbrPixel > acPixel ? 1 : 0);
                            }
                        }
                    }
                    catch (Exception)
                    {
                        return null;
                    }

                    var d1 = Bin2Dec(vals);
                    mat[j, i] = d1;
                }
            }

            return mat;
        }

        /// <summary>
        /// Listu nula i jedinica pretvara u double
        /// </summary>
        /// <param name="bin">Lista nula i jedinica</param>
        /// <returns>Decimalna vrijednost</returns>
        public static double Bin2Dec(List<int> bin)
        {
            return bin.Select((t, i) => t * Math.Pow(2, i)).Sum();
        }

        #region Deprecated
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mat"></param>
        /// <param name="lbp"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        [Obsolete("Ne koristi se više", true)]
        private static double[,] NormalizeLbpMatrix(double[,] mat, Image<Bgr, Byte> lbp, double max)
        {
            int numRow = lbp.Height;
            int numCol = lbp.Width;
            for (int i = 0; i < numRow; i++)
            {
                for (int j = 0; j < numCol; j++)
                {
                    // see the Normalization process of dividing pixel by max value and multiplying with 255
                    double d = mat[j, i] / max;
                    int v = (int)(d * 255);
                    Color c = Color.FromArgb(v, v, v);
                    var item = lbp[j, i];

                    item.Blue = c.B;
                    item.Green = c.G;
                    item.Red = c.R;
                }
            }
            return mat;
        }

        /// <summary>
        /// Transformira sliku u grayscale
        /// </summary>
        /// <param name="srcBmp"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        [Obsolete("Ne koristi se više", true)]
        public static Bitmap GrayConversion(Bitmap srcBmp, int width, int height)
        {
            var bmp = srcBmp;
            var numRow = height;
            var numCol = width;
            var gray = new Bitmap(width, height);// GRAY is the resultant matrix 

            for (int i = 0; i < numRow; i++)
            {
                for (int j = 0; j < numCol; j++)
                {
                    Color c = bmp.GetPixel(j, i);// Extract the color of a pixel 
                    int rd = c.R; int gr = c.G; int bl = c.B;// extract the red,green, blue components from the color.
                    double d1 = 0.2989 * (double)rd + 0.5870 * (double)gr + 0.1140 * (double)bl;
                    int c1 = (int)Math.Round(d1);
                    Color c2 = Color.FromArgb(c1, c1, c1);
                    gray.SetPixel(j, i, c2);
                }
            }
            return gray;
        }
        #endregion
    }
}
