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

            return linieAutobusowe[rand.Next(linieAutobusowe.Count)];
        }
    }
}