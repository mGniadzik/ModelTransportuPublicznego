using System;
using System.Collections.Generic;
using System.Linq;

namespace ModelTransportuPublicznego.Model {
    public class Przystanek {
        protected string nazwaPrzystanku;
        protected List<Pasazer> oczekujacyPasazerowie;
        protected List<Trasa> trasy;
        protected RozkladJazdy rozkladJazdy;
        protected List<Autobus> obecneAutobusy;

        public string NazwaPrzystanku => nazwaPrzystanku;

        public RozkladJazdy RozkladJazdy => rozkladJazdy;

        public IEnumerable<Autobus> ObecneAutobusy => obecneAutobusy;

        public Przystanek(string nazwaPrzystanku) {
            this.nazwaPrzystanku = nazwaPrzystanku;
            oczekujacyPasazerowie = new List<Pasazer>();
            trasy = new List<Trasa>();
            rozkladJazdy = new RozkladJazdy();
            obecneAutobusy = new List<Autobus>();
        }

        protected Przystanek(string nazwaPrzystanku, IEnumerable<Trasa> trasy) : this(nazwaPrzystanku) {
            foreach (var trasa in trasy) {
                this.trasy.Add(trasa);
            }
        }

        protected Przystanek(string nazwaPrzystanku, IEnumerable<Trasa> trasy, IEnumerable<Pasazer> oczekujacyPasazerowie) : this(nazwaPrzystanku, trasy) {
            foreach (var pasazer in oczekujacyPasazerowie) {
                this.oczekujacyPasazerowie.Add(pasazer);
            }
        }

        protected IEnumerable<Trasa> ZwrocTrasyPrzystanku() {
            return trasy;
        }

        public virtual void UsunPasazera(Pasazer pasazer) {
            this.oczekujacyPasazerowie.Remove(pasazer);
        }
        
        public virtual void DodajPasazera(Pasazer pasazer) {
            this.oczekujacyPasazerowie.Add(pasazer);
        }

        public virtual void DodajTrase(Trasa trasa) {
            trasy.Add(trasa);
        }

        public virtual IEnumerable<Pasazer> ZwrocPasazerowOczekujacychNaLinie(Linia linia) {
            var oczekujacyNaLinie = new List<Pasazer>();
            
            foreach (var pasazer in oczekujacyPasazerowie) {
                if (pasazer.OczekiwanaLinia == linia) {
                    oczekujacyNaLinie.Add(pasazer);
                }
            }

            return oczekujacyNaLinie;
        }

        public virtual int IloscPasazerowOczekujacych() {
            return oczekujacyPasazerowie.Count;
        }

        public virtual Trasa ZnajdzTraseDoNastepnegoPrzystanku(Przystanek nastepnyPrzystanek) {
            foreach (var trasa in trasy) {
                if (trasa.PrzystanekDrugi == nastepnyPrzystanek) {
                    return trasa;
                }
            }

            return null;
        }

        public virtual void DodajAutobus(Autobus autobus) {
            obecneAutobusy.Add(autobus);
        }

        public virtual void UsunAutobus(Autobus autobus) {
            obecneAutobusy.Remove(autobus);
        }

        public virtual IEnumerable<WpisRozkladuJazdy> PozostalePrzejazdy() {
            var rezultat = new List<WpisRozkladuJazdy>();

            foreach (var wpis in rozkladJazdy) {
                if (!wpis.CzyWykonany) {
                    rezultat.Add(wpis);
                }
            }
            
            return rezultat;
        }

        public virtual IEnumerable<Linia> PozostaleLiniePrzejazdow() {
            var rezultat = new List<Linia>();

            foreach (var wpis in PozostalePrzejazdy()) {
                if (rezultat.Contains(wpis.LiniaObslugujaca)) continue;

                if (!wpis.LiniaObslugujaca.JestPrzystankiemKoncowym(this)) {
                    rezultat.Add(wpis.LiniaObslugujaca);
                }
            }

            return rezultat;
        }

        public virtual void OznaczPrzejazdJakoWykonany(Linia linia) {
            var lista = rozkladJazdy.ZwrocRozkladJazdy().Where(wpis => wpis.CzyWykonany = false)
                .OrderBy(wpis => wpis.CzasPrzyjazdu).ToList();

            foreach (var wpis in lista) {
                if (wpis.LiniaObslugujaca == linia) {
                    wpis.CzyWykonany = true;
                    return;
                }
            }
        }
    }
}