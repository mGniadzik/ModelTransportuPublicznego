using ModelTransportuPublicznego.Implementacja.Wyjatki;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ModelTransportuPublicznego.Model.Firma {
    public abstract class Firma {

        protected string nazwaFirmy;
        protected SortedDictionary<Autobus, int> dostepnyTabor;
        protected List<Kierowca> listaDostepnychKierowcow;
        protected SortedDictionary<Autobus, int> listaAutobusowZajetych;
        protected List<Kierowca> listaKierwcowZajetych;
        protected RozkladPrzejazdow przejazdy;
        protected string sciezkaPlikuKonfiguracyjnego;
        protected int liczbaOtrzymanychKar;


        public virtual string NazwaFirmy => nazwaFirmy;

        public virtual double DlugoscNajkrotszegoAutobusu => dostepnyTabor.Keys.Min(a => a.DlugoscAutobusu);

        public virtual string SciezkaPlikuKonfiguracyjnego => sciezkaPlikuKonfiguracyjnego;

        public virtual IEnumerable<KeyValuePair<Autobus, int>> Tabor
        {
            get
            {
                var rezultat = new SortedDictionary<Autobus, int>();

                foreach (var kvp in dostepnyTabor)
                {
                    DodajAutobusDoSlownika(rezultat, kvp.Key, kvp.Value);
                }

                foreach (var kvp in listaAutobusowZajetych)
                {
                    DodajAutobusDoSlownika(rezultat, kvp.Key, kvp.Value);
                }

                return rezultat;
            }
        }

        public Firma(string nazwaFirmy, string sciezkaPlikuKonfiguracyjnego) {
            this.nazwaFirmy = nazwaFirmy;
            this.sciezkaPlikuKonfiguracyjnego = sciezkaPlikuKonfiguracyjnego;
            dostepnyTabor = new SortedDictionary<Autobus, int>();
            listaDostepnychKierowcow = new List<Kierowca>();
            listaAutobusowZajetych = new SortedDictionary<Autobus, int>();
            listaKierwcowZajetych = new List<Kierowca>();
        }

        public Firma(string nazwaFirmy, IEnumerable<KeyValuePair<Autobus, int>> tabor, string sciezkaPlikuKonfiguracyjnego, IEnumerable<Kierowca> listaKierowcow) : this(nazwaFirmy, sciezkaPlikuKonfiguracyjnego) {
            foreach (var kvp in tabor) {
                dostepnyTabor.Add(kvp.Key, kvp.Value);
            }

            foreach (var kierowca in listaKierowcow) {
                listaDostepnychKierowcow.Add(kierowca);
            }
        }

        public virtual void DodajAutobus(Autobus autobus, int ilosc = 1) {
            if (dostepnyTabor.ContainsKey(autobus))
            {
                dostepnyTabor[autobus] += ilosc;
            }
            else
            {
                dostepnyTabor.Add(autobus, ilosc);
            }
        }

        public virtual void UsunAutobus(Autobus autobus)
        {
            if (dostepnyTabor.ContainsKey(autobus))
            {
                dostepnyTabor.Remove(autobus);
            }
        }

        public virtual void UsunAutobus(Autobus autobus, int ilosc) {
            if (dostepnyTabor.ContainsKey(autobus))
            {
                if (dostepnyTabor[autobus] > 1)
                {
                    dostepnyTabor[autobus] -= 1;
                }
            }
        }

        public virtual IEnumerable<KeyValuePair<Autobus, int>> ZwrocDostepnyTabor() {
            return dostepnyTabor;
        }

        public virtual IEnumerable<Kierowca> ZwrocKierowcow() {
            return listaDostepnychKierowcow;
        }

        public virtual void DodajAutobusy(IEnumerable<KeyValuePair<Autobus, int>> autobusy) {
            foreach (var kvp in autobusy) {
                dostepnyTabor.Add(kvp.Key, kvp.Value);
            }
        }

        public virtual void DodajKierowcow(IEnumerable<Kierowca> listaKierowcow) {
            foreach (var kierowca in listaKierowcow) {
                listaDostepnychKierowcow.Add(kierowca);
            }
        }

        public abstract Autobus WybierzAutobusDoObslugiPrzejazdu();

        public abstract Kierowca WybierzKierowceDoObslugiPrzejazdu(Linia linia);

        public virtual bool IstniejaDostepneAutobusy() {
            return dostepnyTabor.Any();
        }

        public virtual bool IstniejaDostepniKierowcy() {
            return listaDostepnychKierowcow.Any();
        }

        protected virtual void ZwolnijKierowce(Kierowca kierowca) {
            listaKierwcowZajetych.Remove(kierowca);
            listaDostepnychKierowcow.Add(kierowca);
        }

        protected virtual void DodajAutobusDoSlownika(SortedDictionary<Autobus, int> dict, Autobus autobus, int liczba)
        {
            if (liczba < 0)
            {
                throw new ArgumentException("Liczba dodawanych autobusów nie mo¿e byæ ujemna.");
            }

            if (dict.ContainsKey(autobus))
            {
                dict[autobus] += liczba;
            }
            else
            {
                dict[autobus] = liczba;
            }
        }

        protected virtual void UsunAutobusZeSlownika(SortedDictionary<Autobus, int> dict, Autobus autobus, int liczba)
        {
            if (liczba < 0)
            {
                throw new ArgumentException("Liczba odejmowanych autobusów nie mo¿e byæ ujemna.");
            }

            if (dict.ContainsKey(autobus) && dict[autobus] >= liczba)
            {
                dict[autobus] -= liczba;
            }
            else
            {
                throw new ArgumentException("S³ownik nie posiada danej liczby danego autobusu.");
            }
        }

        protected virtual Autobus ZwrocAutobusPoModelu(SortedDictionary<Autobus, int> dict, string modelAutobusu)
        {
            Autobus autobus = null;

            foreach (var a in dict.Keys)
            {
                if (a.ModelAutobusu == modelAutobusu)
                {
                    autobus = a;
                }
            }

            return autobus;
        }

        public virtual Autobus ZwrocAutobusPoModelu(string modelAutobusu)
        {
            return ZwrocAutobusPoModelu(dostepnyTabor, modelAutobusu);
        }

        public virtual void ZajmijAutobus(string modelAutobusu)
        {
            var autobus = ZwrocAutobusPoModelu(dostepnyTabor, modelAutobusu);

            if (autobus == null)
            {
                throw new AutobusNieZnalezionyWyjatek();
            }

            ZajmijAutobus(autobus);
        }

        public virtual void ZwolnijAutobus(string modelAutobusu)
        {
            var autobus = ZwrocAutobusPoModelu(listaAutobusowZajetych, modelAutobusu);

            if (autobus == null)
            {
                throw new AutobusNieZnalezionyWyjatek();
            }

            ZwolnijAutobus(autobus);
        }

        public virtual void ZajmijAutobus(Autobus autobus)
        {
            UsunAutobusZeSlownika(dostepnyTabor, autobus, 1);
            DodajAutobusDoSlownika(listaAutobusowZajetych, autobus, 1);
        }

        public virtual void ZwolnijAutobus(Autobus autobus)
        {
            UsunAutobusZeSlownika(listaAutobusowZajetych, autobus, 1);
            DodajAutobusDoSlownika(dostepnyTabor, autobus, 1);
        }

        public virtual bool Zapisz(StreamWriter sw)
        {
            sw.WriteLine(nazwaFirmy);

            var last = Tabor.Last();
            foreach (var kvp in Tabor)
            {
                sw.Write($"{0}:{1}", kvp.Key.SciezkaPlikuKonfiguracyjnego, kvp.Value);
                if (kvp.Key != last.Key)
                {
                    sw.Write("|");
                }
            }

            return true;
        }
    }
}