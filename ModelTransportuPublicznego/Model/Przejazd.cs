using System;
using System.Collections.Generic;
using System.Linq;
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

        public bool TrasaZakonczona => trasaZakonczona;

        public Przejazd(Autobus autobus, Firma firma, TimeSpan rozpoczeciePrzejazdu) {
            this.autobus = autobus;
            this.firma = firma;
            nastepnaAkcja = Akcja.PobieraniePasazerow;
            obecnyPrzystanek = autobus.liniaAutobusu.ZwrocPrzystanekIndeks(0);
            czasPrzejazdu = TimeSpan.Zero;
            this.rozpoczeciePrzejazdu = rozpoczeciePrzejazdu;
            trasaZakonczona = false;
        }
        
        protected enum Akcja { PobieraniePasazerow, Przejazd, WypuszczniePasazerow };

        public void WykonajNastepnaAkcje() {
            TimeSpan czasAkcji;
            List<Pasazer> pasazerowie;
            
            switch (nastepnaAkcja) {
                case Akcja.PobieraniePasazerow:
                    obecnyPrzystanek.DodajAutobus(autobus);
                    pasazerowie = autobus.StworzListeWsiadajacychPasazerow(obecnyPrzystanek, autobus.liniaAutobusu);
                    czasAkcji = new TimeSpan(0, 0,autobus.PobierzPasazerow(obecnyPrzystanek, autobus.liniaAutobusu, pasazerowie));
                    czasPrzejazdu += czasAkcji;
                    
                    Logger.ZalogujPobieraniePasazerow(autobus, obecnyPrzystanek, pasazerowie.Count, czasAkcji);
                    
                    nastepnaAkcja = Akcja.Przejazd;
                    break;
                case Akcja.Przejazd:
                    var trasa = obecnyPrzystanek.ZnajdzTraseDoNastepnegoPrzystanku(
                        autobus.liniaAutobusu.ZwrocNastepnyPrzystanek(obecnyPrzystanek));
                    czasAkcji = new TimeSpan(0, 0, autobus.PrzejedzTrase(trasa));
                    
                    Logger.ZalogujPrzejechanieTrasy(autobus, trasa, czasAkcji);

                    czasPrzejazdu += czasAkcji;
                    nastepnaAkcja = Akcja.WypuszczniePasazerow;
                    obecnyPrzystanek = trasa.PrzystanekDrugi;
                    break;
                case Akcja.WypuszczniePasazerow:
                    pasazerowie = autobus.StworzListeWysiadajacychPasazerow(obecnyPrzystanek);
                    czasAkcji = new TimeSpan(0, 0,autobus.WysadzPasazerow(obecnyPrzystanek, pasazerowie));
                    czasPrzejazdu += czasAkcji;
                    
                    Logger.ZalogujWypuszczniePasazerow(autobus, obecnyPrzystanek, pasazerowie.Count, czasAkcji);
                    
                    if (obecnyPrzystanek == autobus.liniaAutobusu.ZwrocOstatniPrzystanek()) {
                        trasaZakonczona = true;
                        obecnyPrzystanek.UsunAutobus(autobus);
                        
                        Logger.ZalogujZakonczenieTrasy(autobus, obecnyPrzystanek, autobus.liniaAutobusu, czasPrzejazdu);
                        
                        break;
                    }

                    nastepnaAkcja = Akcja.PobieraniePasazerow;
                    obecnyPrzystanek.UsunAutobus(autobus);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public TimeSpan CzasNastepnejAkcji() {
            return rozpoczeciePrzejazdu + czasPrzejazdu;
        }

        public int CompareTo(Przejazd other) {
            if (other == null) return 1;

            return CzasNastepnejAkcji().CompareTo(other.CzasNastepnejAkcji());
        }
        
        
    }
}