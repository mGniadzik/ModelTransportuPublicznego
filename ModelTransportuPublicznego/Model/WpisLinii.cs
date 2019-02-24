using System;

namespace ModelTransportuPublicznego.Model {
    public class WpisLinii {
        public Przystanek przystanek;
        public TimeSpan czasPrzyjaduDoPrzystanku;

        public WpisLinii(Przystanek przystanek, TimeSpan czasPrzyjaduDoPrzystanku) {
            this.przystanek = przystanek;
            this.czasPrzyjaduDoPrzystanku = czasPrzyjaduDoPrzystanku;
        }
    }
}