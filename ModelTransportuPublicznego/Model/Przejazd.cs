using System;
using System.Collections.Generic;
using ModelTransportuPublicznego.Implementacja.Wyjatki;
using ModelTransportuPublicznego.Misc;

namespace ModelTransportuPublicznego.Model {
    public class Przejazd : IComparable<Przejazd>
    {
        private Autobus autobus;
        private Akcja nastepnaAkcja;
        private Przystanek.Przystanek obecnyPrzystanek;
        private TimeSpan czasPrzejazdu;
        private TimeSpan czasRozpoczeciaPrzejazdu;
        private bool trasaZakonczona;
        private Firma firma;
        private Linia linia;
        private string uid;

        public bool TrasaZakonczona => trasaZakonczona;

        public TimeSpan CzasNastepnejAkcji
        {
            get
            {
                if (autobus != null)
                {
                    return autobus.czasNastepnejAkcji;
                }

                return czasRozpoczeciaPrzejazdu + czasPrzejazdu;
            }
        }

        public Firma Firma => firma;

        private Przejazd()
        {
            autobus = null;
            nastepnaAkcja = Akcja.PobieraniePasazerow;
            czasPrzejazdu = TimeSpan.Zero;
            trasaZakonczona = false;
            uid = UidGenerator.WygenerujUid();
        }

        public Przejazd(Autobus autobus, Firma firma, TimeSpan czasRozpoczeciaPrzejazdu) : this()
        {
            this.autobus = autobus;
            this.firma = firma;
            linia = autobus.liniaAutobusu;
            obecnyPrzystanek = autobus.liniaAutobusu.ZwrocPrzystanekIndeks(0);
            this.czasRozpoczeciaPrzejazdu = czasRozpoczeciaPrzejazdu;
        }

        public Przejazd(Firma firma, Linia linia, TimeSpan czasRozpoczeciaPrzejazdu) : this()
        {
            autobus = null;
            this.firma = firma;
            this.czasRozpoczeciaPrzejazdu = czasRozpoczeciaPrzejazdu;
            this.linia = linia;
            obecnyPrzystanek = linia.ZwrocPrzystanekIndeks(0);
        }

        protected enum Akcja
        {
            PobieraniePasazerow,
            Przejazd,
            WypuszczniePasazerow
        };

