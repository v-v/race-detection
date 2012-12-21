using System;
using System.Collections.Generic;
using System.Text;

namespace ucitavanjeSlika
{
    class KlasaObjekt
    {
        private string klasaOznaka;
        private string imeSlike;

        public KlasaObjekt()
        {
            this.klasaOznaka = "-";
            this.imeSlike = "-";
        }
        public KlasaObjekt(string ime, string klasa) 
        {
            this.klasaOznaka = klasa;
            this.imeSlike = ime;
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
    }
    class TestListaObjekata
    {
        static void Main()
        {
            List<KlasaObjekt> lista = new List<KlasaObjekt>();
            for (int i = 0; i < 10; i++) 
            { 
                KlasaObjekt obj = new KlasaObjekt("testObjekt",i.ToString());
                lista.Add(obj);
            }
            for (int i = 0; i < 10; i++)
            {
                Console.Write(lista[i].getIme());
                Console.Write(" : ");
                Console.WriteLine(lista[i].getKlasa());
            }
        }
    }
}
