using ModelTransportuPublicznego.Implementacja.Pasazerowie;
using ModelTransportuPublicznego.Model;
using ModelTransportuPublicznego.Model.Przystanek;
using System;
using System.Collections.Generic;

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
    }
}
