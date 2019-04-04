using System;

namespace ModelTransportuPublicznego.Model {
    public class WpisLinii {
        public Przystanek.Przystanek przystanek;
        public TimeSpan czasPrzyjaduDoPrzystanku;

        public WpisLinii(Przystanek.Przystanek przystanek, TimeSpan czasPrzyjaduDoPrzystanku) {
            this.przystanek = przystanek;
            this.czasPrzyjaduDoPrzystanku = czasPrzyjaduDoPrzystanku;
        }

        public WpisLinii(WpisLinii wl) {
            przystanek = wl.przystanek;
            czasPrzyjaduDoPrzystanku = new TimeSpan(wl.czasPrzyjaduDoPrzystanku.Ticks);
        }
    }
}