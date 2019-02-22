using System;
using System.Collections.Generic;
using System.Linq;
using ModelTransportuPublicznego.Implementacja.Graf;
using ModelTransportuPublicznego.Model;

namespace ModelTransportuPublicznego.Implementacja.Pasazerowie {
    public class PasazerDjikstry : Pasazer {

        private static List<List<Przystanek>> obliczoneTrasy = new List<List<Przystanek>>();

        public PasazerDjikstry(IEnumerable<Przystanek> trasaPasazera) : base(trasaPasazera) { }

        public PasazerDjikstry(List<Przystanek> trasaPasazera, int czasWsiadania, int czasWysiadania) : base(trasaPasazera,
            czasWsiadania, czasWysiadania) { }

        public PasazerDjikstry(List<Przystanek> trasaPasazera, int czasWsiadania, int czasWysiadania,
            Przystanek przystanekPoczatkowy, Przystanek przystanekKoncowy)
            : base(trasaPasazera, czasWsiadania, czasWysiadania, przystanekPoczatkowy, przystanekKoncowy) { }

        private bool CzyTrasaObliczona(Przystanek przystanekStartowy, Przystanek przystanekKoncowy) {
            foreach (var otrasa in obliczoneTrasy) {
                if (otrasa[0] == przystanekStartowy &&
                    otrasa[otrasa.Count - 1] == przystanekKoncowy) {
                    return true;
                }
            }

            return false;
        }

        public void ZnajdzTrase(Graf.Graf graf) {
            foreach (var trasa in obliczoneTrasy) {
                if (trasa[0] == przystanekPoczatkowy &&
                    trasa[trasa.Count - 1] == przystanekKoncowy) {
                    trasaPasazera = trasa;
                    return;
                }
            }
            
            trasaPasazera = ZnajdzNajkrotszaTrase(graf);
        }

        public static void DodajTrase(IEnumerable<Przystanek> trasaPasazera) {
            obliczoneTrasy.Add(trasaPasazera.ToList());
        }

        public List<Przystanek> ZnajdzNajkrotszaTrase(Graf.Graf graf) {
            var wStartowy = graf.ZnajdzWierzcholekZawierajacyPrzystanek(przystanekPoczatkowy);
            wStartowy.waga = TimeSpan.Zero;

            AlgorytmDijkstry(graf.OdwiedzNajmniejszy(), graf);
            var wierzcholekKoncowy = graf.WynikAlgorytmuDijkstry();

            var rezultat = KonwertujWynikAlgorytmuNaTrase(wierzcholekKoncowy);
            
            graf.ZresetujGraf();

            return rezultat;
        }

        private static List<Przystanek> KonwertujWynikAlgorytmuNaTrase(Wierzcholek wierzcholekKoncowy) {
            var trasa = new List<Przystanek>();
            Wierzcholek w1;

            for (w1 = wierzcholekKoncowy; w1 != null; w1 = w1.poprzedniWierzcholek) {
                trasa.Insert(0, w1.przystanek);
            }

            return trasa;
        }

        private void AlgorytmDijkstry(Wierzcholek wierzcholek, Graf.Graf graf) {
            if (wierzcholek.przystanek != przystanekKoncowy) {

                foreach (var krawedz in wierzcholek.krawedzie) {
                    if (krawedz.wierzcholekKoncowy.czyOdwiedzony) continue;
                    if (krawedz.wierzcholekKoncowy.waga > wierzcholek.waga + krawedz.spodziewanyCzasPrzejazdu) {
                        krawedz.wierzcholekKoncowy.waga = wierzcholek.waga + krawedz.spodziewanyCzasPrzejazdu;
                        krawedz.wierzcholekKoncowy.poprzedniWierzcholek = wierzcholek;
                    }
                }
                
                AlgorytmDijkstry(graf.OdwiedzNajmniejszy(), graf);
            }
        }

        protected override void Wysiadz() {
            throw new NotImplementedException();
        }

        protected override void Wsiadz() {
            throw new NotImplementedException();
        }
    }
}