using System;
using System.Collections.Generic;
using System.Linq;
using ModelTransportuPublicznego.Misc;
using ModelTransportuPublicznego.Model;

namespace ModelTransportuPublicznego.Implementacja.Graf {
    public class Graf<T> where T : IComparable<T> {
        private MinKopiec<Wierzcholek<T>> wierzcholki;
        private List<Wierzcholek<T>> odwiedzoneWierzcholki;

        private Graf() {
            wierzcholki = new MinKopiec<Wierzcholek<T>>();
            odwiedzoneWierzcholki = new List<Wierzcholek<T>>();
        }
        
        public Graf(IEnumerable<Przystanek> listaPrzystankow, T val) : this() {
            foreach (var przystanek in listaPrzystankow) {
                wierzcholki.Dodaj(new Wierzcholek<T>(przystanek));
            }
            
            UstawWartosciWierzcholkow(val);
        }

        public void DodajKrawedzie(IEnumerable<Linia> linieAutobusowe) {
            foreach (var linia in linieAutobusowe) {
                if (linia.Count == 0 || linia.Count == 1) continue;

                for (var i = 0; i < linia.Count - 1; i++) {
                    var w1 = ZnajdzWierzcholekZawierajacyPrzystanek(linia[i].przystanek);
                    var w2 = ZnajdzWierzcholekZawierajacyPrzystanek(linia[i + 1].przystanek);
                    w1.DodajKrawedz(new Krawedz<T>(w1, w2, linia[i + 1].czasPrzyjaduDoPrzystanku));
                }
            }
        }

        public Wierzcholek<T> ZnajdzWierzcholekZawierajacyPrzystanek(Przystanek przystanek) {
            foreach (Wierzcholek<T> wierzcholek in wierzcholki) {
                if (wierzcholek.przystanek == przystanek) {
                    return wierzcholek;
                }
            }

            throw new Exception($"Nie odnaleziono przystanku {przystanek.NazwaPrzystanku} w grafie!");
        }

        public void NaprawKopiec() {
            wierzcholki.NaprawKopiec();
        }

        public Wierzcholek<T> OdwiedzNajmniejszy() {
            //NaprawKopiec();
            NaprawKopiec();
            var wierzcholek = wierzcholki.ZdejminNajmniejszy();
            wierzcholek.czyOdwiedzony = true;
            odwiedzoneWierzcholki.Add(wierzcholek);

            return wierzcholek;
        }

        public void UstawWartosciWierzcholkow(T val)
        {
            foreach (Wierzcholek<T> w in wierzcholki)
            {
                w.waga = val;
            }
        }

        public Wierzcholek<T> WynikAlgorytmuDijkstry() {
            return !odwiedzoneWierzcholki.Any() ? null : odwiedzoneWierzcholki[odwiedzoneWierzcholki.Count - 1];
        }

        public void ZresetujGraf(T val) {
            wierzcholki.DodajWiele(odwiedzoneWierzcholki);
            odwiedzoneWierzcholki = new List<Wierzcholek<T>>();
            
            foreach (Wierzcholek<T> wierzcholek in wierzcholki)
            {
                wierzcholek.waga = val;
                wierzcholek.czyOdwiedzony = false;
                wierzcholek.poprzedniWierzcholek = null;
            }
            
            NaprawKopiec();
        }
    }
}