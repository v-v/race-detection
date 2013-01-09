using System;
using Classifier;
using Emgu.CV;
using Emgu.CV.Structure;
using ImagePreprocessing;

namespace UI
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //String win1 = "Test Window";
            //CvInvoke.cvNamedWindow(win1);



            var popisSlika = UcitavacSlika.UcitajSlike(@"C:\Users\smisak\Desktop");

            var brojUzoraka = popisSlika.Count;
            const int dimenzionalnostUzoraka = 7; // za boju koze + deviacije, kasnije cemo povecati za LBP

            var featuriSlika = new Matrix<float>(brojUzoraka, dimenzionalnostUzoraka);
            var klaseSlika = new Matrix<float>(brojUzoraka, 1);

            for (var i = 0; i < brojUzoraka; i++)
            {
                Console.WriteLine("Obrađujem sliku: {0} za rasu {1}", popisSlika[i].ImeSlike, popisSlika[i].VratiRasu());
                var image = new Image<Bgr, Byte>(popisSlika[i].ImeSlike);
                Bgr colorAvg;
                MCvScalar colorSdv;
                Detector.PrepoznavanjeBojeKoze(image, out colorAvg, out colorSdv);

                featuriSlika.Data[i, 0] = (float)colorAvg.Red;
                featuriSlika.Data[i, 1] = (float)colorAvg.Green;
                featuriSlika.Data[i, 2] = (float)colorAvg.Blue;

                featuriSlika.Data[i, 3] = (float)colorSdv.v0;
                featuriSlika.Data[i, 4] = (float)colorSdv.v1;
                featuriSlika.Data[i, 5] = (float)colorSdv.v2;
                featuriSlika.Data[i, 6] = (float)colorSdv.v2;

                klaseSlika.Data[i, 0] = (float) popisSlika[i].VratiRasu();
            }

            SVMManager.Ucenje(featuriSlika, klaseSlika);

            Console.ReadKey();

            //CvInvoke.cvShowImage(win1, imgKozaLica); //Show the image
            //CvInvoke.cvWaitKey(0);  //Wait for the key pressing event
            //CvInvoke.cvDestroyWindow(win1);
        }
    }
}
