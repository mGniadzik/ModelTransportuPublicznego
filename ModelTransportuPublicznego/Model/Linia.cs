using System;
using System.Collections.Generic;

namespace ModelTransportuPublicznego.Model {
    public class Linia {
        protected string idLinii;
        protected List<Przystanek> trasaLinii;
        protected RozkladJazdy rozkladPrzejazdow;
        protected List<TimeSpan> spodziewaneCzasyPrzejazdow;

        public RozkladJazdy RozkladPrzejazdow => rozkladPrzejazdow;

        public Linia(string idLinii) {
            this.idLinii = idLinii;
            trasaLinii = new List<Przystanek>();
            spodziewaneCzasyPrzejazdow = new List<TimeSpan>();
        }

        public Linia(string idLinii, IEnumerable<Przystanek> trasaLinii) : this(idLinii) {

            foreach (var przystanek in trasaLinii) {
                this.trasaLinii.Add(przystanek);
            }
        }

        public Linia(string idLinii, IEnumerable<Przystanek> trasaLinii, RozkladJazdy rozkladPrzejazdow, 
            IEnumerable<TimeSpan> spodziewaneCzasyPrzejazdow) : this(idLinii, trasaLinii) {
            this.rozkladPrzejazdow = rozkladPrzejazdow;
            
            foreach (var czas in spodziewaneCzasyPrzejazdow) {
                this.spodziewaneCzasyPrzejazdow.Add(czas);
            }
        }

        public Przystanek ZwrocNastepnyPrzystanek(Przystanek przystanek) {
            if (trasaLinii[trasaLinii.Count - 1] == przystanek) {
                throw new ArgumentOutOfRangeException();   
            }

            return trasaLinii[ZwrocIndeksPrzystanku(przystanek) + 1];
        }

        public Przystanek ZwrocOstatniPrzystanek() {
            return ZwrocPrzystanekIndeks(trasaLinii.Count - 1);
        }

        public void DodajTrase(Trasa trasa) {
            // TODO
        }

        public void UsunTrase(Trasa trasa) {
            // TODO
        }

        public IEnumerable<Przystanek> ZwrocTrasy() {
            return trasaLinii;
        }

        public int ZwrocIndeksPrzystanku(Przystanek przystanek) {
            for (int i = 0; i < trasaLinii.Count; i++) {
                if (trasaLinii[i] == przystanek) {
                    return i;
                }
            }
            return -1;
        }

        public Przystanek ZwrocPrzystanekIndeks(int indeks) {
            return trasaLinii[indeks];
        }
    }
}