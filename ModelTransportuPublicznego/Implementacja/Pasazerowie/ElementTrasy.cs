using System;
using ModelTransportuPublicznego.Model;
using ModelTransportuPublicznego.Model.Przystanek;

namespace ModelTransportuPublicznego.Implementacja.Pasazerowie {
    public class ElementTrasy {
        private Linia linia;
        private Przystanek przystanek;
        private TimeSpan czasOczekiwania;
        private TimeSpan czasPrzejazdu;
        public bool CzyPrzebyty;

        public Linia Linia => linia;

        public Przystanek Przystanek => przystanek;

        public TimeSpan CzasOczekiwania => czasOczekiwania;

        protected ElementTrasy() {
            CzyPrzebyty = false;
        }

        public ElementTrasy(Linia linia, Przystanek przystanek, TimeSpan czasOczekiwania, TimeSpan czasPrzejazdu) : this() {
            this.linia = linia;
            this.przystanek = przystanek;
        }

        public ElementTrasy(Linia linia, TimeSpan czasOczekiwania, TimeSpan czasPrzejazdu, Przystanek przystanek) : this() {
            this.linia = linia;
            this.czasOczekiwania = czasOczekiwania;
            this.czasPrzejazdu = czasPrzejazdu;
            this.przystanek = przystanek;
        }

        public ElementTrasy(ElementTrasy elem) : this()
        {
            linia = elem.linia;
            czasOczekiwania = elem.czasOczekiwania;
            czasPrzejazdu = elem.czasPrzejazdu;
            przystanek = elem.przystanek;
        }
    }
}