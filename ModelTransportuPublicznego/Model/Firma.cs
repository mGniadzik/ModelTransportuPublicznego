using System;
using System.Collections.Generic;

namespace ModelTransportuPublicznego.Model {
    public abstract class Firma {

        protected string NazwaFirmy;
        protected List<Autobus> dostepnyTabor;
        protected List<Kierowca> listaDostepnychKierowcow;
        protected List<Linia> linieAutobusowe;
        protected List<Autobus> listaAutobusowZajetych;
        protected List<Kierowca> listaKierwcowZajetych;
        protected int liczbaOtrzymanychKar;

        public Firma(string nazwaFirmy) {
            this.NazwaFirmy = nazwaFirmy;
            dostepnyTabor = new List<Autobus>();
            listaDostepnychKierowcow = new List<Kierowca>();
            linieAutobusowe = new List<Linia>();
            listaAutobusowZajetych = new List<Autobus>();
            listaKierwcowZajetych = new List<Kierowca>();
        }

        public Firma(string nazwaFirmy, IEnumerable<Autobus> tabor, IEnumerable<Kierowca> listaKierowcow,
            IEnumerable<Linia> linieAutobusowe) : this(nazwaFirmy) {
            foreach (var autobus in tabor) {
                this.dostepnyTabor.Add(autobus);
            }

            foreach (var kierowca in listaKierowcow) {
                this.listaDostepnychKierowcow.Add(kierowca);
            }

            foreach (var linia in linieAutobusowe) {
                this.linieAutobusowe.Add(linia);
            }
        }

        public virtual void DodajAutobus(Autobus autobus) {
            dostepnyTabor.Add(autobus);
        }

        public virtual void UsunAutobus(Autobus autobus) {
            dostepnyTabor.Remove(autobus);
        }

        public virtual void DodajLinieAutobusowa(Linia linia) {
            linieAutobusowe.Add(linia);
        }

        public virtual void UsunLinieAutobusowa(Linia linia) {
            linieAutobusowe.Remove(linia);
        }

        public virtual IEnumerable<Autobus> ZwrocTabor() {
            return dostepnyTabor;
        }

        public virtual IEnumerable<Kierowca> ZwrocKierowcow() {
            return listaDostepnychKierowcow;
        }

        public virtual IEnumerable<Linia> ZwrocLinieAutobusowe() {
            return linieAutobusowe;
        }

        public virtual void DodajAutobusy(IEnumerable<Autobus> autobusy) {
            foreach (var autobus in autobusy) {
                dostepnyTabor.Add(autobus);
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

        public virtual void UstawLinieNaPrzystankach() {
            foreach (var linia in linieAutobusowe) {
                linia.DodajWpisDoRozkladuPrzystankowLinii();
            }
        }

        public abstract IEnumerable<Przejazd> UtworzListePrzejazdow();

        protected abstract Autobus WybierzAutobusDoObslugiPrzejazdu();

        protected abstract Kierowca WybierzKierowceDoObslugiPrzejazdu();

        protected virtual void ZwolnijKierowce(Kierowca kierowca) {
            listaKierwcowZajetych.Remove(kierowca);
            listaDostepnychKierowcow.Add(kierowca);
        }

        protected virtual void ZwolnijAutobus(Autobus autobus) {
            listaAutobusowZajetych.Remove(autobus);
            dostepnyTabor.Add(autobus);
        }
    }
}