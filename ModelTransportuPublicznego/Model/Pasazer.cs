using System;
using System.Collections.Generic;
using System.Linq;

namespace ModelTransportuPublicznego.Model {
    public abstract class Pasazer {
        protected Przystanek.Przystanek przystanekPoczatkowy;
        protected Przystanek.Przystanek przystanekKoncowy;
        protected Przystanek.Przystanek obecnyPrzystanek;
        protected Przystanek.Przystanek oczekiwanyPrzystanek;
        protected bool czyPosiadaTrase;
        protected int czasWsiadania;
        protected int czasWysiadania;


        public virtual Przystanek.Przystanek OczekiwanyPrzystanek => oczekiwanyPrzystanek;

        public virtual Przystanek.Przystanek PrzystanekKoncowy => przystanekKoncowy;

        public virtual int CzasWsiadania => czasWsiadania;

        public virtual int CzasWysiadania => czasWysiadania;

        public virtual bool CzyPosiadaTrase => czyPosiadaTrase;

        protected Pasazer() {
            czyPosiadaTrase = true;
        }

        public Pasazer(int czasWsiadania, int czasWysiadania) : this() {
            this.czasWsiadania = czasWsiadania;
            this.czasWysiadania = czasWysiadania;
        }

        public Pasazer(int czasWsiadania, int czasWysiadania, Przystanek.Przystanek przystanekPoczatkowy,
            Przystanek.Przystanek przystanekKoncowy)
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
        
        public abstract void Wysiadz(Przystanek.Przystanek przystanek);

        public abstract void Wsiadz(Autobus autobus, TimeSpan czas);
    }
}