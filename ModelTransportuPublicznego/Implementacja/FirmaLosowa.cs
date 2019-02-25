using System;
using System.Collections.Generic;
using ModelTransportuPublicznego.Implementacja.Wyjatki;
using ModelTransportuPublicznego.Misc;
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
                    try {
                        var wybranyAutobus = WybierzAutobusDoObslugiPrzejazdu();
                        wybranyAutobus.kierowcaAutobusu = WybierzKierowceDoObslugiPrzejazdu();
                        wybranyAutobus.liniaAutobusu = linia;
                        listaPrzejazdow.Add(new Przejazd(wybranyAutobus, this, wpis));
                    }
                    catch (AutobusNieZnalezionyWyjatek) {
                        Logger.ZalogujBrakDostepnegoAutobusu(this, linia);
                    }
                    catch (KierowcaNieZnalezionyWyjatek) {
                        Logger.ZalogujBrakDostepnegoKierowcy(this, linia);
                    }
                }
            }

            return listaPrzejazdow;
        }

        protected override Autobus WybierzAutobusDoObslugiPrzejazdu() {
            if (!IstniejaDostepneAutobusy()) {
                throw new AutobusNieZnalezionyWyjatek("Nie instnieja autobusy, które moglyby obsłużyć dany przejazd.");
            }
            var wybor = rand.Next(dostepnyTabor.Count);
            var autobus = dostepnyTabor[wybor];
            dostepnyTabor.RemoveAt(wybor);
            listaAutobusowZajetych.Add(autobus);

            return autobus;
        }

        private bool IstniejaDostepneAutobusy() {
            return dostepnyTabor.Count != 0;
        }

        private bool IstniejaDostepniKierowcy() {
            return listaDostepnychKierowcow.Count != 0;
        }

        protected override Kierowca WybierzKierowceDoObslugiPrzejazdu() {
            if (!IstniejaDostepniKierowcy()) {
                throw new KierowcaNieZnalezionyWyjatek("Nie istnieja kierowcy, którzy mogliby obsłużyć dany przejazd.");
            }
            
            var wybor = rand.Next(listaDostepnychKierowcow.Count);
            var kierowca = listaDostepnychKierowcow[wybor];
            listaDostepnychKierowcow.RemoveAt(wybor);
            listaKierwcowZajetych.Add(kierowca);
            
            return kierowca;
        }
    }
}