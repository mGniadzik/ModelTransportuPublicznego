using System.Collections.Generic;

namespace ModelTransportuPublicznego.Model {
    public abstract class Linia {
        protected string idLinii;
        protected List<Przystanek> trasaLinii;
        protected List<int> spodziewaneCzasyPrzejazdow;

        public Linia(string idLinii) {
            this.idLinii = idLinii;
            trasaLinii = new List<Przystanek>();
            spodziewaneCzasyPrzejazdow = new List<int>();
        }

        public Linia(string idLinii, IEnumerable<Przystanek> trasaLinii) : this(idLinii) {

            foreach (var przystanek in trasaLinii) {
                this.trasaLinii.Add(przystanek);
            }
        }

        public Linia(string idLinii, IEnumerable<Przystanek> trasaLinii, IEnumerable<int> spodziewaneCzasyPrzejazdow) : this(idLinii, trasaLinii) {
            foreach (var czas in spodziewaneCzasyPrzejazdow) {
                this.spodziewaneCzasyPrzejazdow.Add(czas);
            }
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

        public Przystanek ZwrocPrzystanekIndex(int index) {
            return trasaLinii[index];
        }
    }
}