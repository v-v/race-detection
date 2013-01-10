using System;
using Emgu.CV;
using Emgu.CV.Structure;

namespace ImageProcessing
{
    /// <summary>
    /// Računa karakteristile koristeći Webberov zakon
    /// </summary>
    public static class WLD
    {
        /// <summary>
        /// TODO: A work in progress
        /// Računa WLD
        /// </summary>
        /// <param name="graySource">EmguCV slika - grayscale</param>
        /// <param name="width">Širina slike</param>
        /// <param name="height">Visina slike</param>
        /// <returns>2D matricu s double vrijednostima</returns>
        public static double[,] WLDAlgorithm(Image<Bgr, Byte> graySource, int width, int height)
        {
            var bmp = graySource;
            var numRow = height;
            var numCol = width;
            var gray = new double[width, height];

            int blockSizeY = 3;
            int blockSizeX = 3;
            int belta = 5;
            int alpha = 3;
            double epsilon = 1e-7;
            int brojSusjeda = 8;

            if (numCol < blockSizeX || numRow < blockSizeY)
                throw new Exception("Slika je premala!");

            var filter = new[,]
                                {
                                    {1, 1, 1},
                                    {1, -8, 1},
                                    {1, 1, 1}
                                };

            int dx = width - blockSizeX;
            int dy = height - blockSizeY;

            return gray;
        }
    }
}
