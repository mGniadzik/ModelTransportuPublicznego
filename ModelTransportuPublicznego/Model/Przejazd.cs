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
        private TimeSpan czasRozpoczeciaPrzejazdu;
        private bool trasaZakonczona;
        private Firma firma;
        private Linia linia;

        public bool TrasaZakonczona => trasaZakonczona;
        
        public TimeSpan CzasNastepnejAkcji => czasRozpoczeciaPrzejazdu + czasPrzejazdu;

        public Firma Firma => firma;

        private Przejazd() {
            autobus = null;
            nastepnaAkcja = Akcja.PobieraniePasazerow;
            czasPrzejazdu = TimeSpan.Zero;
            trasaZakonczona = false;
        }
        
        public Przejazd(Autobus autobus, Firma firma, TimeSpan czasRozpoczeciaPrzejazdu) : this() {
            this.autobus = autobus;
            this.firma = firma;
            linia = autobus.liniaAutobusu;
            obecnyPrzystanek = autobus.liniaAutobusu.ZwrocPrzystanekIndeks(0);
            this.czasRozpoczeciaPrzejazdu = czasRozpoczeciaPrzejazdu;
        }

        public Przejazd(Firma firma, Linia linia, TimeSpan czasRozpoczeciaPrzejazdu) {
            autobus = null;
            this.firma = firma;
            this.czasRozpoczeciaPrzejazdu = czasRozpoczeciaPrzejazdu;
            this.linia = linia;
            obecnyPrzystanek = linia.ZwrocPrzystanekIndeks(0);
        }
        
        protected enum Akcja { PobieraniePasazerow, Przejazd, WypuszczniePasazerow };

        public void WykonajNastepnaAkcje() {
            obecnyPrzystanek.WykonajPrzyplywy(czasRozpoczeciaPrzejazdu + czasPrzejazdu);
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
            var pasazerowie = autobus.StworzListeWsiadajacychPasazerow(obecnyPrzystanek, autobus.liniaAutobusu, czasRozpoczeciaPrzejazdu + czasPrzejazdu);
            var czasAkcji = new TimeSpan(0, 0,autobus.PobierzPasazerow(obecnyPrzystanek, autobus.liniaAutobusu, pasazerowie));
            var spodziewanyCzasPrzyjazdu = linia.SpodziewanyCzasPrzejazduDoPrzystanku(obecnyPrzystanek);                    // Spodziewany czas przez jaki autobus jest w trasie
            var czasRozpoczeciaAkcji = CzasRozpoczeciaAkcji(czasPrzejazdu);
            
            if (czasPrzejazdu + czasAkcji < spodziewanyCzasPrzyjazdu) {                                                    // Aby autobus nie mógł odjechać z przystanku przed spodziewanym czasem.
                czasPrzejazdu = spodziewanyCzasPrzyjazdu;
            }
            else {
                czasPrzejazdu += czasAkcji;
            }
            
            obecnyPrzystanek.RozkladJazdy.UstawJakoOdwiedzony(linia, czasRozpoczeciaPrzejazdu + spodziewanyCzasPrzyjazdu);
                    
            Logger.ZalogujPobieraniePasazerow(czasRozpoczeciaAkcji, autobus, obecnyPrzystanek, pasazerowie.Count, czasRozpoczeciaPrzejazdu + czasPrzejazdu);
                    
            nastepnaAkcja = Akcja.Przejazd;
        }

        private void WykonajPrzejazd() {
            var trasa = obecnyPrzystanek.ZnajdzTraseDoNastepnegoPrzystanku(
                autobus.liniaAutobusu.ZwrocNastepnyPrzystanek(obecnyPrzystanek));
            var czasAkcji = new TimeSpan(0, 0, autobus.PrzejedzTrase(trasa));
            var czasRozpoczeciaAkcji = CzasRozpoczeciaAkcji(czasPrzejazdu);
                    
            czasPrzejazdu += czasAkcji;
            
            Logger.ZalogujPrzejechanieTrasy(czasRozpoczeciaAkcji, autobus, trasa, czasRozpoczeciaPrzejazdu + czasPrzejazdu);
            
            nastepnaAkcja = Akcja.WypuszczniePasazerow;
            obecnyPrzystanek = trasa.PrzystanekPrawy;
        }

        private void WykonajWypuszczaniePasazerow() {
            var pasazerowie = autobus.StworzListeWysiadajacychPasazerow(obecnyPrzystanek);
            var czasAkcji = new TimeSpan(0, 0,autobus.WysadzPasazerow(obecnyPrzystanek, pasazerowie));
            var czasRozpoczeciaAkcji = CzasRozpoczeciaAkcji(czasPrzejazdu);
            
            czasPrzejazdu += czasAkcji;
                    
            Logger.ZalogujWypuszczniePasazerow(czasRozpoczeciaPrzejazdu + czasPrzejazdu, autobus, obecnyPrzystanek, pasazerowie.Count, czasRozpoczeciaPrzejazdu + czasAkcji);
                    
            if (obecnyPrzystanek == autobus.liniaAutobusu.ZwrocOstatniPrzystanek()) {
                trasaZakonczona = true;
                obecnyPrzystanek.UsunAutobus(autobus);
                firma.DodajPrzejazdDoHistorii(this);
                        
                Logger.ZalogujZakonczenieTrasy(czasRozpoczeciaAkcji, autobus, obecnyPrzystanek, autobus.liniaAutobusu, czasRozpoczeciaPrzejazdu + czasPrzejazdu);
                return;
            }

            nastepnaAkcja = Akcja.PobieraniePasazerow;
            obecnyPrzystanek.UsunAutobus(autobus);
        }

        private TimeSpan CzasRozpoczeciaAkcji(TimeSpan czasPrzejazdu) {
            return new TimeSpan(czasRozpoczeciaPrzejazdu.Ticks + czasPrzejazdu.Ticks);
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