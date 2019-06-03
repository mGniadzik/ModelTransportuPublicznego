using System;
using System.Collections.Generic;
using System.IO;
using ModelTransportuPublicznego.Implementacja.Autobusy;
using ModelTransportuPublicznego.Implementacja.Wyjatki;
using ModelTransportuPublicznego.Model;
using ModelTransportuPublicznego.Model.Firma;

namespace ModelTransportuPublicznego.Implementacja.Firmy {
    public class FirmaLosowa : Firma {
        Random rand;

        public FirmaLosowa(string nazwaFirmy, string sciezkaPlikuKonfiguracyjnego) : base(nazwaFirmy, sciezkaPlikuKonfiguracyjnego) {
            rand = new Random();
        }

        public FirmaLosowa(string nazwaFirmy, IEnumerable<KeyValuePair<Autobus, int>> tabor, string sciezkaPlikuKonfiguracyjnego, 
            IEnumerable<Kierowca> listaKierowcow) : base(nazwaFirmy, tabor, sciezkaPlikuKonfiguracyjnego, listaKierowcow) {
            rand = new Random();
        }

        public override Autobus WybierzAutobusDoObslugiPrzejazdu() {
            if (!IstniejaDostepneAutobusy()) {
                throw new AutobusNieZnalezionyWyjatek("Nie instnieja autobusy, które moglyby obsłużyć dany przejazd.");
            }

            List<Autobus> klucze = new List<Autobus>(dostepnyTabor.Keys);
            Autobus rezultat;

            do
            {
                rezultat = klucze[rand.Next(klucze.Count)];
            } while (dostepnyTabor[rezultat] > 0);

            ZajmijAutobus(rezultat);

            return rezultat;
        }

        public override Kierowca WybierzKierowceDoObslugiPrzejazdu(Linia linia) {
            if (!IstniejaDostepniKierowcy()) {
                throw new KierowcaNieZnalezionyWyjatek("Nie istnieja kierowcy, którzy mogliby obsłużyć dany przejazd.");
            }

            Kierowca kierowca;
            int wybor;
            do
            {
                wybor = rand.Next(listaDostepnychKierowcow.Count);
                kierowca = listaDostepnychKierowcow[wybor];
            } while (!kierowca.CzyMozeWykonacPrzejazd(linia.ZwrocSpodziewanyCzasPrzejazduLinii()));

            listaDostepnychKierowcow.RemoveAt(wybor);
            listaKierwcowZajetych.Add(kierowca);
            
            return kierowca;
        }

        public static FirmaLosowa OdczytajPlik(string sciezkaPliku, ZarzadTransportu zt)
        {
            FirmaLosowa rezultat;

            using (var sr = File.OpenText(sciezkaPliku))
            {
                rezultat = new FirmaLosowa(sr.ReadLine(), sciezkaPliku);
                var liczbaKierowcow = Convert.ToInt32(sr.ReadLine());
                var tabor = sr.ReadLine().Split('|');
                var kierowcy = new List<Kierowca>();

                for (int i = 0; i < liczbaKierowcow; i++)
                {
                    kierowcy.Add(new Kierowca());
                }

                rezultat.DodajKierowcow(kierowcy);

                foreach (var dane in tabor)
                {
                    var daneAutobusu = dane.Split('-');
                    rezultat.DodajAutobus(AutobusLiniowy.OdczytajPlik(daneAutobusu[0]), Convert.ToInt32(daneAutobusu[1]));
                }
            }

            return rezultat;
        }
    }
}