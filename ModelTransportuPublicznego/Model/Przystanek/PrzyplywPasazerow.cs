using System;

namespace ModelTransportuPublicznego.Model.Przystanek {
    public struct PrzyplywPasazerow : IComparable<PrzyplywPasazerow> {
        public TimeSpan czasPrzyplywu;
        public int IloscPasazerow;
        public bool CzyWykonany;

        public PrzyplywPasazerow(TimeSpan czasPrzyplywu, int iloscPasazerow) {
            this.czasPrzyplywu = czasPrzyplywu;
            IloscPasazerow = iloscPasazerow;
            CzyWykonany = false;
        }

        public int CompareTo(PrzyplywPasazerow other) {
            return czasPrzyplywu.CompareTo(other.czasPrzyplywu);
        }
    }
}