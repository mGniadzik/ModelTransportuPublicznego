using System.Collections.Generic;
using System.Linq;

namespace ModelTransportuPublicznego.Model {
    public abstract class Pasazer {
        protected Przystanek przystanekPoczatkowy;
        protected Przystanek przystanekKoncowy;
        protected Przystanek obecnyPrzystanek;
        protected int czasWsiadania;
        protected int czasWysiadania;
        protected List<Przystanek> trasaPasazera;
        protected Linia oczekiwanaLinia;

        public Linia OczekiwanaLinia => oczekiwanaLinia;

        public Przystanek OczekiwanyPrzystanek => trasaPasazera[0];

        public Przystanek PrzystanekKoncowy => przystanekKoncowy;

        public int CzasWsiadania => czasWsiadania;

        public int CzasWysiadania => czasWysiadania;

        public Pasazer(IEnumerable<Przystanek> trasaPasazera) {
            this.trasaPasazera = new List<Przystanek>();

            foreach (var przystanek in trasaPasazera) {
                this.trasaPasazera.Add(przystanek);
            }
        }

        protected abstract void Wysiadz();

        protected abstract void Wsiadz();
        

        public Pasazer(List<Przystanek> trasaPasazera, int czasWsiadania, int czasWysiadania) : this(trasaPasazera) {
            this.czasWsiadania = czasWsiadania;
            this.czasWysiadania = czasWysiadania;
        }
        
        public Pasazer(List<Przystanek> trasaPasazera, int czasWsiadania, int czasWysiadania, Przystanek przystanekPoczatkowy, Przystanek przystanekKoncowy) 
            : this(trasaPasazera, czasWsiadania, czasWysiadania) {
            this.przystanekPoczatkowy = przystanekPoczatkowy;
            this.przystanekKoncowy = przystanekKoncowy;
        }

        public virtual void WybierzKolejke(List<List<Pasazer>> listaKolejek) {
            var obecnyWybor = listaKolejek.ElementAt(0);

            foreach (var lista in listaKolejek) {
                if (lista.Count < obecnyWybor.Count) {
                    obecnyWybor = lista;
                }   
            }

            obecnyWybor.Add(this);
        }
    }
}