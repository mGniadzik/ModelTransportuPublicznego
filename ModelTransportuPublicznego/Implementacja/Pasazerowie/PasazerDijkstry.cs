using System;
using System.Collections.Generic;
using System.Linq;
using ModelTransportuPublicznego.Implementacja.Graf;
using ModelTransportuPublicznego.Implementacja.Wyjatki;
using ModelTransportuPublicznego.Model;

namespace ModelTransportuPublicznego.Implementacja.Pasazerowie
{
    public class PasazerDijkstry : Pasazer {
        
        private static List<TrasaPasazera> obliczoneTrasy = new List<TrasaPasazera>();
        private Graf.Graf graf;
        private TrasaPasazera trasaPasazera;
        private TimeSpan czasOstatniegoStworzeniaTrasy;
        
        public PasazerDijkstry(IEnumerable<ElementTrasy> trasaPasazera, TimeSpan czasUtworzenia, int czasWsiadania, int czasWysiadania)
            : base(czasWsiadania, czasWsiadania) {
            trasaPasazera = new TrasaPasazera(trasaPasazera, czasUtworzenia);

            przystanekPoczatkowy = this.trasaPasazera.PrzystanekStartowy;
            przystanekKoncowy = this.trasaPasazera.PrzystanekKoncowy;
            czasOstatniegoStworzeniaTrasy = TimeSpan.Zero;
        }

        public PasazerDijkstry(int czasWsiadania, int czasWysiadania, Przystanek przystanekPoczatkowy,
            Przystanek przystanekKoncowy, Graf.Graf graf, TimeSpan czasOstatniegoStworzeniaTrasy)
            : base(czasWsiadania, czasWysiadania, przystanekPoczatkowy, przystanekKoncowy) {
            this.graf = graf;

            var temp = CzyTrasaObliczona(przystanekPoczatkowy, przystanekKoncowy);

            //if (temp == null)
            //{
                trasaPasazera = ZnajdzTrase(graf, czasOstatniegoStworzeniaTrasy);
                //obliczoneTrasy.Add(trasaPasazera);
                this.czasOstatniegoStworzeniaTrasy = czasOstatniegoStworzeniaTrasy; 
            //}
            //else
            //{
            //    trasaPasazera = new TrasaPasazera(temp, temp.CzasWaznosci);   
            //}
        }
        
        private TrasaPasazera CzyTrasaObliczona(Przystanek przystanekStartowy, Przystanek przystanekKoncowy) {
            foreach (var otrasa in obliczoneTrasy) {
                if (otrasa[0].Przystanek == przystanekStartowy &&
                    otrasa[otrasa.Count - 1].Przystanek == przystanekKoncowy) {
                    return otrasa;
                }
            }

            return null;
        }

        public TrasaPasazera ZnajdzTrase(Graf.Graf graf, TimeSpan czasUtworzenia) {
            UsunPrzedawnioneTrasy(czasUtworzenia);
            
            foreach (var trasa in obliczoneTrasy) {
                if (trasa.PrzystanekStartowy == przystanekPoczatkowy &&
                    trasa.PrzystanekKoncowy == przystanekKoncowy) {
                    return trasa;
                }
            }
            
            return ZnajdzNajkrotszaTrase(graf, czasUtworzenia);
        }

        public void UsunPrzedawnioneTrasy(TimeSpan czas) {
            obliczoneTrasy.RemoveAll(t => t.CzyPrzedawniony(czas));
        }

        public static void DodajTrase(TrasaPasazera trasaPasazera) {
            obliczoneTrasy.Add(trasaPasazera);
        }

        public TrasaPasazera ZnajdzNajkrotszaTrase(Graf.Graf graf, TimeSpan czasPoczatkowy) {
            var wStartowy = graf.ZnajdzWierzcholekZawierajacyPrzystanek(przystanekPoczatkowy);
            wStartowy.waga = TimeSpan.Zero;

            try
            {
                AlgorytmDijkstry(graf.OdwiedzNajmniejszy(), graf, czasPoczatkowy);
            } catch (TrasaNieZnalezionaWyjatek)
            {
                return null;
            }

            var wKoncowy = graf.WynikAlgorytmuDijkstry();
            
            if (wKoncowy == null) return new TrasaPasazera();
            
            var rezultat = KonwertujWynikAlgorytmuNaTrase(wKoncowy);
            
            graf.ZresetujGraf();
            
            return rezultat.Count == 0 ? null : new TrasaPasazera(rezultat, rezultat[0].CzasOczekiwania + czasPoczatkowy);
        }

