using System;
using System.Collections.Generic;

namespace ModelTransportuPublicznego.Model {
    public abstract class ZarzadTransportu {
        
        protected List<Przystanek> siecPrzystankow;
        protected List<Firma> listaFirm;
        protected List<Przejazd> listaPrzejazdow;

        public IEnumerable<Przystanek> SiecPrzystankow => siecPrzystankow;
        public IEnumerable<Firma> ListaFirm => listaFirm;

        protected ZarzadTransportu() {
            siecPrzystankow = new List<Przystanek>();
            listaFirm = new List<Firma>();
        }

        protected ZarzadTransportu(IEnumerable<Przystanek> siecPrzystankow) : this() {
            foreach (var przystanek in siecPrzystankow) {
                this.siecPrzystankow.Add(przystanek);
            }
            
            listaFirm = new List<Firma>();
        }

        protected ZarzadTransportu(IEnumerable<Firma> listaFirm) : this() {
            foreach (var firma in listaFirm) {
                this.listaFirm.Add(firma);
            }
            
            siecPrzystankow = new List<Przystanek>();
        }

        protected ZarzadTransportu(IEnumerable<Przystanek> siecPrzystankow, IEnumerable<Firma> listaFirm) : this() {
            foreach (var przystanek in siecPrzystankow) {
                this.siecPrzystankow.Add(przystanek);
            }

            foreach (var firma in listaFirm) {
                this.listaFirm.Add(firma);
            }
        }

        public void DodajPrzystanek(Przystanek przystanek) {
            siecPrzystankow.Add(przystanek);
        }

        public void DodajPrzystanki(IEnumerable<Przystanek> przystanki) {
            foreach (var przystanek in przystanki) {
                siecPrzystankow.Add(przystanek);
            }
        }

        public void UsunPrzystanek(Przystanek przystanek) {
            siecPrzystankow.Remove(przystanek);
        }

        public void DodajFirme(Firma firma) {
            listaFirm.Add(firma);
        }

        public void DodajFirmy(IEnumerable<Firma> firmy) {
            foreach (var firma in firmy) {
                listaFirm.Add(firma);
            }
        }

        public void UsunFirme(Firma firma) {
            listaFirm.Remove(firma);
        }

        public void UzupelnijListePrzejazdow() {
            foreach (var firma in listaFirm) {
                listaPrzejazdow.AddRange(firma.UtworzListePrzejazdow());
            }
            
            listaPrzejazdow.Sort();
        }
    }
}