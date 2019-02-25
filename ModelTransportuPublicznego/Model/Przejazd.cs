using System;
using System.Collections.Generic;
using System.Linq;
using ModelTransportuPublicznego.Implementacja.Wyjatki;
using ModelTransportuPublicznego.Misc;

namespace ModelTransportuPublicznego.Model {
    public class Przejazd : IComparable<Przejazd> {
        private Autobus autobus;
        private Akcja nastepnaAkcja;
        private Przystanek obecnyPrzystanek;
        private TimeSpan czasPrzejazdu;
        private TimeSpan rozpoczeciePrzejazdu;
        private bool trasaZakonczona;
        private Firma firma;
        private Linia linia;

        public bool TrasaZakonczona => trasaZakonczona;
        
        public TimeSpan CzasNastepnejAkcji => rozpoczeciePrzejazdu + czasPrzejazdu;

        private Przejazd() {
            autobus = null;
            nastepnaAkcja = Akcja.PobieraniePasazerow;
            czasPrzejazdu = TimeSpan.Zero;
            trasaZakonczona = false;
        }
        
        public Przejazd(Autobus autobus, Firma firma, TimeSpan rozpoczeciePrzejazdu) : this() {
            this.autobus = autobus;
            this.firma = firma;
            linia = autobus.liniaAutobusu;
            obecnyPrzystanek = autobus.liniaAutobusu.ZwrocPrzystanekIndeks(0);
            this.rozpoczeciePrzejazdu = rozpoczeciePrzejazdu;
        }

        public Przejazd(Firma firma, Linia linia, TimeSpan rozpoczeciePrzejazdu) {
            autobus = null;
            this.firma = firma;
            this.rozpoczeciePrzejazdu = rozpoczeciePrzejazdu;
            this.linia = linia;
            obecnyPrzystanek = linia.ZwrocPrzystanekIndeks(0);
        }
        
        protected enum Akcja { PobieraniePasazerow, Przejazd, WypuszczniePasazerow };

        public void WykonajNastepnaAkcje() {
            SprawdzCzyPrzejazdPosiadaAutobus();

            if (trasaZakonczona) {
                return;
            }
            
            switch (nastepnaAkcja) {
                case Akcja.PobieraniePasazerow:
                    WykonajPobieraniaPasazerow();
                    break;
                case Akcja.Przejazd:
                    WykonajPrzejazd();
                    break;
                case Akcja.WypuszczniePasazerow:
                    WykonajWypuszczaniePasazerow();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public int CompareTo(Przejazd other) {
            if (other == null) return 1;

            return CzasNastepnejAkcji.CompareTo(other.CzasNastepnejAkcji);
        }

        private void WykonajPobieraniaPasazerow() {
            
            obecnyPrzystanek.DodajAutobus(autobus);
            var pasazerowie = autobus.StworzListeWsiadajacychPasazerow(obecnyPrzystanek, autobus.liniaAutobusu);
            var czasAkcji = new TimeSpan(0, 0,autobus.PobierzPasazerow(obecnyPrzystanek, autobus.liniaAutobusu, pasazerowie));
            czasPrzejazdu += czasAkcji;
                    
            Logger.ZalogujPobieraniePasazerow(autobus, obecnyPrzystanek, pasazerowie.Count, czasAkcji);
                    
            nastepnaAkcja = Akcja.Przejazd;
        }

        private void WykonajPrzejazd() {
            var trasa = obecnyPrzystanek.ZnajdzTraseDoNastepnegoPrzystanku(
                autobus.liniaAutobusu.ZwrocNastepnyPrzystanek(obecnyPrzystanek));
            var czasAkcji = new TimeSpan(0, 0, autobus.PrzejedzTrase(trasa));
                    
            Logger.ZalogujPrzejechanieTrasy(autobus, trasa, czasAkcji);

            czasPrzejazdu += czasAkcji;
            nastepnaAkcja = Akcja.WypuszczniePasazerow;
            obecnyPrzystanek = trasa.PrzystanekDrugi;
        }

        private void WykonajWypuszczaniePasazerow() {
            var pasazerowie = autobus.StworzListeWysiadajacychPasazerow(obecnyPrzystanek);
            var czasAkcji = new TimeSpan(0, 0,autobus.WysadzPasazerow(obecnyPrzystanek, pasazerowie));
            czasPrzejazdu += czasAkcji;
                    
            Logger.ZalogujWypuszczniePasazerow(autobus, obecnyPrzystanek, pasazerowie.Count, czasAkcji);
                    
            if (obecnyPrzystanek == autobus.liniaAutobusu.ZwrocOstatniPrzystanek()) {
                trasaZakonczona = true;
                obecnyPrzystanek.UsunAutobus(autobus);
                        
                Logger.ZalogujZakonczenieTrasy(autobus, obecnyPrzystanek, autobus.liniaAutobusu, czasPrzejazdu);
                return;
            }

            nastepnaAkcja = Akcja.PobieraniePasazerow;
            obecnyPrzystanek.UsunAutobus(autobus);
        }

        private void SprawdzCzyPrzejazdPosiadaAutobus() {
            if (autobus == null) {
                try {
                    var autobus = firma.WybierzAutobusDoObslugiPrzejazdu();
                    var kierowca = firma.WybierzKierowceDoObslugiPrzejazdu();
                    
                    autobus.kierowcaAutobusu = kierowca;                   
                    autobus.liniaAutobusu = linia;
                    this.autobus = autobus;
                }
                catch (AutobusNieZnalezionyWyjatek) {
                    Logger.ZalogujBrakDostepnegoAutobusu(firma, linia);
                    trasaZakonczona = true;
                }
                catch (KierowcaNieZnalezionyWyjatek) {
                    Logger.ZalogujBrakDostepnegoKierowcy(firma, linia);
                    trasaZakonczona = true;
                }
            }
        }
    }
}