        private void AlgorytmDijkstry(Wierzcholek wierzcholek, Graf.Graf graf, TimeSpan czasPoczatkowy) {
            var rezultat = new List<ElementTrasy>();
            
            if (wierzcholek.przystanek != przystanekKoncowy) {

                TimeSpan minWaga = TimeSpan.Zero;
                WpisRozkladuJazdy min;

                foreach (var k in wierzcholek.krawedzie) {
                    if (k.wierzcholekKoncowy.czyOdwiedzony) continue;

                    var pozostalePrzejazdy = ZwrocPozostalePrzejazdy(k, czasPoczatkowy);


                    if (!pozostalePrzejazdy.Any()) throw new TrasaNieZnalezionaWyjatek();
                    
                    min = null;
                    minWaga = TimeSpan.MaxValue;

                    foreach (var wrj in pozostalePrzejazdy) {
                        var czasPrzejazdu = wrj.PozostalyCzas(czasPoczatkowy) +
                                                 wrj.LiniaObslugujaca.CzasPrzejazduPoMiedzyPrzystankami(
                                                     k.wierzcholekStartowy.przystanek,
                                                     k.wierzcholekKoncowy.przystanek);
                        if (czasPrzejazdu < minWaga) {
                            min = wrj;
                            minWaga = czasPrzejazdu;
                        }   
                    }

                    k.wierzcholekKoncowy.waga = minWaga;
                    k.wierzcholekKoncowy.elementTrasy = new ElementTrasy(min.LiniaObslugujaca, min.PozostalyCzas(czasPoczatkowy), 
                        min.LiniaObslugujaca.CzasPrzejazduPoMiedzyPrzystankami(k.wierzcholekKoncowy.przystanek, k.wierzcholekKoncowy.przystanek), 
                        k.wierzcholekKoncowy.przystanek);
                    k.wierzcholekKoncowy.poprzedniWierzcholek = wierzcholek;
                }
                
                AlgorytmDijkstry(graf.OdwiedzNajmniejszy(), graf, czasPoczatkowy + minWaga);
            }
        }

        protected virtual List<ElementTrasy> KonwertujWynikAlgorytmuNaTrase(Wierzcholek wKoncowy) {
            var rezultat = new List<ElementTrasy>();
            
            for (var w1 = wKoncowy; w1.poprzedniWierzcholek != null; w1 = w1.poprzedniWierzcholek) {
                rezultat.Insert(0, w1.elementTrasy);

                if (w1.poprzedniWierzcholek.elementTrasy == null) {
                    rezultat.Insert(0, new ElementTrasy(w1.elementTrasy.Linia, w1.poprzedniWierzcholek.przystanek,
                        w1.poprzedniWierzcholek.przystanek.ZwrocPierwszyPrzejazdDanejLinii(w1.elementTrasy.Linia), 
                        TimeSpan.Zero));
                    break;
                }
            }

            return rezultat;
        }

        protected virtual List<WpisRozkladuJazdy> ZwrocPozostalePrzejazdy(Krawedz k, TimeSpan czasPoczatkowy) {
            return k.wierzcholekStartowy.przystanek.PozostalePrzejazdy(
                k.wierzcholekStartowy.przystanek.PozostaleLiniePrzejazdow().Where(l => 
                    l.CzyPrzystanekPozostalDoOdwiedzenia(k.wierzcholekStartowy.przystanek, 
                        k.wierzcholekKoncowy.przystanek)).ToList(), czasPoczatkowy).ToList();
        }
        public override Linia OczekiwanaLinia(TimeSpan obecnyCzas) {
            if (trasaPasazera.Count == 0) return null;
            if (obecnyCzas > trasaPasazera[0].CzasOczekiwania + czasOstatniegoStworzeniaTrasy)
            {
                przystanekPoczatkowy = obecnyPrzystanek;
                trasaPasazera = ZnajdzTrase(graf, obecnyCzas);   
            }
            return ZwrocLinieNastepnegoElementu(ZwrocNastepnyElementTrasy());
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