using ModelTransportuPublicznego.Implementacja.Wyjatki;
using ModelTransportuPublicznego.Model;
using ModelTransportuPublicznego.Model.Firma;

namespace ModelTransportuPublicznego.Implementacja.Firmy {
    public class FirmaPierwszyWybor : Firma {
        
        public FirmaPierwszyWybor(string nazwaFirmy) : base(nazwaFirmy) { }
        public override Autobus WybierzAutobusDoObslugiPrzejazdu() {
            if (IstniejaDostepneAutobusy()) {
                var autobus = dostepnyTabor[0];
                listaAutobusowZajetych.Add(autobus);
                dostepnyTabor.Remove(autobus);
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