using System;

namespace ModelTransportuPublicznego.Model {
    public class Przejazd {
        private Linia liniaPrzejazdu;
        private Autobus autobus;
        private Kierowca kierowca;
        private Akcja obecnaAkcja;
        private Przystanek obecnyPRzystanek;
        private int obecnyCzas;

        public Przejazd(Linia liniaPrzejazdu, Autobus autobus, Kierowca kierowca) {
            this.liniaPrzejazdu = liniaPrzejazdu;
            this.autobus = autobus;
            this.kierowca = kierowca;
            obecnaAkcja = Akcja.PobieraniePasazerow;
            obecnyPRzystanek = liniaPrzejazdu.ZwrocPrzystanekIndex(0);
            obecnyCzas = 0;
        }
        
        protected enum Akcja { PobieraniePasazerow, Przejazd, WypuszczniePasazerow };

        public void WykonajNastepnaAkcje() {
            switch (obecnaAkcja) {
                case Akcja.PobieraniePasazerow:
                    
                    break;
                case Akcja.Przejazd:
                    break;
                case Akcja.WypuszczniePasazerow:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}