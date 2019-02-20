using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace ModelTransportuPublicznego.Model {
    public abstract class Firma {

        protected string NazwaFirmy;
        protected List<Autobus> tabor;
        protected List<Kierowca> listaKierowcow;
        protected List<Linia> linieAutobusowe;
        protected int liczbaOtrzymanychKar;

        public Firma(string nazwaFirmy) {
            this.NazwaFirmy = nazwaFirmy;
            tabor = new List<Autobus>();
            listaKierowcow = new List<Kierowca>();
            linieAutobusowe = new List<Linia>();
        }

        public Firma(string nazwaFirmy, IEnumerable<Autobus> tabor, IEnumerable<Kierowca> listaKierowcow,
            IEnumerable<Linia> linieAutobusowe) : this(nazwaFirmy) {
            foreach (var autobus in tabor) {
                this.tabor.Add(autobus);
            }

            foreach (var kierowca in listaKierowcow) {
                this.listaKierowcow.Add(kierowca);
            }

            foreach (var linia in linieAutobusowe) {
                this.linieAutobusowe.Add(linia);
            }
        }

        public virtual void DodajAutobus(Autobus autobus) {
            tabor.Add(autobus);
        }

        public virtual void UsunAutobus(Autobus autobus) {
            tabor.Remove(autobus);
        }

        public virtual void DodajLinieAutobusowa(Linia linia) {
            linieAutobusowe.Add(linia);
        }

        public virtual void UsunLinieAutobusowa(Linia linia) {
            linieAutobusowe.Remove(linia);
        }

        public virtual IEnumerable<Autobus> ZwrocTabor() {
            return tabor;
        }

        public virtual IEnumerable<Kierowca> ZwrocKierowcow() {
            return listaKierowcow;
        }

        public virtual IEnumerable<Linia> ZwrocLinieAutobusowe() {
            return linieAutobusowe;
        }

        public virtual void DodajAutobusy(IEnumerable<Autobus> autobusy) {
            foreach (var autobus in autobusy) {
                tabor.Add(autobus);
            }
        }

        public virtual void DodajKierowcow(IEnumerable<Kierowca> listaKierowcow) {
            foreach (var kierowca in listaKierowcow) {
                this.listaKierowcow.Add(kierowca);
            }
        }

        public virtual void DodajLinie(IEnumerable<Linia> listaLinii) {
            foreach (var linia in listaLinii) {
                linieAutobusowe.Add(linia);
            }
        }

        public virtual void UstawLinieNaPrzystankach() {
            foreach (var linia in linieAutobusowe) {
                foreach (var wpis in linia.ZwrocTrasy()) {
                    wpis.przystanek.DodajLinie(linia);
                }
            }
        }

        public abstract List<Przejazd> UtworzListePrzejazdow();

        protected abstract Autobus WybierzAutobusDoObslugiPrzejazdu();

        protected abstract Kierowca WybierzKierowceDoObslugiPrzejazdu();
    }
}