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
            if (sciezkaPlikuTrasy != "")
            {
                trasa = Trasa.OdczytajPlik(sciezkaPlikuTrasy);
                przystanek.DodajTrase(trasa);
                this.sciezkaPlikuTrasy = sciezkaPlikuTrasy;
            }
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
                sw.WriteLine($"{0}-{1}-{2}", przystanek.NazwaPrzystanku, czasPrzyjaduDoPrzystanku, sciezkaPlikuTrasy);
            } catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }

            return true;
        }

        public static WpisLinii Odczytaj(StreamReader sr, ZarzadTransportu zt)
        {
            var dane = sr.ReadLine().Split('-');

            if (zt == null)
            {
                return new WpisLinii(Przystanek.Przystanek.OdczytajPlik(dane[0], null), new TimeSpan(Convert.ToInt32(dane[1]), 
                    Convert.ToInt32(dane[2]), Convert.ToInt32(dane[3])));
            } else
            {
                return new WpisLinii(zt.ZwrocPrzystanekPodanejNazwy(dane[0]), TimeSpan.Parse(dane[1]), dane[2]);
            }
        }

        public static WpisLinii Odczytaj(string tekstWpisu, ZarzadTransportu zt)
        {
            var dane = tekstWpisu.Split('-');
            var czasRaw = dane[1].Split(':');
            TimeSpan czas = TimeSpan.Zero;

            if (czasRaw.Length == 1)
            {
                czas = new TimeSpan(0, Convert.ToInt32(czasRaw[0]), 0);
            }
            else if (czasRaw.Length == 2)
            {
                czas = new TimeSpan(0, Convert.ToInt32(czasRaw[0]), Convert.ToInt32(czasRaw[1]));
            }
            else if (czasRaw.Length == 3)
            {
                czas = new TimeSpan(Convert.ToInt32(czasRaw[0]), Convert.ToInt32(czasRaw[1]), Convert.ToInt32(czasRaw[2]));
            }
            else
            {
                throw new ArgumentException("Podany czas jest w z³ym formacie");
            }

            if (zt == null)
            {
                return new WpisLinii(Przystanek.Przystanek.OdczytajPlik(dane[0], null), czas, dane[2]);
            }
            else
            {
                return new WpisLinii(zt.ZwrocPrzystanekPodanejNazwy(dane[0]), czas, dane[2]);
            }
        }
    }
}