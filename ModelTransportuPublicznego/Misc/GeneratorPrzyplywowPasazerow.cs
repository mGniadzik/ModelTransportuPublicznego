using ModelTransportuPublicznego.Model.Przystanek;
using System;
using System.Collections.Generic;

namespace ModelTransportuPublicznego.Misc
{
    class GeneratorPrzyplywowPasazerow
    {
        private static GeneratorPrzyplywowPasazerow instancja;
        private List<PrzyplywPasazerow> przyplywyPasazerow;
        private GeneratorPrzyplywowPasazerow()
        {
            przyplywyPasazerow = new List<PrzyplywPasazerow>();
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
    }
}
