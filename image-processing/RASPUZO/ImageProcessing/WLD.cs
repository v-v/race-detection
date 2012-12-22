using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace ImageProcessing
{
    public class WLD
    {
        public static Bitmap WLDAlgorithm(Bitmap graySource, int width, int height)
        {
            var bmp = graySource;
            var numRow = height;
            var numCol = width;
            var gray = new Bitmap(width, height);

            int blockSizeY = 3;
            int blockSizeX = 3;
            int belta = 5;
            int alpha = 3;
            double epsilon = 1e-7;
            int brojSusjeda = 8;

            if(numCol < blockSizeX || numRow < blockSizeY)
                throw new Exception("Slika je premala!");

            var filter = new[,]
                                {
                                    {1, 1, 1},
                                    {1, -8, 1},
                                    {1, 1, 1}
                                };

            int dx = width - blockSizeX;
            int dy = height - blockSizeY;

            return null;
        }
    }
}
