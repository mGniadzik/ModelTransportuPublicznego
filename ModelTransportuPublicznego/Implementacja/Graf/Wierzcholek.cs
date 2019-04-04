using System;
using System.Collections.Generic;
using ModelTransportuPublicznego.Implementacja.Pasazerowie;
using ModelTransportuPublicznego.Model;
using ModelTransportuPublicznego.Model.Przystanek;

namespace ModelTransportuPublicznego.Implementacja.Graf {
    public class Wierzcholek<T> : IComparable<Wierzcholek<T>> where T : IComparable<T> {
        public Przystanek przystanek;
        public List<Krawedz<T>> krawedzie;
        public bool czyOdwiedzony;
        public T waga;
        public Wierzcholek<T> poprzedniWierzcholek;
        public ElementTrasy elementTrasy;

        public Wierzcholek(Przystanek przystanek) {
            this.przystanek = przystanek;
            krawedzie = new List<Krawedz<T>>();
            czyOdwiedzony = false;
        }

        public Wierzcholek(Przystanek przystanek, IEnumerable<Krawedz<T>> krawedzie) : this(przystanek) {
            foreach (var krawedz in krawedzie) {
                this.krawedzie.Add(krawedz);
            }
        }

        public void DodajKrawedz(Krawedz<T> krawedz) {
            krawedzie.Add(krawedz);
        }

        public int CompareTo(Wierzcholek<T> other) {
            return waga.CompareTo(other.waga);
        }
    }
}