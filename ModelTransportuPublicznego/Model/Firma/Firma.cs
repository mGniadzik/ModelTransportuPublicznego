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
        protected List<Linia> linieAutobusowe;
        protected SortedDictionary<Autobus, int> listaAutobusowZajetych;
        protected List<Kierowca> listaKierwcowZajetych;
        protected List<Przejazd> historiaPrzejazdow;
        protected RozkladPrzejazdow przejazdy;
        protected string sciezkaPlikuKonfiguracyjnego;
        protected int liczbaOtrzymanychKar;

        public IEnumerable<Linia> LinieAutobusowe => linieAutobusowe;

        public virtual string NazwaFirmy => nazwaFirmy;

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
            linieAutobusowe = new List<Linia>();
            listaAutobusowZajetych = new SortedDictionary<Autobus, int>();
            listaKierwcowZajetych = new List<Kierowca>();
            historiaPrzejazdow = new List<Przejazd>();
        }

        public Firma(string nazwaFirmy, IEnumerable<KeyValuePair<Autobus, int>> tabor, string sciezkaPlikuKonfiguracyjnego, IEnumerable<Kierowca> listaKierowcow,
            IEnumerable<Linia> linieAutobusowe) : this(nazwaFirmy, sciezkaPlikuKonfiguracyjnego) {
            foreach (var kvp in tabor) {
                dostepnyTabor.Add(kvp.Key, kvp.Value);
            }

            foreach (var kierowca in listaKierowcow) {
                listaDostepnychKierowcow.Add(kierowca);
            }

            foreach (var linia in linieAutobusowe) {
                this.linieAutobusowe.Add(linia);
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

        public virtual void DodajLinieAutobusowa(Linia linia) {
            linieAutobusowe.Add(linia);
        }

        public virtual void UsunLinieAutobusowa(Linia linia) {
            linieAutobusowe.Remove(linia);
        }

        public virtual IEnumerable<KeyValuePair<Autobus, int>> ZwrocDostepnyTabor() {
            return dostepnyTabor;
        }

        public virtual IEnumerable<Kierowca> ZwrocKierowcow() {
            return listaDostepnychKierowcow;
        }

        public virtual IEnumerable<Linia> ZwrocLinieAutobusowe() {
            return linieAutobusowe;
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

        public virtual void DodajLinie(IEnumerable<Linia> listaLinii) {
            foreach (var linia in listaLinii) {
                linieAutobusowe.Add(linia);
            }
        }

        public virtual void DodajLinie(Linia linia) {
            linieAutobusowe.Add(linia);
        }

        public virtual Linia ZwrocLiniePoID(string idLinii)
        {
            foreach (var l in linieAutobusowe)
            {
                if (l.IdLinii == idLinii)
                {
                    return l;
                }
            }

            return null;
        }

        public virtual void UstawLinieNaPrzystankach() {
            DodajWpisyDoRozkladowPrzystankowLinii();
        }

//        public virtual IEnumerable<Przejazd> UtworzListePrzejazdow() {
//            var listaPrzejazdow = new List<Przejazd>();
//
//            foreach (var linia in linieAutobusowe) {
//                foreach (var wpis in linia.RozkladPrzejazdow.CzasyPrzejazdow) {
//                    listaPrzejazdow.Add(new Przejazd(this, linia, wpis));
//                }
//            }
//
//            return listaPrzejazdow;    
//        }

        public virtual IEnumerable<Przejazd> UtworzListePrzejazdow()
        {
            var listaPrzejazdow = new List<Przejazd>();

            foreach (var przejazd in przejazdy)
            {
                listaPrzejazdow.Add(new Przejazd(this, przejazd.Linia, przejazd.CzasPrzejazdu));
            }

            return listaPrzejazdow;
        }

        public virtual void DodajWpisyDoRozkladowPrzystankowLinii()
        {
            foreach (var elem in przejazdy)
            {
                var suma = TimeSpan.Zero;
                foreach (WpisLinii wpis in elem.Linia)
                {
                    suma += wpis.czasPrzyjaduDoPrzystanku;
                    wpis.przystanek.RozkladJazdy.DodajWpisDoRozkladu(new WpisRozkladuJazdy(elem.Linia, elem.CzasPrzejazdu + suma));
                }
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

        public virtual void DodajPrzejazdDoHistorii(Przejazd przejazd) {
            historiaPrzejazdow.Add(przejazd);
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
            foreach (var a in dict.Keys)
            {
                if (a.ModelAutobusu == modelAutobusu)
                {
                    ZajmijAutobus(a);
                }
            }

            return null;
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

            foreach (var l in linieAutobusowe)
            {
                sw.Write(l.SciezkaPlikuKonfiguracyjnego);
                if (l != linieAutobusowe.Last())
                {
                    sw.Write("|");
                }
            }

            sw.WriteLine();

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