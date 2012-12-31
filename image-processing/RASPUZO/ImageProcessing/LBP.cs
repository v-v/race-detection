using System;
using System.Collections.Generic;
using System.Drawing;

namespace ImageProcessing
{
    // besramno kopirano s interneta, ako bude smisla kanim napraviti paralelnu verziju
    // http://grasshoppernetwork.com/showthread.php?tid=849
    public class LBP
    {
        public Bitmap GrayConversion(Bitmap srcBmp, int width, int height)
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

        public Bitmap LBPAlgorithm(Bitmap srcBmp, int r, int width, int height)
        {
            //1. Extract rows and columns from srcImage . Note Source image is Gray scale Converted Image
            int numRow = srcBmp.Height;
            int numCol = srcBmp.Width;
            var lbp = new Bitmap(numCol, numRow); // resultant matrix
            var mat = new double[numCol, numRow];
            double max = 0.0;

            //2. Loop through Pixels
            for (int i = 0; i < numRow; i++)
            {
                for (int j = 0; j < numCol; j++)
                {
                    mat[j, i] = 0;

                    //define boundary condition, other wise say if you are looking at pixel (0,0), it does not have any suitable neighbors
                    if ((i > r) && (j > r) && (i < (numRow - r)) && (j < (numCol - r)))
                    {
                        // we want to store binary values in a List
                        var vals = new List<int>();
                        try
                        {
                            for (int i1 = i - r; i1 < (i + r); i1++)
                            {
                                for (int j1 = j - r; j1 < (j + r); j1++)
                                {
                                    int acPixel = srcBmp.GetPixel(j, i).R;
                                    int nbrPixel = srcBmp.GetPixel(j1, i1).R;
                                    // 3. This is the main Logic of LBP

                                    vals.Add(nbrPixel > acPixel ? 1 : 0);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                        }
                        //4. Once we have a list of 1's and 0's , convert the list to decimal
                        // Also for normalization purpose calculate Max value
                        double d1 = Bin2Dec(vals);
                        mat[j, i] = d1;
                        if (d1 > max)
                        {
                            max = d1;
                        }
                    }
                }
            }
            //5. Normalize LBP matrix MAT an obtain LBP image lbp
            lbp = NormalizeLbpMatrix(mat, lbp, max);
            return lbp;
        }

        public static double Bin2Dec(List<int> bin)
        {
            double d = 0;

            for (int i = 0; i < bin.Count; i++)
            {
                d += bin[i] * Math.Pow(2, i);
            }
            return d;
        }

        private Bitmap NormalizeLbpMatrix(double[,] mat, Bitmap lbp, double max)
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
                    lbp.SetPixel(j, i, c);
                }
            }
            return lbp;
        }
    }
}
