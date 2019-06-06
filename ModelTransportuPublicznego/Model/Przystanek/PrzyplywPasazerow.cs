using ModelTransportuPublicznego.Implementacja.Pasazerowie;
using ModelTransportuPublicznego.Misc;
using System;
using System.Collections.Generic;
using System.IO;

namespace ModelTransportuPublicznego.Model.Przystanek {
    public class PrzyplywPasazerow : IComparable<PrzyplywPasazerow> {
        public TimeSpan czasPrzyplywu;
        private List<DanePasazera> pasazerowie;
        private Przystanek przystanek;
        public bool CzyWykonany;

        public int IloscPasazerow => pasazerowie.Count;

        public Przystanek Przystanek => przystanek;

        private PrzyplywPasazerow()
        {
            pasazerowie = new List<DanePasazera>();
            CzyWykonany = false;
        }

        public PrzyplywPasazerow(TimeSpan czasPrzyplywu, Przystanek przystanek) : this()
        {
            this.czasPrzyplywu = czasPrzyplywu;
        }

        public void DodajPasazera(Pasazer pasazer)
        {
            pasazerowie.Add((DanePasazera)pasazer);
        }

        public void DodajPasazera(DanePasazera pasazer)
        {
            pasazerowie.Add(pasazer);
        }

        public void DodajPasazera(string typPasazera, string czasWsiadania, string czasWysiadania, string pPoczatkowy, string pKoncowy)
        {
            Type typ;

            switch (typPasazera)
            {
                case "ModelTransportuPublicznego.Implementacja.Pasazerowie.PasazerDijkstry":
                    typ = typeof(PasazerDijkstry);
                    break;
                case "ModelTransportuPublicznego.Implementacja.Pasazerowie.PasazerKrotkodystansowy":
                    typ = typeof(PasazerKrotkodystansowy);
                    break;
                case "ModelTransportuPublicznego.Implementacja.Pasazerowie.PasazerWygodnicki":
                    typ = typeof(PasazerWygodnicki);
                    break;
                default:
                    typ = null;
                    break;
            }

            pasazerowie.Add(new DanePasazera(typ, Convert.ToInt32(czasWsiadania), Convert.ToInt32(czasWysiadania), pPoczatkowy, pKoncowy));
        }

        public void UsunPasazera(Pasazer pasazer)
        {
            pasazerowie.Remove((DanePasazera)pasazer);
        }

        public void WykonajPrzyplyw()
        {
            CzyWykonany = true;
            WygenerujPasazerow();
        }

        public void WygenerujPasazerow()
        {
            var rezultat = new List<Pasazer>();
            var generator = GeneratorPasazerow.Instancja();

            foreach (var pasazer in pasazerowie)
            {
                przystanek.DodajPasazera(generator.WygenerujPasazera(pasazer.typPasazera, pasazer.czasWsiadania, pasazer.czasWysiadania, pasazer.pPoczatkowy,
                    pasazer.pKoncowy, czasPrzyplywu));
            }
        }

        public int CompareTo(PrzyplywPasazerow other) {
            return czasPrzyplywu.CompareTo(other.czasPrzyplywu);
        }

        public void Zapisz(StreamWriter sw)
        {
            sw.WriteLine($"{ czasPrzyplywu }|{ przystanek.NazwaPrzystanku }");
            var last = pasazerowie[pasazerowie.Count];

            foreach (var pasazerDane in pasazerowie)
            {
                pasazerDane.Zapisz(sw);

                if (pasazerDane != last)
                {
                    sw.Write("|");
                }
            }
        }

        public static PrzyplywPasazerow Odczytaj(StreamReader sr, ZarzadTransportu zt)
        {
            var dane = sr.ReadLine().Split('|');
            var czas = TimeSpan.Parse(dane[0]);
            var przystanek = zt.ZwrocPrzystanekPodanejNazwy(dane[1]);
            var rezultat = new PrzyplywPasazerow(czas, przystanek);
            var danePasazerow = sr.ReadLine().Split('|');

            foreach (var dp in danePasazerow)
            {
                var danePasazera = dp.Split(':');
                rezultat.DodajPasazera(danePasazera[0], danePasazera[1], danePasazera[2], danePasazera[3], danePasazera[4]);
            }

            return rezultat;
        }
    }
}