using System.Collections.Generic;
using System.Linq;

namespace ModelTransportuPublicznego.Model {
    public abstract class Pasazer {
        protected Przystanek przystanekPoczatkowy;
        protected Przystanek przystanekKoncowy;
        protected Przystanek obecnyPrzystanek;
        protected Przystanek oczekiwanyPrzystanek;
        protected int czasWsiadania;
        protected int czasWysiadania;
        protected List<Przystanek> trasaPasazera;


        public virtual Przystanek OczekiwanyPrzystanek => trasaPasazera[0];

        public virtual Linia OczekiwanaLinia => WybierzLinie();

        public virtual Przystanek PrzystanekKoncowy => przystanekKoncowy;

        public virtual int CzasWsiadania => czasWsiadania;

        public virtual int CzasWysiadania => czasWysiadania;

        public Pasazer() {
            trasaPasazera = new List<Przystanek>();
        }
        
        public Pasazer(IEnumerable<Przystanek> trasaPasazera) : this() {
            foreach (var przystanek in trasaPasazera) {
                this.trasaPasazera.Add(przystanek);
            }

            przystanekPoczatkowy = this.trasaPasazera[0];
            przystanekKoncowy = this.trasaPasazera[this.trasaPasazera.Count - 1];
            obecnyPrzystanek = przystanekPoczatkowy;
        }

        public Pasazer(int czasWsiadania, int czasWysiadania) {
            this.czasWsiadania = czasWsiadania;
            this.czasWysiadania = czasWysiadania;
        }

        public Pasazer(IEnumerable<Przystanek> trasaPasazera, int czasWsiadania, int czasWysiadania) : this(trasaPasazera) {
            this.czasWsiadania = czasWsiadania;
            this.czasWysiadania = czasWysiadania;
        }

        public Pasazer(int czasWsiadania, int czasWysiadania, Przystanek przystanekPoczatkowy,
            Przystanek przystanekKoncowy)
            : this(czasWsiadania, czasWysiadania) {
            this.przystanekPoczatkowy = przystanekPoczatkowy;
            obecnyPrzystanek = przystanekPoczatkowy;
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

        protected abstract Linia WybierzLinie();
        
        public abstract void Wysiadz(Przystanek przystanek);

        public abstract void Wsiadz(Autobus autobus);
    }
}