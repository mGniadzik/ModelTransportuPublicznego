using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace ModelTransportuPublicznego.Model {
    public class Firma {

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

        public void DodajAutobus(Autobus autobus) {
            tabor.Add(autobus);
        }

        public void UsunAutobus(Autobus autobus) {
            tabor.Remove(autobus);
        }

        public void DodajLinieAutobusowa(Linia linia) {
            linieAutobusowe.Add(linia);
        }

        public void UsunLinieAutobusowa(Linia linia) {
            linieAutobusowe.Remove(linia);
        }

        public IEnumerable<Autobus> ZwrocTabor() {
            return tabor;
        }

        public IEnumerable<Kierowca> ZwrocKierowcow() {
            return listaKierowcow;
        }

        public IEnumerable<Linia> ZwrocLinieAutobusowe() {
            return linieAutobusowe;
        }

        public void DodajAutobusy(IEnumerable<Autobus> autobusy) {
            foreach (var autobus in autobusy) {
                tabor.Add(autobus);
            }
        }

        public void DodajKierowcow(IEnumerable<Kierowca> listaKierowcow) {
            foreach (var kierowca in listaKierowcow) {
                this.listaKierowcow.Add(kierowca);
            }
        }

        public void DodajLinie(IEnumerable<Linia> listaLinii) {
            foreach (var linia in listaLinii) {
                linieAutobusowe.Add(linia);
            }
        }

        public List<Przejazd> UtworzListePrzejazdow() {
            var listaPrzejazdow = new List<Przejazd>();

            foreach (var linia in linieAutobusowe) {
                foreach (var wpis in linia.RozkladPrzejazdow.CzasyPrzejazdow) {
                    listaPrzejazdow.Add(new Przejazd(linia, WybierzAutobusDoObslugiPrzejazdu(), WybierzKierowceDoObslugiPrzejazdu(), wpis));
                }
            }

            return listaPrzejazdow;
        }

        protected Autobus WybierzAutobusDoObslugiPrzejazdu() {
            Random rand = new Random();

            return tabor[rand.Next(tabor.Count)];
        }

        protected Kierowca WybierzKierowceDoObslugiPrzejazdu() {
            Random rand = new Random();

            return listaKierowcow[rand.Next(listaKierowcow.Count)];
        }
    }
}