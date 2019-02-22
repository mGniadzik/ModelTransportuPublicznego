using System;
using System.Collections.Generic;
using ModelTransportuPublicznego.Misc;
using ModelTransportuPublicznego.Model;

namespace ModelTransportuPublicznego.Implementacja.Graf {
    public class Graf {
        private MinKopiec<Wierzcholek> wierzcholki;
        private List<Wierzcholek> odwiedzoneWierzcholki;

        private Graf() {
            wierzcholki = new MinKopiec<Wierzcholek>();
            odwiedzoneWierzcholki = new List<Wierzcholek>();
        }
        
        public Graf(IEnumerable<Przystanek> listaPrzystankow) : this() {
            foreach (var przystanek in listaPrzystankow) {
                wierzcholki.Dodaj(new Wierzcholek(przystanek));
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

        public Wierzcholek ZnajdzWierzcholekZawierajacyPrzystanek(Przystanek przystanek) {
            foreach (Wierzcholek wierzcholek in wierzcholki) {
                if (wierzcholek.przystanek == przystanek) {
                    return wierzcholek;
                }
            }

            throw new Exception($"Nie odnaleziono przystanku {przystanek.NazwaPrzystanku} w grafie!");
        }

        public void NaprawKopiec() {
            wierzcholki.NaprawKopiec();
        }

        public Wierzcholek OdwiedzNajmniejszy() {
            NaprawKopiec();
            var wierzcholek = wierzcholki.ZdejminNajmniejszy();
            wierzcholek.czyOdwiedzony = true;
            odwiedzoneWierzcholki.Add(wierzcholek);

            return wierzcholek;
        }

        public Wierzcholek WynikAlgorytmuDijkstry() {
            return odwiedzoneWierzcholki[odwiedzoneWierzcholki.Count - 1];
        }

        public void ZresetujGraf() {
            wierzcholki.DodajWiele(odwiedzoneWierzcholki);
            odwiedzoneWierzcholki = new List<Wierzcholek>();
            
            foreach (Wierzcholek wierzcholek in wierzcholki) {
                wierzcholek.waga = TimeSpan.MaxValue;
                wierzcholek.czyOdwiedzony = false;
                wierzcholek.poprzedniWierzcholek = null;
            }
            
            NaprawKopiec();
        }
    }
}