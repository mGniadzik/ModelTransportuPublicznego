using System;
using System.Collections.Generic;
using ModelTransportuPublicznego.Model;

namespace ModelTransportuPublicznego.Implementacja {
    public class FirmaLosowa : Firma {
        Random rand;

        public FirmaLosowa(string nazwaFirmy) : base(nazwaFirmy) {
            rand = new Random();
        }

        public FirmaLosowa(string nazwaFirmy, IEnumerable<Autobus> tabor, IEnumerable<Kierowca> listaKierowcow,
            IEnumerable<Linia> linieAutobusowe) : base(nazwaFirmy, tabor, listaKierowcow, linieAutobusowe) {
            rand = new Random();
        }
        
        public override List<Przejazd> UtworzListePrzejazdow() {
            var listaPrzejazdow = new List<Przejazd>();

            foreach (var linia in linieAutobusowe) {
                foreach (var wpis in linia.RozkladPrzejazdow.CzasyPrzejazdow) {
                    listaPrzejazdow.Add(new Przejazd(linia, WybierzAutobusDoObslugiPrzejazdu(), WybierzKierowceDoObslugiPrzejazdu(), wpis));
                }
            }

            return listaPrzejazdow;
        }

        protected override Autobus WybierzAutobusDoObslugiPrzejazdu() {
            return tabor[rand.Next(tabor.Count)];
        }

        protected override Kierowca WybierzKierowceDoObslugiPrzejazdu() {
            return listaKierowcow[rand.Next(listaKierowcow.Count)];
        }
    }
}