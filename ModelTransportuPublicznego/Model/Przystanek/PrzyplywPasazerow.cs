using System;

namespace ModelTransportuPublicznego.Model {
    public struct PrzyplywPasazerow : IComparable<PrzyplywPasazerow> {
        public TimeSpan CzasPrzyplywu;
        public int IloscPasazerow;
        public bool CzyWykonany;

        public PrzyplywPasazerow(TimeSpan czasPrzyplywu, int iloscPasazerow) {
            CzasPrzyplywu = czasPrzyplywu;
            IloscPasazerow = iloscPasazerow;
            CzyWykonany = false;
        }

        public int CompareTo(PrzyplywPasazerow other) {
            return CzasPrzyplywu.CompareTo(other.CzasPrzyplywu);
        }
    }
}