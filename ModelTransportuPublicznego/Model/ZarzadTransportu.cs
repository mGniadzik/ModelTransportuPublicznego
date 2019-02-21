using System;
using System.Collections.Generic;

namespace ModelTransportuPublicznego.Model {
    public abstract class ZarzadTransportu {

        protected string nazwaFirmy;
        protected List<Przystanek> siecPrzystankow;
        protected List<Firma> listaFirm;

        public IEnumerable<Przystanek> SiecPrzystankow => siecPrzystankow;
        public IEnumerable<Firma> ListaFirm => listaFirm;

        public ZarzadTransportu(string nazwaFirmy) {
            this.nazwaFirmy = nazwaFirmy;
            siecPrzystankow = new List<Przystanek>();
            listaFirm = new List<Firma>();
        }

        public ZarzadTransportu(string nazwaFirmy, IEnumerable<Przystanek> siecPrzystankow) : this(nazwaFirmy) {
            foreach (var przystanek in siecPrzystankow) {
                this.siecPrzystankow.Add(przystanek);
            }
            
            listaFirm = new List<Firma>();
        }

        public ZarzadTransportu(string nazwaFirmy, IEnumerable<Firma> listaFirm) : this(nazwaFirmy) {
            foreach (var firma in listaFirm) {
                this.listaFirm.Add(firma);
            }
            
            siecPrzystankow = new List<Przystanek>();
        }

        protected ZarzadTransportu(string nazwaFirmy, IEnumerable<Przystanek> siecPrzystankow, IEnumerable<Firma> listaFirm) : this(nazwaFirmy) {
            foreach (var przystanek in siecPrzystankow) {
                this.siecPrzystankow.Add(przystanek);
            }

            foreach (var firma in listaFirm) {
                this.listaFirm.Add(firma);
            }
        }

        public virtual void DodajPrzystanek(Przystanek przystanek) {
            siecPrzystankow.Add(przystanek);
        }

        public virtual void DodajPrzystanki(IEnumerable<Przystanek> przystanki) {
            foreach (var przystanek in przystanki) {
                siecPrzystankow.Add(przystanek);
            }
        }

        public virtual void UsunPrzystanek(Przystanek przystanek) {
            siecPrzystankow.Remove(przystanek);
        }

        public virtual void DodajFirme(Firma firma) {
            listaFirm.Add(firma);
        }

        public virtual void DodajFirmy(IEnumerable<Firma> firmy) {
            foreach (var firma in firmy) {
                listaFirm.Add(firma);
            }
        }

        public virtual void UsunFirme(Firma firma) {
            listaFirm.Remove(firma);
        }

        public virtual IEnumerable<Linia> ZwrocLinie() {
            var linie = new List<Linia>();

            foreach (var firma in listaFirm) {
                linie.AddRange(firma.ZwrocLinieAutobusowe());
            }

            return linie;
        }

        public abstract void StworzListePrzejazdow();

        public abstract void DodajPrzejazdDoListy(Przejazd przejazd);

        public abstract void WykonajPrzejazdy();
    }
}