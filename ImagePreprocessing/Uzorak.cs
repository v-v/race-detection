using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Emgu.CV;
using System;
using System.Collections.Generic;
using Emgu.CV.Structure;

namespace ImagePreprocessing
{
    public static class UcitavacSlika
    {
        public static List<Uzorak> UcitajSlike(string root)
        {
            var model = new List<Uzorak>();
            var subdirectories = Directory.GetDirectories(root + @"\data\images");

            foreach (var subdirectory in subdirectories)
            {
                var imagesFileNames = Directory.GetFiles(subdirectory);
                var brojevi = subdirectory.Split('\\');
                var broj = brojevi[brojevi.Length - 1];

                var imageDataFile = root + @"\data\ground_truths\name_value\" + broj + @"\" + broj + ".txt";
                var opis = File.ReadAllText(imageDataFile);

                for (var i = 0; i < imagesFileNames.Length; i += 2)
                {
                    var obj = new Uzorak(imagesFileNames[i], opis);
                    model.Add(obj);
                }
            }

            return model;
        }

        public static List<Uzorak> UcitalSlikeParalelno(string root)
        {
            var model = new List<Uzorak>();
            var subdirectories = Directory.GetDirectories(root + @"\data\images");

            Parallel.ForEach(subdirectories, currentFile =>
                                                 {
                                                     var imagesFileNames = Directory.GetFiles(currentFile);
                                                     var brojevi = currentFile.Split('\\');
                                                     var broj = brojevi[brojevi.Length - 1];

                                                     var imageDataFile = root + @"\data\ground_truths\name_value\" +
                                                                         broj + @"\" + broj + ".txt";
                                                     var opis = File.ReadAllText(imageDataFile);

                                                     for (var i = 0; i < imagesFileNames.Length; i += 2)
                                                     {
                                                         var obj = new Uzorak(imagesFileNames[i], opis);
                                                         model.Add(obj);
                                                     }

                                                 }
                );

            return model;
        }
    }

    public class Uzorak
    {
        public string KlasaOznaka { get; set; }
        public string ImeSlike { get; set; }
        public Image<Bgr, Byte> Img { get; set; }

        public Uzorak()
        {
            KlasaOznaka = "-";
            ImeSlike = "-";
        }

        public Uzorak(string ime, string klasa, Image<Bgr, Byte> image = null)
        {
            KlasaOznaka = klasa;
            ImeSlike = ime;
            Img = image;
        }

        public void UcitajSliku()
        {
            Img = new Image<Bgr, Byte>(ImeSlike);
        }

        public Rasa VratiRasu()
        {
            var sp = KlasaOznaka.Split(null);

            foreach (var g in sp.Select(s => s.Split('=')).Where(g => g[0] == "race"))
            {
                if (g[1].Contains("Asian"))
                {
                    return Rasa.Asian;
                }
                if (g[1].Contains("Black"))
                {
                    return Rasa.Black;
                }
                if (g[1].Contains("Hispanic"))
                {
                    return Rasa.Hispanic;
                }
                return g[1].Contains("White") ? Rasa.White : Rasa.Other;
            }

            return Rasa.Other;
        }
    }

    public enum Rasa
    {
        White,
        Black,
        Asian,
        Hispanic,
        Other
    }
}


