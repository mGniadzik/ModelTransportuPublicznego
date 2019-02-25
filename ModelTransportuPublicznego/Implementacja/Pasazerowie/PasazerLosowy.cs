using System;
using System.Collections.Generic;
using System.Linq;
using ModelTransportuPublicznego.Model;

namespace ModelTransportuPublicznego.Implementacja.Pasazerowie {
    public sealed class PasazerLosowy : Pasazer {

        private Linia wybranaLinia;

        public PasazerLosowy(int czasWsiadania, int czasWysiadania) : base(czasWsiadania, czasWysiadania) {
            wybranaLinia = null;
        }

        public PasazerLosowy(int czasWsiadania, int czasWysiadania, Przystanek przystanekPoczatkowy,
            Przystanek przystanekKoncowy) : base(czasWsiadania, czasWysiadania, przystanekPoczatkowy, przystanekKoncowy) { }

        public override Przystanek OczekiwanyPrzystanek => oczekiwanyPrzystanek;
        
        protected override Linia WybierzLinie() {
            if (wybranaLinia != null) {
                return wybranaLinia;
            }

            return WybierzLosowaLinie(obecnyPrzystanek.PozostaleLiniePrzejazdow());
        }

        public override void Wysiadz(Przystanek przystanek) {
            wybranaLinia = null;
            obecnyPrzystanek = przystanek;
            WybierzLinie();
        }

        public override void Wsiadz(Autobus autobus) {
            if (autobus.liniaAutobusu.ZwrocPozostalePrzystanki(obecnyPrzystanek).Contains(przystanekKoncowy)) {
                oczekiwanyPrzystanek = przystanekKoncowy;
                return;
            }
            
            oczekiwanyPrzystanek = WybierzLosowyPrzystanekLinii(autobus.liniaAutobusu);
        }

        private Przystanek WybierzLosowyPrzystanekLinii(Linia linia) {
            var przystanki = linia.ZwrocPozostalePrzystanki(obecnyPrzystanek).ToList();
            var rand = new Random();

            return przystanki[rand.Next(przystanki.Count)];
        }

        private Linia WybierzLosowaLinie(IEnumerable<Linia> linie) {
            var linieAutobusowe = linie.ToList();
            var rand = new Random();
            var los = rand.Next(linieAutobusowe.Count);

            return linieAutobusowe[los];
        }
    }
}