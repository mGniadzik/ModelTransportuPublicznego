using System;
using System.Collections.Generic;
using ModelTransportuPublicznego.Model;

namespace ModelTransportuPublicznego.Implementacja.Graf {
    public class Wierzcholek : IComparable<Wierzcholek> {
        public Przystanek przystanek;
        public List<Krawedz> krawedzie;
        public bool czyOdwiedzony;
        public TimeSpan waga;
        public Wierzcholek poprzedniWierzcholek;

        public Wierzcholek(Przystanek przystanek) {
            this.przystanek = przystanek;
            krawedzie = new List<Krawedz>();
            czyOdwiedzony = false;
            waga = TimeSpan.MaxValue;
        }

        public Wierzcholek(Przystanek przystanek, IEnumerable<Krawedz> krawedzie) : this(przystanek) {
            foreach (var krawedz in krawedzie) {
                this.krawedzie.Add(krawedz);
            }
        }

        public void DodajKrawedz(Krawedz krawedz) {
            krawedzie.Add(krawedz);
        }

        public int CompareTo(Wierzcholek other) {
            return waga.CompareTo(other.waga);
        }
    }
}