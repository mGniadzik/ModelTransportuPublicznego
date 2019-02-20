using System.Collections.Generic;
using System.Linq;

namespace ModelTransportuPublicznego.Model {
    public class Pasazer {
        protected Przystanek przystanekKoncowy;
        protected int czasWsiadania;
        protected int czasWysiadania;
        protected TrasaPasazera trasaPasazera;
        

        protected Linia OczekiwanaLinia => trasaPasazera.ZwrocOczekiwanaLinie();

        public Przystanek OczekiwanyPrzystanek => trasaPasazera.ZwrocOczekiwanyPrzystanek();

        public Przystanek PrzystanekKoncowy => przystanekKoncowy;

        public int CzasWsiadania => czasWsiadania;

        public int CzasWysiadania => czasWysiadania;

        public Pasazer(TrasaPasazera trasaPasazera) {
            this.trasaPasazera = trasaPasazera;
        }

        public Pasazer(TrasaPasazera trasaPasazera, int czasWsiadania, int czasWysiadania) : this(trasaPasazera) {
            this.czasWsiadania = czasWsiadania;
            this.czasWysiadania = czasWysiadania;
        }
        
        public Pasazer(TrasaPasazera trasaPasazera, int czasWsiadania, int czasWysiadania, Przystanek przystanekPoczatkowy, Przystanek przystanekKoncowy) 
            : this(trasaPasazera, czasWsiadania, czasWysiadania) {
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