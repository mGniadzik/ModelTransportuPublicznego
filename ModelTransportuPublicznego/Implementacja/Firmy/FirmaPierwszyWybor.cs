using ModelTransportuPublicznego.Implementacja.Wyjatki;
using ModelTransportuPublicznego.Model;
using ModelTransportuPublicznego.Model.Firma;
using System.Collections.Generic;

namespace ModelTransportuPublicznego.Implementacja.Firmy {
    public class FirmaPierwszyWybor : Firma {
        
        public FirmaPierwszyWybor(string nazwaFirmy, string sciezkaPlikuKonfiguracyjnego) : base(nazwaFirmy, sciezkaPlikuKonfiguracyjnego) { }

        public override Autobus WybierzAutobusDoObslugiPrzejazdu() {
            if (IstniejaDostepneAutobusy()) {
                var autobus = new List<Autobus>(dostepnyTabor.Keys)[0];

                ZajmijAutobus(autobus);

                return autobus;
            }
            
            throw new AutobusNieZnalezionyWyjatek();
        }

        public override Kierowca WybierzKierowceDoObslugiPrzejazdu(Linia linia) {
            if (IstniejaDostepniKierowcy()) {
                foreach (var k in listaDostepnychKierowcow) {
                    if (k.CzyMozeWykonacPrzejazd(linia.ZwrocSpodziewanyCzasPrzejazduLinii())) {
                        var kierowca = listaDostepnychKierowcow[0];
                        listaDostepnychKierowcow.Remove(kierowca);
                        listaKierwcowZajetych.Add(kierowca);
                        return kierowca;
                    }
                }
            }
            
            throw new KierowcaNieZnalezionyWyjatek();
        }
    }
}