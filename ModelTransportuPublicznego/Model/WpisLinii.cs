using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace ModelTransportuPublicznego.Model {
    public class WpisLinii {
        public Przystanek.Przystanek przystanek;
        public TimeSpan czasPrzyjaduDoPrzystanku;
        public Trasa trasa;
        public string sciezkaPlikuTrasy;

        public WpisLinii(Przystanek.Przystanek przystanek, TimeSpan czasPrzyjaduDoPrzystanku) {
            this.przystanek = przystanek;
            this.czasPrzyjaduDoPrzystanku = czasPrzyjaduDoPrzystanku;
        }

        public WpisLinii(Przystanek.Przystanek przystanek, TimeSpan czasPrzyjaduDoPrzystanku, string sciezkaPlikuTrasy) : this(przystanek, czasPrzyjaduDoPrzystanku)
        {
            trasa = Trasa.OdczytajPlik(sciezkaPlikuTrasy);
            this.sciezkaPlikuTrasy = sciezkaPlikuTrasy;
        }

        public WpisLinii(WpisLinii wl) {
            przystanek = wl.przystanek;
            czasPrzyjaduDoPrzystanku = new TimeSpan(wl.czasPrzyjaduDoPrzystanku.Ticks);
        }

        public Point[] ZwrocPunktyWpisu()
        {
            List<Point> result = new List<Point>();

            result.Add(trasa.PrzystanekLewy.Pozycja);
            result.AddRange(trasa.PunktyTrasy);
            result.Add(trasa.PrzystanekPrawy.Pozycja);

            return result.ToArray();
        }

        public virtual bool Zapisz(StreamWriter sw)
        {
            try
            {
                sw.WriteLine($"{0}:{1}:{2}", przystanek.NazwaPrzystanku, czasPrzyjaduDoPrzystanku, sciezkaPlikuTrasy);
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
                return new WpisLinii(zt.ZwrocPrzystanekPodanejNazwy(dane[0]), new TimeSpan(Convert.ToInt32(dane[1]), 
                    Convert.ToInt32(dane[2]), Convert.ToInt32(dane[3])));
            }
        }
    }
}