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
            var slika = (Bitmap) Image.FromFile("mark.png");
        }
    }
}
