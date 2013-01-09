using System;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;

namespace Classifier
{
    public class Detector
    {
        public static void PrepoznavanjeBojeKoze(Image<Bgr, Byte> img, out Bgr colorAvg, out MCvScalar colorSdv)
        {
            // ------ prosjecna boja koze i standardna deviacija iste -----------
            var imgKozaLica = new Image<Bgr, Byte>(img.Width, img.Height);

            //HaarCascade haar = new HaarCascade("../../haarcascade_frontalface_default.xml"); // ne detektira crnce
            var haar = new HaarCascade("haarcascade_frontalface_alt.xml");
            var faces = img.DetectHaarCascade(haar)[0];

            foreach (var face in faces)
            {
                if (face.rect != null)
                {
                    imgKozaLica = img.GetSubRect(face.rect);
                    break;
                }
            }

            var skinDetect = new AdaptiveSkinDetector(1, AdaptiveSkinDetector.MorphingMethod.ERODE);
            var mask = new Image<Gray, byte>(imgKozaLica.Size.Width, imgKozaLica.Size.Height,
                                                           new Gray(128));
            skinDetect.Process(imgKozaLica, mask);
            imgKozaLica = imgKozaLica.Copy(mask);

            imgKozaLica.AvgSdv(out colorAvg, out colorSdv);
          
        }

        public static Image<Gray, Byte> VratiCrnoBijelu(Image<Bgr, Byte> slika, int width, int height)
        {
            var imgLiceZaLBP = new Image<Gray, Byte>(100, 100);
            var imgLiceTmp = new Image<Bgr, Byte>(img.Width, img.Height);

            var haar = new HaarCascade("haarcascade_frontalface_alt.xml");
            var faces = img.DetectHaarCascade(haar)[0];

            foreach (var face in faces)
            {
                if (face.rect != null)
                {
                    imgLiceTmp = img.GetSubRect(face.rect);
                    break;
                }
            }

            imgLiceZaLBP = imgLiceTmp.Convert<Gray, byte>();
            imgLiceZaLBP.Reize(width, height, INTER.CV_INTER_LINEAR);

            return imgLiceZaLBP;
        } 
    }
}