        public void WykonajNastepnaAkcje()
        {
            obecnyPrzystanek.WykonajPrzyplywy(czasRozpoczeciaPrzejazdu + czasPrzejazdu);
            SprawdzCzyPrzejazdPosiadaAutobus();

            if (trasaZakonczona)
            {
                return;
            }

            switch (nastepnaAkcja)
            {
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

        public int CompareTo(Przejazd other)
        {
            if (other == null) return 1;

            return CzasNastepnejAkcji.CompareTo(other.CzasNastepnejAkcji);
        }

        private void WykonajPobieraniaPasazerow()
        {

            obecnyPrzystanek.UsunPrasazerowBezTrasy();
            obecnyPrzystanek.DodajAutobus(autobus);
            var pasazerowie = autobus.StworzListeWsiadajacychPasazerow(obecnyPrzystanek, autobus.liniaAutobusu,
                czasRozpoczeciaPrzejazdu + czasPrzejazdu);
            var czasAkcji = new TimeSpan(0, 0,
                autobus.PobierzPasazerow(obecnyPrzystanek, autobus.liniaAutobusu, pasazerowie));
            var spodziewanyCzasPrzyjazdu =
                linia.SpodziewanyCzasPrzejazduDoPrzystanku(
                    obecnyPrzystanek); // Spodziewany czas przez jaki autobus jest w trasie
            var czasRozpoczeciaAkcji = CzasRozpoczeciaAkcji(czasPrzejazdu);

            if (czasPrzejazdu + czasAkcji < spodziewanyCzasPrzyjazdu)
            {
                // Aby autobus nie mógł odjechać z przystanku przed spodziewanym czasem.
                czasPrzejazdu = spodziewanyCzasPrzyjazdu;
            }
            else
            {
                czasPrzejazdu += czasAkcji;
            }

            obecnyPrzystanek.RozkladJazdy.UstawJakoOdwiedzony(linia,
                czasRozpoczeciaPrzejazdu + spodziewanyCzasPrzyjazdu);
            autobus.czasNastepnejAkcji = czasRozpoczeciaPrzejazdu + czasPrzejazdu;

            Logger.ZalogujPobieraniePasazerow(czasRozpoczeciaAkcji, autobus, obecnyPrzystanek, pasazerowie.Count,
                czasRozpoczeciaPrzejazdu + czasPrzejazdu);

            UstawCzasyAkcjiPojazdowOczekujacych(CzasNastepnejAkcji);
            nastepnaAkcja = Akcja.Przejazd;
        }

        private void WykonajPrzejazd()
        {
            obecnyPrzystanek.UsunAutobus(autobus);
            obecnyPrzystanek.DodajAutobusDoZatoki();
            var trasa = obecnyPrzystanek.ZnajdzTraseDoNastepnegoPrzystanku(
                autobus.liniaAutobusu.ZwrocNastepnyPrzystanek(obecnyPrzystanek));

            var czasAkcji = new TimeSpan(0, 0, autobus.PrzejedzTrase(trasa));
            var czasRozpoczeciaAkcji = CzasRozpoczeciaAkcji(czasPrzejazdu);

            czasPrzejazdu += czasAkcji;

            Logger.ZalogujPrzejechanieTrasy(uid, czasRozpoczeciaAkcji, autobus, trasa,
                czasRozpoczeciaPrzejazdu + czasPrzejazdu);
            autobus.czasNastepnejAkcji = czasRozpoczeciaPrzejazdu + czasPrzejazdu;

            nastepnaAkcja = Akcja.WypuszczniePasazerow;
            obecnyPrzystanek = trasa.PrzystanekPrawy;
        }

        private void WykonajWypuszczaniePasazerow()
        {

            var czasRozpoczeciaAkcji = CzasRozpoczeciaAkcji(czasPrzejazdu);
            List<Pasazer> pasazerowie;
            TimeSpan czasAkcji;

            if (obecnyPrzystanek == autobus.liniaAutobusu.ZwrocOstatniPrzystanek())
            {
                trasaZakonczona = true;
                obecnyPrzystanek.UsunAutobus(autobus);
                firma.DodajPrzejazdDoHistorii(this);
                autobus.WypuscWszystkichPasazerow(obecnyPrzystanek);

                pasazerowie = autobus.ObecniPasazerowie;
                czasAkcji = new TimeSpan(0, 0, autobus.WysadzPasazerow(obecnyPrzystanek, pasazerowie));
                Logger.ZalogujWypuszczniePasazerow(czasRozpoczeciaPrzejazdu + czasPrzejazdu, autobus, obecnyPrzystanek,
                    pasazerowie.Count, czasRozpoczeciaPrzejazdu + czasAkcji);
                Logger.ZalogujZakonczenieTrasy(czasRozpoczeciaAkcji, autobus, obecnyPrzystanek, autobus.liniaAutobusu,
                    czasRozpoczeciaPrzejazdu + czasPrzejazdu);
                return;
            }

            pasazerowie = autobus.StworzListeWysiadajacychPasazerow(obecnyPrzystanek);
            czasAkcji = new TimeSpan(0, 0, autobus.WysadzPasazerow(obecnyPrzystanek, pasazerowie));

            czasPrzejazdu += czasAkcji;

            Logger.ZalogujWypuszczniePasazerow(czasRozpoczeciaAkcji, autobus, obecnyPrzystanek, pasazerowie.Count,
                czasRozpoczeciaPrzejazdu + czasPrzejazdu);
            autobus.czasNastepnejAkcji = czasRozpoczeciaPrzejazdu + czasPrzejazdu;

            UstawCzasyAkcjiPojazdowOczekujacych(CzasNastepnejAkcji);
            nastepnaAkcja = Akcja.PobieraniePasazerow;
        }

        private TimeSpan CzasRozpoczeciaAkcji(TimeSpan czasRozpoczecia)
        {
            return new TimeSpan(czasRozpoczeciaPrzejazdu.Ticks + czasRozpoczecia.Ticks);
        }

        private void SprawdzCzyPrzejazdPosiadaAutobus()
        {
            if (autobus == null)
            {
                try
                {
                    var tmpAutobus = firma.WybierzAutobusDoObslugiPrzejazdu();
                    var kierowca = firma.WybierzKierowceDoObslugiPrzejazdu(linia);

                    tmpAutobus.kierowcaAutobusu = kierowca;
                    tmpAutobus.liniaAutobusu = linia;
                    tmpAutobus.czasNastepnejAkcji = czasRozpoczeciaPrzejazdu;
                    autobus = tmpAutobus;
                }
                catch (AutobusNieZnalezionyWyjatek)
                {
                    Logger.ZalogujBrakDostepnegoAutobusu(firma, linia);
                    trasaZakonczona = true;
                }
                catch (KierowcaNieZnalezionyWyjatek)
                {
                    Logger.ZalogujBrakDostepnegoKierowcy(firma, linia);
                    trasaZakonczona = true;
                }
            }
        }

        private void UstawCzasyAkcjiPojazdowOczekujacych(TimeSpan czas)
        {
            foreach (var a in obecnyPrzystanek.AutobusyOczekujace)
            {
                a.czasNastepnejAkcji = czas + new TimeSpan(0, 0, 30);
            }
        }
    }
}