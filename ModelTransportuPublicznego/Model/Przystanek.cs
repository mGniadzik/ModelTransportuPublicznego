using System.Collections.Generic;

namespace ModelTransportuPublicznego.Model {
    public abstract class Przystanek {
        protected string nazwaPrzystanku;
        protected List<Pasazer> oczekujacyPasazerowie;
        protected List<Trasa> trasy;

        public Przystanek(string nazwaPrzystanku) {
            this.nazwaPrzystanku = nazwaPrzystanku;
            oczekujacyPasazerowie = new List<Pasazer>();
            trasy = new List<Trasa>();
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

        public virtual IEnumerable<Pasazer> ZwrocPasazerowOczekujacychNaLinie(Linia linia) {
            return oczekujacyPasazerowie;
        }

        public virtual Trasa ZnajdzTraseDoNastepnegoPrzystanku(Przystanek nastepnyPrzystanek) {
            foreach (var trasa in trasy) {
                if (trasa.PrzystanekDrugi == nastepnyPrzystanek) {
                    return trasa;
                }
            }

            return null;
        }
    }
}