using ModelTransportuPublicznego.Implementacja.Pasazerowie;
using ModelTransportuPublicznego.Model;
using ModelTransportuPublicznego.Model.Przystanek;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ModelTransportuPublicznego.Misc
{
    class GeneratorPasazerow
    {
        private IEnumerable<Przystanek> siecPrzystankow;
        private IEnumerable<Linia> linie;
        private static GeneratorPasazerow instancja = null;
        private GeneratorPasazerow(IEnumerable<Przystanek> siecPrzystankow, IEnumerable<Linia> linie)
        {
            this.siecPrzystankow = siecPrzystankow;
            this.linie = linie;
        }

        public static GeneratorPasazerow Instancja(IEnumerable<Przystanek> siecPrzystankow, IEnumerable<Linia> linie)
        {
            if (instancja == null)
            {
                instancja = new GeneratorPasazerow(siecPrzystankow, linie);
            }

            return instancja;
        }

        public static GeneratorPasazerow Instancja()
        {
            if (instancja == null)
            {
                throw new ArgumentNullException("Generator Pasazerow nie zostal zinicjalizowany.");
            }

            return instancja;
        }

        public Pasazer WygenerujPasazera(Type typPasazera, int czasWsiadania, int czasWysiadania, Przystanek pPoczatkowy, Przystanek pKoncowy, TimeSpan czas)
        {
            if (typPasazera == typeof(PasazerDijkstry))
            {
                return new PasazerDijkstry(czasWsiadania, czasWysiadania, pPoczatkowy, pKoncowy, siecPrzystankow, linie, czas);
            } else if (typPasazera == typeof(PasazerKrotkodystansowy))
            {
                return new PasazerKrotkodystansowy(czasWsiadania, czasWysiadania, pPoczatkowy, pKoncowy, siecPrzystankow, linie, czas);
            } else if (typPasazera == typeof(PasazerWygodnicki))
            {
                return new PasazerWygodnicki(czasWsiadania, czasWysiadania, pPoczatkowy, pKoncowy, siecPrzystankow, linie, czas);
            } else
            {
                throw new ArgumentException("Generator pasazerów nie obsługuje danego typu pasażera");
            }
        }

        public Pasazer WygenerujPasazera(Type typPasazera, int czasWsiadania, int czasWysiadania, string pPoczatkowy, string pKoncowy, TimeSpan czas)
        {
            return WygenerujPasazera(typPasazera, czasWsiadania, czasWysiadania, ZwrocPrzystanekNazwa(pPoczatkowy), ZwrocPrzystanekNazwa(pKoncowy), czas);
        }

        public Pasazer WygenerujLosowegoPasazera(TimeSpan czas)
        {
            var rand = new Random();

            Przystanek pPoczatkowy = siecPrzystankow.ToList()[rand.Next(siecPrzystankow.Count())];
            Przystanek pKoncowy;

            do
            {
                pKoncowy = siecPrzystankow.ToList()[rand.Next(siecPrzystankow.Count())];
            } while (pKoncowy == pPoczatkowy);

            var rng = rand.Next(100);

            if (rng < 33)
            {
                return new PasazerDijkstry(rand.Next(2, 11), rand.Next(2, 11), pPoczatkowy, pKoncowy, siecPrzystankow, linie, czas);
            }
            if (rng < 66)
            {
                return new PasazerWygodnicki(rand.Next(2, 11), rand.Next(2, 11), pPoczatkowy, pKoncowy, siecPrzystankow, linie, czas);
            }

            return new PasazerKrotkodystansowy(rand.Next(2, 11), rand.Next(2, 11), pPoczatkowy, pKoncowy, siecPrzystankow, linie, czas);
        }

        public Przystanek ZwrocPrzystanekNazwa(string nazwa)
        {
            foreach (var przystanek in siecPrzystankow)
            {
                if (przystanek.NazwaPrzystanku == nazwa) return przystanek;
            }

            throw new ArgumentException($"Sieć przystanków nie posiada przystanku o nazwie { nazwa }");
        }
    }
}
