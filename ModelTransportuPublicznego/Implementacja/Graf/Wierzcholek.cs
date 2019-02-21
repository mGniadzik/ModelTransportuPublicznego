using System.Collections.Generic;
using ModelTransportuPublicznego.Implementacja.Pasazerowie.PasazerowieOparciNaGrafie;
using ModelTransportuPublicznego.Model;

namespace ModelTransportuPublicznego.Implementacja.Graf {
    public struct Wierzcholek {
        public Przystanek przystanek;
        public List<Krawedz> krawedzie;
        public bool czyOdwiedzony;

        public Wierzcholek(Przystanek przystanek) {
            this.przystanek = przystanek;
            krawedzie = new List<Krawedz>();
            czyOdwiedzony = false;
        }

        public Wierzcholek(Przystanek przystanek, IEnumerable<Krawedz> krawedzie) : this(przystanek) {
            foreach (var krawedz in krawedzie) {
                this.krawedzie.Add(krawedz);
            }
        }

        public void DodajKrawedz(Krawedz krawedz) {
            krawedzie.Add(krawedz);
        }
    }
}