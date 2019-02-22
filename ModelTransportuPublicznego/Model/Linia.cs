using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;

namespace ModelTransportuPublicznego.Model {
    public class Linia : IEnumerable {
        protected string idLinii;
        protected RozkladPrzejazdow rozkladPrzejazdow;
        protected List<WpisLinii> trasaLinii;

        public RozkladPrzejazdow RozkladPrzejazdow => rozkladPrzejazdow;
        
        public WpisLinii this[int indeks] => trasaLinii[indeks];

        public int Count => trasaLinii.Count;

        public Linia(string idLinii) {
            this.idLinii = idLinii;
            trasaLinii = new List<WpisLinii>();
        }

        public Linia(string idLinii, IEnumerable<WpisLinii> trasaLinii) : this(idLinii) {

            foreach (var przystanek in trasaLinii) {
                this.trasaLinii.Add(przystanek);
            }
        }

        public Linia(string idLinii, IEnumerable<WpisLinii> trasaLinii, RozkladPrzejazdow rozkladPrzejazdow) 
            : this(idLinii, trasaLinii) {
            
            this.rozkladPrzejazdow = rozkladPrzejazdow;
        }

        public Przystanek ZwrocNastepnyPrzystanek(Przystanek przystanek) {
            if (trasaLinii[trasaLinii.Count - 1].przystanek == przystanek) {
                throw new ArgumentOutOfRangeException();   
            }

            return trasaLinii[ZwrocIndeksPrzystanku(przystanek) + 1].przystanek;
        }

        public Przystanek ZwrocOstatniPrzystanek() {
            return ZwrocPrzystanekIndeks(trasaLinii.Count - 1);
        }

        public void DodajTrase() {
            // TODO
        }

        public void UsunTrase(Trasa trasa) {
            // TODO
        }

        public IEnumerable<WpisLinii> ZwrocTrasy() {
            return trasaLinii;
        }

        public int ZwrocIndeksPrzystanku(Przystanek przystanek) {
            for (int i = 0; i < trasaLinii.Count; i++) {
                if (trasaLinii[i].przystanek == przystanek) {
                    return i;
                }
            }
            return -1;
        }

        public Przystanek ZwrocPrzystanekIndeks(int indeks) {
            return trasaLinii[indeks].przystanek;
        }

        public IEnumerator GetEnumerator() {
            return new LiniaEnumerator(trasaLinii);
        }

        public void DodajWpisDoRozkladuPrzystankowLinii() {
            foreach (var czas in rozkladPrzejazdow) {
                var suma = TimeSpan.Zero;
                foreach (var wpis in trasaLinii) {
                    suma += wpis.czasPrzyjaduDoPrzystanku;
                    wpis.przystanek.RozkladJazdy.DodajWpisDoRozkladu(new WpisRozkladuJazdy(this, czas + suma));
                }
            }
        }

        private class LiniaEnumerator : IEnumerator {

            private List<WpisLinii> trasaLinii;
            private int pozycja = -1;

            public LiniaEnumerator(List<WpisLinii> trasaLinii) {
                this.trasaLinii = trasaLinii;
            }
            public bool MoveNext() {
                pozycja++;
                return (pozycja < trasaLinii.Count);
            }

            public void Reset() {
                pozycja = -1;
            }

            object IEnumerator.Current {
                get { return Current; }
            }

            public WpisLinii Current {
                get {
                    try {
                        return trasaLinii[pozycja];
                    }
                    catch (ArgumentOutOfRangeException) {
                        throw new InvalidOperationException();
                    }
                }    
            }
        }
    }
}