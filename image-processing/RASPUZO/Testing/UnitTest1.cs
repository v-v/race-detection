using System;
using System.Drawing;
using System.Drawing.Imaging;
using ImageProcessing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Testing
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var lbp = new LBP();
            var slika = (Bitmap) Image.FromFile("mark.png");

            var gray = lbp.GrayConversion(slika, slika.Width, slika.Height);

            gray.Save("mark_sivi.png", ImageFormat.Png);

            var obrada = lbp.LBPAlgorithm(gray, 1, gray.Width, gray.Height);

            obrada.Save("mark_lbp_1.png", ImageFormat.Png);

            obrada = lbp.LBPAlgorithm(gray, 2, gray.Width, gray.Height);

            obrada.Save("mark_lbp_2.png", ImageFormat.Png);

            obrada = lbp.LBPAlgorithm(gray, 2, gray.Width, gray.Height);

            obrada.Save("mark_lbp_3.png", ImageFormat.Png);
        }
    }
}
