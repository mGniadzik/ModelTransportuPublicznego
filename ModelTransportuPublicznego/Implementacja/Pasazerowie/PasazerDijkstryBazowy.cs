using System;
using System.Collections.Generic;
using System.Linq;
using ModelTransportuPublicznego.Implementacja.Graf;
using ModelTransportuPublicznego.Model;

namespace ModelTransportuPublicznego.Implementacja.Pasazerowie
{
    public abstract class PasazerDijkstryBazowy : Pasazer
    {
        protected TrasaPasazera trasaPasazera;
        protected TimeSpan czasOstatniegoStworzeniaTrasy;
        
        public PasazerDijkstryBazowy(IEnumerable<ElementTrasy> trasaPasazera, TimeSpan czasUtworzenia, int czasWsiadania, int czasWysiadania)
            : base(czasWsiadania, czasWsiadania) {
            trasaPasazera = new TrasaPasazera(trasaPasazera, czasUtworzenia);

            przystanekPoczatkowy = this.trasaPasazera.PrzystanekStartowy;
            przystanekKoncowy = this.trasaPasazera.PrzystanekKoncowy;
            czasOstatniegoStworzeniaTrasy = TimeSpan.Zero;
        }

        public PasazerDijkstryBazowy(int czasWsiadania, int czasWysiadania, Przystanek przystanekPoczatkowy,
            Przystanek przystanekKoncowy, TimeSpan czasOstatniegoStworzeniaTrasy)
            : base(czasWsiadania, czasWysiadania, przystanekPoczatkowy, przystanekKoncowy) {
        }

        protected virtual List<WpisRozkladuJazdy> ZwrocPozostalePrzejazdy<T>(Krawedz<T> k, TimeSpan czasPoczatkowy) where T : IComparable<T> {
            return k.wierzcholekStartowy.przystanek.PozostalePrzejazdy(
                k.wierzcholekStartowy.przystanek.PozostaleLiniePrzejazdow().Where(l => 
                    l.CzyPrzystanekPozostalDoOdwiedzenia(k.wierzcholekStartowy.przystanek, 
                        k.wierzcholekKoncowy.przystanek)).ToList(), czasPoczatkowy).ToList();
        }

        protected virtual List<WpisRozkladuJazdy> ZwrocPozostalePrzejazdy<T>(Krawedz<T> k) where T : IComparable<T>
        {
            return k.wierzcholekStartowy.przystanek.PozostalePrzejazdy(k.wierzcholekStartowy.przystanek.PozostaleLiniePrzejazdow().Where(l => 
                l.CzyPrzystanekPozostalDoOdwiedzenia(k.wierzcholekStartowy.przystanek, 
                    k.wierzcholekKoncowy.przystanek)).ToList()).ToList();
        }

        public override void Wysiadz(Przystanek przystanek) {
            UstawElementyTrasyJakoPrzebyte(przystanek);
        }

        public override void Wsiadz(Autobus autobus, TimeSpan czas) {
            // oczekiwanyPrzystanek = ZwrocNastepnyElementTrasy().Przystanek;
            UstawJakoPrzebyty();
            oczekiwanyPrzystanek = ZnajdzOczekiwanyPrzystanek(czas);
        }

        protected virtual Przystanek ZnajdzOczekiwanyPrzystanek(TimeSpan czas) {
            var elementy = trasaPasazera.Where(e => !e.CzyPrzebyty).ToList();

            for (int i = 0; i < elementy.Count; i++) {
                if (i == elementy.Count - 1) return elementy[i].Przystanek;
                if (elementy[i].Linia != elementy[i + 1].Linia) return elementy[i].Przystanek;
            }

            return null;
        }

        protected virtual void UstawElementyTrasyJakoPrzebyte(Przystanek przystanek) {
            foreach (var elem in trasaPasazera) {
                if (!elem.CzyPrzebyty && elem.Przystanek != przystanek) {
                    elem.CzyPrzebyty = true;
                    return;
                }
            }
        }

        protected virtual void UstawJakoPrzebyty() {
            foreach (var elem in trasaPasazera)
                if (!elem.CzyPrzebyty) {
                    elem.CzyPrzebyty = true;
                    return;
                }
        }

        protected virtual ElementTrasy ZwrocNastepnyElementTrasy() {
            foreach (var elemTrasy in trasaPasazera) {
                if (!elemTrasy.CzyPrzebyty) return elemTrasy;
            }

            return null;
        }

        protected virtual Linia ZwrocLinieNastepnegoElementu(ElementTrasy et) {
            return et?.Linia;
        }
    }
}