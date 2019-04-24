using System;
using System.IO;

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

        public virtual bool Zapisz(StreamWriter sw)
        {
            try
            {
                sw.WriteLine($"{0}:{1}", przystanek.SciezkaPlikuKonfiguracyjnego, czasPrzyjaduDoPrzystanku);
            } catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }

            return true;
        }

        public static WpisLinii Odczytaj(StreamReader sr, ZarzadTransportu zt)
        {
            var dane = sr.ReadLine().Split(':');

            if (zt == null)
            {
                return new WpisLinii(Przystanek.Przystanek.OdczytajPlik(dane[0], null), new TimeSpan(Convert.ToInt32(dane[1]), 
                    Convert.ToInt32(dane[2]), Convert.ToInt32(dane[3])));
            } else
            {
                return new WpisLinii(zt.ZwrocPrzystanekPodanejSpecyfikacji(dane[0]), new TimeSpan(Convert.ToInt32(dane[1]), 
                    Convert.ToInt32(dane[2]), Convert.ToInt32(dane[3])));
            }
        }
    }
}