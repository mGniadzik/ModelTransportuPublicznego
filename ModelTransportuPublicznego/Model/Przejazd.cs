using System;

namespace ModelTransportuPublicznego.Model {
    public class Przejazd {
        private Linia liniaPrzejazdu;
        private Autobus autobus;
        private Kierowca kierowca;
        private Akcja nastepnaAkcja;
        private Przystanek obecnyPrzystanek;
        private int czasPrzejazdu;

        public Przejazd(Linia liniaPrzejazdu, Autobus autobus, Kierowca kierowca) {
            this.liniaPrzejazdu = liniaPrzejazdu;
            this.autobus = autobus;
            this.kierowca = kierowca;
            nastepnaAkcja = Akcja.PobieraniePasazerow;
            obecnyPrzystanek = liniaPrzejazdu.ZwrocPrzystanekIndex(0);
            czasPrzejazdu = 0;
        }
        
        protected enum Akcja { PobieraniePasazerow, Przejazd, WypuszczniePasazerow };

        public void WykonajNastepnaAkcje() {
            switch (nastepnaAkcja) {
                case Akcja.PobieraniePasazerow:
                    czasPrzejazdu += autobus.PobierzPasazerow(obecnyPrzystanek, liniaPrzejazdu);
                    nastepnaAkcja = Akcja.Przejazd;
                    break;
                case Akcja.Przejazd:
                    nastepnaAkcja = Akcja.WypuszczniePasazerow;
                    break;
                case Akcja.WypuszczniePasazerow:
                    czasPrzejazdu += autobus.WysadzPasazerow(obecnyPrzystanek);
                    nastepnaAkcja = Akcja.PobieraniePasazerow;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}