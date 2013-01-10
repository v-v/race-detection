using System.Drawing;
using System.Linq;
using ImagePreprocessing;
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

        [TestMethod]
        public void UcitavanjeSlika()
        {
            var slike = UcitavacSlika.UcitajSlike(@"C:\Users\smisak\Desktop");

            var uzorak = slike.First();
            var rasa = uzorak.VratiRasu();
        }
    }
}
