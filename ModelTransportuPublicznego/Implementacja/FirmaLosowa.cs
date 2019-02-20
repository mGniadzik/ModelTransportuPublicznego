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
        
        public override IEnumerable<Przejazd> UtworzListePrzejazdow() {
            var listaPrzejazdow = new List<Przejazd>();

            foreach (var linia in linieAutobusowe) {
                foreach (var wpis in linia.RozkladPrzejazdow.CzasyPrzejazdow) {
                    listaPrzejazdow.Add(new Przejazd(linia, WybierzAutobusDoObslugiPrzejazdu(), WybierzKierowceDoObslugiPrzejazdu(), wpis));
                }
            }

            return listaPrzejazdow;
        }

        protected override Autobus WybierzAutobusDoObslugiPrzejazdu() {
            var wybor = rand.Next(dostepnyTabor.Count);
            var autobus = dostepnyTabor[wybor];
            dostepnyTabor.RemoveAt(wybor);
            listaAutobusowZajetych.Add(autobus);

            return autobus;
        }

        protected override Kierowca WybierzKierowceDoObslugiPrzejazdu() {
            var wybor = rand.Next(listaDostepnychKierowcow.Count);
            var kierowca = listaDostepnychKierowcow[wybor];
            listaDostepnychKierowcow.RemoveAt(wybor);
            listaKierwcowZajetych.Add(kierowca);
            
            return kierowca;
        }
    }
}