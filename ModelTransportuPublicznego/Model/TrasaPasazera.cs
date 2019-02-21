using System.Collections.Generic;
using System.Linq;

namespace ModelTransportuPublicznego.Model {
    public struct TrasaPasazera {
        public Przystanek przystanekPoczatkowy;
        public List<Przystanek> oczekiwanePrzystanki;
        public List<List<Linia>> oczekiwaneLinie;

        public TrasaPasazera(Przystanek przystanekPoczatkowy, IEnumerable<Przystanek> oczekiwanePrzystanki, IEnumerable<IEnumerable<Linia>> oczekiwaneLinie) {
            this.przystanekPoczatkowy = przystanekPoczatkowy;
            this.oczekiwanePrzystanki = new List<Przystanek>();
            this.oczekiwaneLinie = new List<List<Linia>>();

            foreach (var przystanek in oczekiwanePrzystanki) {
                this.oczekiwanePrzystanki.Add(przystanek);
            }

            foreach (var listaLinii in oczekiwaneLinie) {
                var l = listaLinii.ToList();
                this.oczekiwaneLinie.Add(l);
            }
        }

        public List<Linia> ZwrocOczekiwanaLinie() {
            return oczekiwaneLinie[0];
        }

        public Przystanek ZwrocOczekiwanyPrzystanek() {
            return oczekiwanePrzystanki[0];
        }

        public void UsunPierwszaOczekiwanaLinie() {
            oczekiwaneLinie.RemoveAt(0);
        }

        public void UsunPierwszyOczekiwanyPrzystanek() {
            oczekiwanePrzystanki.RemoveAt(0);
        }

        public Przystanek ZwrocPrzystanekKoncowy() {
            return oczekiwanePrzystanki[oczekiwanePrzystanki.Count - 1];
        }
    }
}