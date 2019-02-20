using System;
using System.Collections.Generic;

namespace ModelTransportuPublicznego.Model {
    public class Linia {
        protected string idLinii;
        protected RozkladJazdy rozkladPrzejazdow;
        protected List<WpisLinii> trasaLinii;

        public RozkladJazdy RozkladPrzejazdow => rozkladPrzejazdow;

        public Linia(string idLinii) {
            this.idLinii = idLinii;
            trasaLinii = new List<WpisLinii>();
        }

        public Linia(string idLinii, IEnumerable<WpisLinii> trasaLinii) : this(idLinii) {

            foreach (var przystanek in trasaLinii) {
                this.trasaLinii.Add(przystanek);
            }
        }

        public Linia(string idLinii, IEnumerable<WpisLinii> trasaLinii, RozkladJazdy rozkladPrzejazdow) 
            : this(idLinii, trasaLinii) {
            
            this.rozkladPrzejazdow = rozkladPrzejazdow;
        }

        public Przystanek ZwrocNastepnyPrzystanek(Przystanek przystanek) {
            if (trasaLinii[trasaLinii.Count - 1].przystanek == przystanek) {
                throw new ArgumentOutOfRangeException();   
            }

            return trasaLinii[ZwrocIndeksPrzystanku(przystanek) + 1].przystanek;
        }

        public Przystanek ZwrocOstatniPrzystanek() {
            return ZwrocPrzystanekIndeks(trasaLinii.Count - 1);
        }

        public void DodajTrase() {
            // TODO
        }

        public void UsunTrase(Trasa trasa) {
            // TODO
        }

        public IEnumerable<WpisLinii> ZwrocTrasy() {
            return trasaLinii;
        }

        public int ZwrocIndeksPrzystanku(Przystanek przystanek) {
            for (int i = 0; i < trasaLinii.Count; i++) {
                if (trasaLinii[i].przystanek == przystanek) {
                    return i;
                }
            }
            return -1;
        }

        public Przystanek ZwrocPrzystanekIndeks(int indeks) {
            return trasaLinii[indeks].przystanek;
        }
    }
}