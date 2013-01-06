using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using Emgu.CV;
using Emgu.CV.Structure;
using System.IO;

namespace ucitavanjeSlika
{
    class KlasaObjekt
    {
        private string klasaOznaka;
        private string imeSlike;
        private Image<Bgr, Byte> img;

        public KlasaObjekt()
        {
            this.klasaOznaka = "-";
            this.imeSlike = "-";
        }
        public KlasaObjekt(Image<Bgr,Byte> image,string ime, string klasa) 
        {
            this.klasaOznaka = klasa;
            this.imeSlike = ime;
            this.img = image;
        }
        public void setIme(string ime)
        {
            this.imeSlike = ime;
        }
        public string getIme()
        {
            return this.imeSlike;
        }
        public void setKlasa(string klasa) {
            this.klasaOznaka = klasa;
        }
        public string getKlasa()
        {
            return this.klasaOznaka;
        }
        public void setImage(Image<Bgr, Byte> image){
            this.img = image;
        }
        public Image<Bgr, Byte> getImage()
        {
            return this.img;
        }
    }
    class TestListaObjekata
    {
        static void Main()
        {
            for(int m=2;m<150;m++){
            string broj;
            List<KlasaObjekt> lista = new List<KlasaObjekt>();
            List<string> listaOznaka = new List<string>();
            if (m < 10) {
                broj = "0000" + m.ToString(); 
            }
            else if (m > 10 && m < 100)
            {
                broj = "000" + m.ToString(); 
            }
            else {
                broj = "00" + m.ToString(); 
            }
            string imagesResourcePath1 = ".\\data\\images\\"+broj+"\\*fa*";
            string imagesResourcePath2 = ".\\data\\images\\"+broj+"\\*fb*";
            string imageDataFile = ".\\data\\ground_truths\\name_value\\"+broj+".txt";
            string[] imagesFileNames1 = Directory.GetFiles(imagesResourcePath1);
            string[] imagesFileNames2 = Directory.GetFiles(imagesResourcePath2);
            string[] lines = System.IO.File.ReadAllLines(imageDataFile);

            foreach (string line in lines)
            {
                listaOznaka.Add(line);
            }
            int counter = 0;
            int totalCount1 = imagesFileNames1.Length;
            foreach (string imageName in imagesFileNames1)
            {
                try
                {
                    counter++;
                    Console.WriteLine("Processing image " + counter + " of " + totalCount1);
                    Image < Bgr, Byte> img = new Image < Bgr, Byte>(imageName);
                    KlasaObjekt obj = new KlasaObjekt(img,imageName,listaOznaka[counter]);
                    lista.Add(obj);

                    
                }
                catch (Exception e)
                {
                    Console.WriteLine(imageName + ": " + e.Message);
                    Console.ReadLine();
                }
            }
            counter = 0;
            int totalCount2 = imagesFileNames2.Length;
            foreach (string imageName in imagesFileNames2)
            {
                try
                {
                    counter++;
                    Console.WriteLine("Processing image " + counter + " of " + totalCount2);
                    Image<Bgr, Byte> img = new Image<Bgr, Byte>(imageName);
                    KlasaObjekt obj = new KlasaObjekt(img, imageName, listaOznaka[counter]);
                    lista.Add(obj);


                }
                catch (Exception e)
                {
                    Console.WriteLine(imageName + ": " + e.Message);
                    Console.ReadLine();
                }
            }

            Console.WriteLine("Finished processing. Enter to exit.");
            Console.ReadLine();
        }
        }

    }
}
