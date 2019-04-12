using System.Collections.Generic;
using System.Linq;

namespace ModelTransportuPublicznego.Model {
    public abstract class ZarzadTransportu {

        protected string nazwaFirmy;
        protected List<Przystanek.Przystanek> siecPrzystankow;
        protected List<Firma> listaFirm;

        public IEnumerable<Przystanek.Przystanek> SiecPrzystankow => siecPrzystankow;
        public IEnumerable<Firma> ListaFirm => listaFirm;

        public ZarzadTransportu(string nazwaFirmy) {
            this.nazwaFirmy = nazwaFirmy;
            siecPrzystankow = new List<Przystanek.Przystanek>();
            listaFirm = new List<Firma>();
        }

        public ZarzadTransportu(string nazwaFirmy, IEnumerable<Przystanek.Przystanek> siecPrzystankow) : this(nazwaFirmy) {
            foreach (var przystanek in siecPrzystankow) {
                this.siecPrzystankow.Add(przystanek);
            }
            
            listaFirm = new List<Firma>();
        }

        public ZarzadTransportu(string nazwaFirmy, IEnumerable<Firma> listaFirm) : this(nazwaFirmy) {
            foreach (var firma in listaFirm) {
                this.listaFirm.Add(firma);
            }
            
            siecPrzystankow = new List<Przystanek.Przystanek>();
        }

        protected ZarzadTransportu(string nazwaFirmy, IEnumerable<Przystanek.Przystanek> siecPrzystankow, IEnumerable<Firma> listaFirm) : this(nazwaFirmy) {
            foreach (var przystanek in siecPrzystankow) {
                this.siecPrzystankow.Add(przystanek);
            }

            foreach (var firma in listaFirm) {
                this.listaFirm.Add(firma);
            }
        }

        public virtual void DodajPrzystanek(Przystanek.Przystanek przystanek) {
            siecPrzystankow.Add(przystanek);
        }

        public virtual void DodajPrzystanki(IEnumerable<Przystanek.Przystanek> przystanki) {
            foreach (var przystanek in przystanki) {
                siecPrzystankow.Add(przystanek);
            }
        }

        public virtual void UsunPrzystanek(Przystanek.Przystanek przystanek) {
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
                linie.AddRange(firma.LinieAutobusowe);
            }

            return linie;
        }

        public abstract void StworzListePrzejazdow();

        public abstract void DodajPrzejazdDoListy(Przejazd przejazd);

        public abstract void WykonajPrzejazdy();

        public virtual void StworzRozkladJazdyNaPrzystankach() {
            foreach (var firma in listaFirm) {
                firma.UstawLinieNaPrzystankach();
            }
        }

        public virtual void DodajLiniePowrotne() {
            var linie = new List<Linia>();
            
            foreach (var firma in listaFirm) {
                linie.AddRange(firma.LinieAutobusowe.Select(linia => linia.LiniaOdwrotna));
                firma.DodajLinie(linie);
            }
        }

        public virtual Przystanek.Przystanek ZwrocPrzystanekPodanejSpecyfikacji(string sciezkaPlikuKonfiguracjiPrzystanku)
        {
            foreach (var p in siecPrzystankow)
            {
                if (p.SciezkaPlikuKonfiguracyjnego == sciezkaPlikuKonfiguracjiPrzystanku)
                {
                    return p;
                }
            }

            return null;
        }
    }
}