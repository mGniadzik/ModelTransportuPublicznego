using System.Collections.Generic;
using System.Security.Cryptography;

namespace ModelTransportuPublicznego.Model {
    public abstract class Firma {

        protected string NazwaFirmy;
        protected List<Autobus> Tabor;
        protected List<Kierowca> ListaKierowcow;
        protected List<Linia> LinieAutobusowe;
        protected int LiczbaOtrzymanychKar;

        public Firma(string nazwaFirmy) {
            this.NazwaFirmy = nazwaFirmy;
            Tabor = new List<Autobus>();
            ListaKierowcow = new List<Kierowca>();
            LinieAutobusowe = new List<Linia>();
        }

        public void DodajAutobus(Autobus autobus) {
            Tabor.Add(autobus);
        }

        public void UsunAutobus(Autobus autobus) {
            Tabor.Remove(autobus);
        }

        public void DodajLinieAutobusowa(Linia linia) {
            LinieAutobusowe.Add(linia);
        }

        public void UsunLinieAutobusowa(Linia linia) {
            LinieAutobusowe.Remove(linia);
        }

        public IEnumerable<Autobus> ZwrocTabor() {
            return Tabor;
        }

        public IEnumerable<Kierowca> ZwrocKierowcow() {
            return ListaKierowcow;
        }

        public IEnumerable<Linia> ZwrocLinieAutobusowe() {
            return LinieAutobusowe;
        }

        public void DodajAutobusy(IEnumerable<Autobus> autobusy) {
            foreach (var autobus in autobusy) {
                Tabor.Add(autobus);
            }
        }

        public void DodajKierowcow(IEnumerable<Kierowca> listaKierowcow) {
            foreach (var kierowca in listaKierowcow) {
                this.ListaKierowcow.Add(kierowca);
            }
        }

        public void DodajLinie(IEnumerable<Linia> listaLinii) {
            foreach (var linia in listaLinii) {
                LinieAutobusowe.Add(linia);
            }
        }
    }
}