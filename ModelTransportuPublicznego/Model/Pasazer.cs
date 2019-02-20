using System.Collections.Generic;
using System.Linq;

namespace ModelTransportuPublicznego.Model {
    public class Pasazer {
        protected Linia oczekiwanaLinia;
        protected Przystanek przystanekObecny;
        protected Przystanek oczekiwanyPrzystanek;
        protected Przystanek przystanekKoncowy;
        protected int czasWsiadania;
        protected int czasWysiadania;

        protected Linia OczekiwanaLinia => oczekiwanaLinia;

        public Przystanek OczekiwanyPrzystanek => oczekiwanyPrzystanek;

        public Przystanek PrzystanekKoncowy => przystanekKoncowy;

        public int CzasWsiadania => czasWsiadania;

        public int CzasWysiadania => czasWysiadania;

        public Pasazer(Linia oczekiwanaLinia) {
            this.oczekiwanaLinia = oczekiwanaLinia;      
        }

        public Pasazer(Linia oczekiwanaLinia, int czasWsiadania, int czasWysiadania) : this(oczekiwanaLinia) {
            this.czasWsiadania = czasWsiadania;
            this.czasWysiadania = czasWysiadania;
        }
        
        public Pasazer(Linia oczekiwanaLinia, int czasWsiadania, int czasWysiadania, Przystanek przystanekPoczatkowy, Przystanek przystanekKoncowy) 
            : this(oczekiwanaLinia, czasWsiadania, czasWysiadania) {
            this.przystanekObecny = przystanekKoncowy;
            this.przystanekKoncowy = przystanekKoncowy;
            oczekiwanyPrzystanek = przystanekKoncowy;
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