using ModelTransportuPublicznego.Model;
using ModelTransportuPublicznego.Model.Przystanek;
using System;
using System.Collections.Generic;
using System.IO;

namespace ModelTransportuPublicznego.Misc
{
    class GeneratorPrzyplywowPasazerow
    {
        private static GeneratorPrzyplywowPasazerow instancja;
        private List<PrzyplywPasazerow> przyplywyPasazerow;
        private Random random;

        public IEnumerable<PrzyplywPasazerow> Przyplywy => przyplywyPasazerow;
        private GeneratorPrzyplywowPasazerow()
        {
            przyplywyPasazerow = new List<PrzyplywPasazerow>();
            random = new Random();
        }

        public static GeneratorPrzyplywowPasazerow Instancja()
        {
            if (instancja == null)
            {
                instancja = new GeneratorPrzyplywowPasazerow();
            }

            return instancja;
        }

        public PrzyplywPasazerow StworzPrzyplyw(TimeSpan czas, Przystanek przystanek)
        {
            var rezultat = new PrzyplywPasazerow(czas, przystanek);
            przyplywyPasazerow.Add(rezultat);

            return rezultat;
        }

        public void Zapisz(string sciezkaPliku)
        {
            using (var sw = File.CreateText(sciezkaPliku))
            {
                foreach (var przyplyw in przyplywyPasazerow)
                {
                    przyplyw.Zapisz(sw);
                }
            }
        }

        public void OdczytajPlik(string sciezkaPliku, ZarzadTransportu zt)
        {
            using (var sr = File.OpenText(sciezkaPliku))
            {
                do
                {
                    przyplywyPasazerow.Add(PrzyplywPasazerow.Odczytaj(sr, zt));
                } while (!sr.EndOfStream);
            }
        }

        public void WygenerujLosowePrzyplywyDlaPrzystanku(Przystanek przystanek, int iloscPrzyplywow, int iloscPasazerow)
        {
            for (int i = 0; i < iloscPrzyplywow; i++)
            {
                var przyplyw = new PrzyplywPasazerow(WygenerujLosowyCzas(), przystanek);

                for (int j = 0; j < iloscPasazerow; j++)
                {
                    przyplyw.DodajPasazera(GeneratorPasazerow.Instancja().WygenerujLosowegoPasazera(przyplyw.czasPrzyplywu));
                }

                przyplywyPasazerow.Add(przyplyw);
            }
        }

        private TimeSpan WygenerujLosowyCzas()
        {
            return new TimeSpan(random.Next(0, 24), random.Next(0, 60), random.Next(0, 60));
        }
    }
}
