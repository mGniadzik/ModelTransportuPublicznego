using System;
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


        public virtual Przystanek OczekiwanyPrzystanek => oczekiwanyPrzystanek;

        public virtual Przystanek PrzystanekKoncowy => przystanekKoncowy;

        public virtual int CzasWsiadania => czasWsiadania;

        public virtual int CzasWysiadania => czasWysiadania;

        protected Pasazer() { }

        public Pasazer(int czasWsiadania, int czasWysiadania) {
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

        public abstract Linia OczekiwanaLinia(TimeSpan obecnyCzas);
        
        public abstract void Wysiadz(Przystanek przystanek);

        public abstract void Wsiadz(Autobus autobus);
    }
}