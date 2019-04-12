using System;
using System.Collections.Generic;
using ModelTransportuPublicznego.Implementacja.Wyjatki;
using ModelTransportuPublicznego.Model;
using ModelTransportuPublicznego.Model.Firma;

namespace ModelTransportuPublicznego.Implementacja.Firmy {
    public class FirmaLosowa : Firma {
        Random rand;

        public FirmaLosowa(string nazwaFirmy) : base(nazwaFirmy) {
            rand = new Random();
        }

        public FirmaLosowa(string nazwaFirmy, IEnumerable<Autobus> tabor, IEnumerable<Kierowca> listaKierowcow,
            IEnumerable<Linia> linieAutobusowe) : base(nazwaFirmy, tabor, listaKierowcow, linieAutobusowe) {
            rand = new Random();
        }

        public override Autobus WybierzAutobusDoObslugiPrzejazdu() {
            if (!IstniejaDostepneAutobusy()) {
                throw new AutobusNieZnalezionyWyjatek("Nie instnieja autobusy, które moglyby obsłużyć dany przejazd.");
            }
            var wybor = rand.Next(dostepnyTabor.Count);
            var autobus = dostepnyTabor[wybor];
            dostepnyTabor.RemoveAt(wybor);
            listaAutobusowZajetych.Add(autobus);

            return autobus;
        }

        public override Kierowca WybierzKierowceDoObslugiPrzejazdu(Linia linia) {
            if (!IstniejaDostepniKierowcy()) {
                throw new KierowcaNieZnalezionyWyjatek("Nie istnieja kierowcy, którzy mogliby obsłużyć dany przejazd.");
            }

            Kierowca kierowca = null;
            int wybor = 0;

            do {
                wybor = rand.Next(listaDostepnychKierowcow.Count);
                kierowca = listaDostepnychKierowcow[wybor];
            } while (!kierowca.CzyMozeWykonacPrzejazd(linia.ZwrocSpodziewanyCzasPrzejazduLinii()));
            
            listaDostepnychKierowcow.RemoveAt(wybor);
            listaKierwcowZajetych.Add(kierowca);
            
            return kierowca;
        }
    }
}