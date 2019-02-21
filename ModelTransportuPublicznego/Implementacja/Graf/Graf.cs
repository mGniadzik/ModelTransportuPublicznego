using System;
using System.Collections.Generic;
using ModelTransportuPublicznego.Model;

namespace ModelTransportuPublicznego.Implementacja.Graf {
    public class Graf {
        private List<Wierzcholek> wierzcholki;

        private Graf() {
            wierzcholki = new List<Wierzcholek>();
        }
        
        public Graf(IEnumerable<Przystanek> listaPrzystankow) : this() {
            foreach (var przystanek in listaPrzystankow) {
                wierzcholki.Add(new Wierzcholek(przystanek));
            }
        }

        public void DodajKrawedzie(IEnumerable<Linia> linieAutobusowe) {
            foreach (var linia in linieAutobusowe) {
                if (linia.Count == 0 || linia.Count == 1) continue;

                for (var i = 0; i < linia.Count - 1; i++) {
                    var w1 = ZnajdzWierzcholekZawierajacyPrzystanek(linia[i].przystanek);
                    var w2 = ZnajdzWierzcholekZawierajacyPrzystanek(linia[i + 1].przystanek);
                    w1.DodajKrawedz(new Krawedz(w1, w2, linia[i + 1].czasPrzyjaduDoPrzystanku));
                }
            }
        }

        private Wierzcholek ZnajdzWierzcholekZawierajacyPrzystanek(Przystanek przystanek) {
            foreach (var wierzcholek in wierzcholki) {
                if (wierzcholek.przystanek == przystanek) {
                    return wierzcholek;
                }
            }

            throw new Exception($"Nie odnaleziono przystanku {przystanek.NazwaPrzystanku} w grafie!");
        }
    }
}