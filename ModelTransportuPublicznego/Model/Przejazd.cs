using System;

namespace ModelTransportuPublicznego.Model {
    public class Przejazd {
        private Linia liniaPrzejazdu;
        private Autobus autobus;
        private Kierowca kierowca;
        private Akcja nastepnaAkcja;
        private Przystanek obecnyPrzystanek;
        private TimeSpan czasPrzejazdu;
        private TimeSpan rozpoczeciePrzejazdu;
        private bool trasaZakonczona;

        public bool TrasaZakonczona => trasaZakonczona;

        public Przejazd(Linia liniaPrzejazdu, Autobus autobus, Kierowca kierowca, TimeSpan rozpoczeciePrzejazdu) {
            this.liniaPrzejazdu = liniaPrzejazdu;
            this.autobus = autobus;
            this.kierowca = kierowca;
            nastepnaAkcja = Akcja.PobieraniePasazerow;
            obecnyPrzystanek = liniaPrzejazdu.ZwrocPrzystanekIndeks(0);
            czasPrzejazdu = new TimeSpan();
            this.rozpoczeciePrzejazdu = rozpoczeciePrzejazdu;
            trasaZakonczona = false;
        }
        
        protected enum Akcja { PobieraniePasazerow, Przejazd, WypuszczniePasazerow };

        public void WykonajNastepnaAkcje() {
            switch (nastepnaAkcja) {
                case Akcja.PobieraniePasazerow:
                    czasPrzejazdu += new TimeSpan(autobus.PobierzPasazerow(obecnyPrzystanek, liniaPrzejazdu));
                    nastepnaAkcja = Akcja.Przejazd;
                    break;
                case Akcja.Przejazd:
                    nastepnaAkcja = Akcja.WypuszczniePasazerow;
                    var trasa = obecnyPrzystanek.ZnajdzTraseDoNastepnegoPrzystanku(
                        liniaPrzejazdu.ZwrocNastepnyPrzystanek(obecnyPrzystanek));
                    czasPrzejazdu += new TimeSpan(autobus.PrzejedzTrase(trasa));
                    obecnyPrzystanek = trasa.PrzystanekDrugi;
                    nastepnaAkcja = Akcja.WypuszczniePasazerow;
                    break;
                case Akcja.WypuszczniePasazerow:
                    czasPrzejazdu += new TimeSpan(autobus.WysadzPasazerow(obecnyPrzystanek));
                    if (obecnyPrzystanek == liniaPrzejazdu.ZwrocOstatniPrzystanek()) {
                        trasaZakonczona = true;
                        break;
                    }
                    
                    nastepnaAkcja = Akcja.PobieraniePasazerow;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public TimeSpan CzasNastepnejAkcji() {
            return rozpoczeciePrzejazdu + czasPrzejazdu;
        }
    }
}