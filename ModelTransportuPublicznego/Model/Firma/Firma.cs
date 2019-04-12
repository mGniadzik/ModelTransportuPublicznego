using System;
using System.Collections.Generic;
using System.Linq;

namespace ModelTransportuPublicznego.Model {
    public abstract class Firma {

        protected string nazwaFirmy;
        protected List<Autobus> dostepnyTabor;
        protected List<Kierowca> listaDostepnychKierowcow;
        protected List<Linia> linieAutobusowe;
        protected List<Autobus> listaAutobusowZajetych;
        protected List<Kierowca> listaKierwcowZajetych;
        protected List<Przejazd> historiaPrzejazdow;
        protected int liczbaOtrzymanychKar;

        public IEnumerable<Linia> LinieAutobusowe => linieAutobusowe;

        public virtual string NazwaFirmy => nazwaFirmy;

        public Firma(string nazwaFirmy) {
            this.nazwaFirmy = nazwaFirmy;
            dostepnyTabor = new List<Autobus>();
            listaDostepnychKierowcow = new List<Kierowca>();
            linieAutobusowe = new List<Linia>();
            listaAutobusowZajetych = new List<Autobus>();
            listaKierwcowZajetych = new List<Kierowca>();
            historiaPrzejazdow = new List<Przejazd>();
        }

        public Firma(string nazwaFirmy, IEnumerable<Autobus> tabor, IEnumerable<Kierowca> listaKierowcow,
            IEnumerable<Linia> linieAutobusowe) : this(nazwaFirmy) {
            foreach (var autobus in tabor) {
                dostepnyTabor.Add(autobus);
            }

            foreach (var kierowca in listaKierowcow) {
                listaDostepnychKierowcow.Add(kierowca);
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

        public virtual void DodajLinie(Linia linia) {
            linieAutobusowe.Add(linia);
        }

        public virtual void UstawLinieNaPrzystankach() {
            foreach (var linia in linieAutobusowe) {
                linia.DodajWpisDoRozkladuPrzystankowLinii();
            }
        }

        public virtual IEnumerable<Przejazd> UtworzListePrzejazdow() {
            var listaPrzejazdow = new List<Przejazd>();

            foreach (var linia in linieAutobusowe) {
                foreach (var wpis in linia.RozkladPrzejazdow.CzasyPrzejazdow) {
                    listaPrzejazdow.Add(new Przejazd(this, linia, wpis));
                }
            }

            return listaPrzejazdow;    
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

        protected virtual void ZwolnijAutobus(Autobus autobus) {
            listaAutobusowZajetych.Remove(autobus);
            dostepnyTabor.Add(autobus);
        }

        public virtual void DodajPrzejazdDoHistorii(Przejazd przejazd) {
            historiaPrzejazdow.Add(przejazd);
        }
    }
}