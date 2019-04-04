using System;

namespace ModelTransportuPublicznego.Model {
    public class WpisRozkladuJazdy : IComparable<WpisRozkladuJazdy> {
        private Linia liniaObslugujaca;
        private TimeSpan czasPrzyjazdu;
        public bool czyWykonany;

        public TimeSpan CzasPrzyjazdu => czasPrzyjazdu;

        public Linia LiniaObslugujaca => liniaObslugujaca;

        public WpisRozkladuJazdy(Linia liniaObslugujaca, TimeSpan czasPrzyjazdu) {
            this.liniaObslugujaca = liniaObslugujaca;
            this.czasPrzyjazdu = czasPrzyjazdu;
            czyWykonany = false;
        }

        public TimeSpan PozostalyCzas(TimeSpan czasObecny) {
            return czasPrzyjazdu - czasObecny;
        }

        public int CompareTo(WpisRozkladuJazdy other) {
            return czasPrzyjazdu.CompareTo(other.czasPrzyjazdu);
        }
    }
}