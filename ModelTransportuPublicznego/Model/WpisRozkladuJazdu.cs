using System;

namespace ModelTransportuPublicznego.Model {
    public class WpisRozkladuJazdy : IComparable<WpisRozkladuJazdy> {
        private Linia liniaObslugujaca;
        private TimeSpan czasPrzyjazdu;
        public bool CzyWykonany;

        public TimeSpan CzasPrzyjazdu => czasPrzyjazdu;

        public Linia LiniaObslugujaca => liniaObslugujaca;

        public WpisRozkladuJazdy(Linia liniaObslugujaca, TimeSpan czasPrzyjazdu) {
            this.liniaObslugujaca = liniaObslugujaca;
            this.czasPrzyjazdu = czasPrzyjazdu;
            CzyWykonany = false;
        }

        public int CompareTo(WpisRozkladuJazdy other) {
            return czasPrzyjazdu.CompareTo(other.czasPrzyjazdu);
        }
    }
}