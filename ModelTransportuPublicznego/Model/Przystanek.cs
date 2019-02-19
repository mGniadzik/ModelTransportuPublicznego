using System.Collections.Generic;

namespace ModelTransportuPublicznego.Model {
    public abstract class Przystanek {
        protected string nazwaPrzystanku;
        protected int obecnaLiczbaOczekujacych;
        protected List<Trasa> trasy;

        public Przystanek(string nazwaPrzystanku) {
            this.nazwaPrzystanku = nazwaPrzystanku;
            obecnaLiczbaOczekujacych = 0;
            trasy = new List<Trasa>();
        }

        protected Przystanek(string nazwaPrzystanku, IEnumerable<Trasa> trasy) {
            this.nazwaPrzystanku = nazwaPrzystanku;

            foreach (var trasa in trasy) {
                this.trasy.Add(trasa);
            }
        }

        protected IEnumerable<Trasa> ZwrocTrasyPrzystanku() {
            return trasy;
        }
    }
}