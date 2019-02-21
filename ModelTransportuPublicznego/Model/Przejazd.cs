using System;

namespace ModelTransportuPublicznego.Model {
    public class Przejazd : IComparable<Przejazd> {
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
            czasPrzejazdu = TimeSpan.Zero;
            this.rozpoczeciePrzejazdu = rozpoczeciePrzejazdu;
            trasaZakonczona = false;
        }
        
        protected enum Akcja { PobieraniePasazerow, Przejazd, WypuszczniePasazerow };

        public void WykonajNastepnaAkcje() {
            switch (nastepnaAkcja) {
                case Akcja.PobieraniePasazerow:
                    
                    czasPrzejazdu += new TimeSpan(0, 0,autobus.PobierzPasazerow(obecnyPrzystanek, liniaPrzejazdu));
                    nastepnaAkcja = Akcja.Przejazd;

                    Console.WriteLine("Pobrano Pasazerow z przystanku {0}", obecnyPrzystanek.NazwaPrzystanku);
                    
                    break;
                case Akcja.Przejazd:
                    var trasa = obecnyPrzystanek.ZnajdzTraseDoNastepnegoPrzystanku(
                        liniaPrzejazdu.ZwrocNastepnyPrzystanek(obecnyPrzystanek));
                    czasPrzejazdu += new TimeSpan(0, 0, autobus.PrzejedzTrase(trasa));

                    Console.WriteLine("Przejechano Trase! z {0} pasazerami.", autobus.IloscPasazerow());
                    
                    nastepnaAkcja = Akcja.WypuszczniePasazerow;
                    obecnyPrzystanek = trasa.PrzystanekDrugi;
                    break;
                case Akcja.WypuszczniePasazerow:
                    czasPrzejazdu += new TimeSpan(0, 0,autobus.WysadzPasazerow(obecnyPrzystanek));
                    
                    Console.WriteLine("Wypuszczono Pasazerow na przystanku {0}", obecnyPrzystanek.NazwaPrzystanku);
                    
                    if (obecnyPrzystanek == liniaPrzejazdu.ZwrocOstatniPrzystanek()) {
                        trasaZakonczona = true;
                        Console.WriteLine("Zakonczono trase!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
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

        public int CompareTo(Przejazd other) {
            if (other == null) return 1;

            return CzasNastepnejAkcji().CompareTo(other.CzasNastepnejAkcji());
        }
    }
}