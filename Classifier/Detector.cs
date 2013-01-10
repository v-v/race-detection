using System;
using System.IO;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;

namespace Classifier
{
    public class Detector
    {
        public static HaarCascade HaarCascade;
        public static string resourcePath = null;

        public static void PrepoznavanjeBojeKoze(Image<Bgr, Byte> img, out Bgr colorAvg, out MCvScalar colorSdv)
        {
            // ------ prosjecna boja koze i standardna deviacija iste -----------
            var imgKozaLica = new Image<Bgr, Byte>(img.Width, img.Height);

            //HaarCascade haar = new HaarCascade("../../haarcascade_frontalface_default.xml"); // ne detektira crnce
            //var haar = new HaarCascade("haarcascade_frontalface_alt.xml");
            //var faces = img.DetectHaarCascade(haar)[0];
            if (resourcePath == null)
                resourcePath = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).FullName;

            if (HaarCascade == null)
                HaarCascade = new HaarCascade(resourcePath + "\\haarcascade_frontalface_alt.xml");

            var faces = img.DetectHaarCascade(HaarCascade)[0];

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

        public static Image<Gray, Byte> VratiCrnoBijelu(Image<Bgr, Byte> img, int width, int height)
        {
            Image<Gray, Byte> imgLiceZaLBP = new Image<Gray, Byte>(width, height);
            Image<Bgr, Byte> imgLiceTmp = new Image<Bgr, Byte>(img.Width, img.Height);

            if (resourcePath == null)
                resourcePath = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).FullName;

            if (HaarCascade == null)
                HaarCascade = new HaarCascade(resourcePath + "\\haarcascade_frontalface_alt.xml");

            var faces = img.DetectHaarCascade(HaarCascade)[0];

            if (faces.Length == 0)
                return null;

            foreach (var face in faces)
            {
                if (face.rect != null)
                {
                    imgLiceTmp = img.GetSubRect(face.rect);
                    break;
                }
            }

            imgLiceZaLBP = imgLiceTmp.Convert<Gray, byte>();
            imgLiceZaLBP = imgLiceZaLBP.Resize(width, height, INTER.CV_INTER_LINEAR);

            return imgLiceZaLBP;
        } 
    }
}
