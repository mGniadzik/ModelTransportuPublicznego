using System.Collections.Generic;
using System.IO;
using System.Linq;
using ModelTransportuPublicznego.Implementacja.Firmy;
using ModelTransportuPublicznego.Misc;
using ModelTransportuPublicznego.Model;
using ModelTransportuPublicznego.Model.Firma;
using ModelTransportuPublicznego.Model.Przystanek;

namespace ModelTransportuPublicznego.Implementacja {
    
    public class SynchronicznyZarzadTransportu : ZarzadTransportu {

        private List<Przejazd> listaPrzejazdow;

        public SynchronicznyZarzadTransportu(string nazwaFirmy) : base(nazwaFirmy) {
            listaPrzejazdow = new List<Przejazd>();
        }

        public SynchronicznyZarzadTransportu(string nazwaFirmy, IEnumerable<Przystanek> listaPrzystankow) : base(nazwaFirmy, listaPrzystankow) { }
        
        public SynchronicznyZarzadTransportu(string nazwaFirmy, IEnumerable<Firma> listaFirm) : base(nazwaFirmy, listaFirm) { }
        
        public SynchronicznyZarzadTransportu(string nazwaFirmy, IEnumerable<Przystanek> siecPrzystankow, IEnumerable<Firma> listaFirm) 
            : base(nazwaFirmy, siecPrzystankow, listaFirm) { }
        
        public override void DodajPrzystanek(Przystanek przystanek) {
            siecPrzystankow.Add(przystanek);
        }

        public override void DodajPrzystanek(IEnumerable<Przystanek> przystanki) {
            foreach (var przystanek in przystanki) {
                siecPrzystankow.Add(przystanek);
            }
        }

        public override void UsunPrzystanek(Przystanek przystanek) {
            siecPrzystankow.Remove(przystanek);
        }

        public override void DodajFirme(Firma firma) {
            listaFirm.Add(firma);
        }

        public override void DodajFirme(IEnumerable<Firma> firmy) {
            foreach (var firma in firmy) {
                listaFirm.Add(firma);
            }
        }

        public override void UsunFirme(Firma firma) {
            listaFirm.Remove(firma);
        }

        public override void StworzListePrzejazdow() {
            foreach (var firma in listaFirm) {
                listaPrzejazdow.AddRange(firma.UtworzListePrzejazdow());
            }
            
            listaPrzejazdow.Sort();
        }
        
        public override void DodajPrzejazdDoListy(Przejazd przejazd) {
            if (listaPrzejazdow.Count == 0) {
                listaPrzejazdow.Add(przejazd);
                return;
            }
            
            for (var i = 0; i < listaPrzejazdow.Count; i++) {
                if (listaPrzejazdow[i].CzasNastepnejAkcji > przejazd.CzasNastepnejAkcji) {
                    listaPrzejazdow.Insert(i, przejazd);
                    break;
                }
            }
        }

        public override void WykonajPrzejazdy() {
            Przejazd przejazd;
            
            while (listaPrzejazdow.Count != 0) {
                przejazd = listaPrzejazdow[0];
                listaPrzejazdow.RemoveAt(0);
                przejazd.WykonajNastepnaAkcje();

                if (!przejazd.TrasaZakonczona) {
                    DodajPrzejazdDoListy(przejazd);
                }
                
                przejazd.Firma.DodajPrzejazdDoHistorii(przejazd);
                WizualizatorMapy.NarysujMape(przejazd.CzasNastepnejAkcji.ToString().Replace(':', '-'), siecPrzystankow, ZwrocLinie());
            }
        }

        public static SynchronicznyZarzadTransportu OdczytajPlik(string sciezkaPliku)
        {
            SynchronicznyZarzadTransportu zt;
            using (var sr = File.OpenText(sciezkaPliku))
            {
                zt = new SynchronicznyZarzadTransportu(sr.ReadLine());
                zt.DodajPrzystanek(sr.ReadLine().Split('|').Select(s => Przystanek.OdczytajPlik(s, zt)));
                zt.DodajFirme(sr.ReadLine().Split('|').Select(f => FirmaLosowa.OdczytajPlik(f, zt)));
                zt.DodajLinie(sr.ReadLine().Split('|').Select(l => Linia.OdczytajPlik(l, zt)));
            }

            return zt;
        }
    }
}