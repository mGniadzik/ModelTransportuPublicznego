using System;
using System.Collections.Generic;
using System.Linq;
using ModelTransportuPublicznego.Implementacja.Graf;
using ModelTransportuPublicznego.Implementacja.Wyjatki;
using ModelTransportuPublicznego.Model;
using ModelTransportuPublicznego.Model.Przystanek;

namespace ModelTransportuPublicznego.Implementacja.Pasazerowie
{
    public class PasazerDijkstry : PasazerDijkstryBazowy {
        private Graf<TimeSpan> graf;
        
        public PasazerDijkstry(IEnumerable<ElementTrasy> trasaPasazera, TimeSpan czasUtworzenia, int czasWsiadania, int czasWysiadania)
            : base(trasaPasazera, czasUtworzenia, czasWsiadania, czasWysiadania) { }

        public PasazerDijkstry(int czasWsiadania, int czasWysiadania, Przystanek przystanekPoczatkowy,
            Przystanek przystanekKoncowy, Graf<TimeSpan> graf, TimeSpan czasOstatniegoStworzeniaTrasy)
            : base(czasWsiadania, czasWysiadania, przystanekPoczatkowy, przystanekKoncowy, czasOstatniegoStworzeniaTrasy) {
            
            this.graf = graf;
            var temp = CzyTrasaObliczona(przystanekPoczatkowy, przystanekKoncowy);

            if (temp == null)
            {
                trasaPasazera = ZnajdzTrase(graf, czasOstatniegoStworzeniaTrasy);

                if (trasaPasazera != null)
                {
                    obliczoneTrasy.Add(trasaPasazera);
                }
                
                this.czasOstatniegoStworzeniaTrasy = czasOstatniegoStworzeniaTrasy; 
            }
            else
            {
                trasaPasazera = new TrasaPasazera(temp, temp.CzasWaznosci);   
            }
        }

        public PasazerDijkstry(int czasWsiadania, int czasWysiadania, Przystanek przystanekPoczatkowy,
            Przystanek przystanekKoncowy, IEnumerable<Przystanek> siecPrzystankow, IEnumerable<Linia> linie, TimeSpan czasOstatniegoStworzeniaTrasy)
            : this(czasWsiadania, czasWysiadania, przystanekPoczatkowy, przystanekKoncowy, new Graf<TimeSpan>(siecPrzystankow, linie, TimeSpan.MaxValue), czasOstatniegoStworzeniaTrasy)
        { }

        public TrasaPasazera ZnajdzTrase(Graf.Graf<TimeSpan> graf, TimeSpan czasUtworzenia) {
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

        public TrasaPasazera ZnajdzNajkrotszaTrase(Graf<TimeSpan> graf, TimeSpan czasPoczatkowy) {
            var wStartowy = graf.ZnajdzWierzcholekZawierajacyPrzystanek(przystanekPoczatkowy);
            wStartowy.waga = TimeSpan.Zero;

            try
            {
                AlgorytmDijkstry(graf.OdwiedzNajmniejszy(), graf, czasPoczatkowy);
            } catch (TrasaNieZnalezionaWyjatek)
            {
                czyPosiadaTrase = false;
                return null;
            }

            var wKoncowy = graf.WynikAlgorytmuDijkstry();

            if (wKoncowy == null) return null;
            
            var rezultat = KonwertujWynikAlgorytmuNaTrase(wKoncowy);
            
            graf.ZresetujGraf(TimeSpan.MaxValue);

            if (rezultat.Count == 0)
            {
                czyPosiadaTrase = false;
                return null;
            }
            
            return new TrasaPasazera(rezultat, rezultat[0].CzasOczekiwania + czasPoczatkowy);
        }
        
        protected virtual List<ElementTrasy> KonwertujWynikAlgorytmuNaTrase(Wierzcholek<TimeSpan> wKoncowy) {
            var rezultat = new List<ElementTrasy>();
            
            for (var w1 = wKoncowy; w1.poprzedniWierzcholek != null; w1 = w1.poprzedniWierzcholek) {
                rezultat.Insert(0, w1.elementTrasy);

                if (w1.poprzedniWierzcholek.elementTrasy == null) {
                    try
                    {
                        rezultat.Insert(0, new ElementTrasy(w1.elementTrasy.Linia, w1.poprzedniWierzcholek.przystanek,
                            w1.poprzedniWierzcholek.przystanek.ZwrocPierwszyPrzejazdDanejLinii(w1.elementTrasy.Linia), 
                            TimeSpan.Zero));
                    }
                    catch (TrasaNieZnalezionaWyjatek)
                    {
                        czyPosiadaTrase = false;
                    }
                    break;
                }
            }

            return rezultat;
        }

        protected virtual void AlgorytmDijkstry(Wierzcholek<TimeSpan> wierzcholek, Graf.Graf<TimeSpan> graf, TimeSpan czasPoczatkowy) {
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

        public override Linia OczekiwanaLinia(TimeSpan obecnyCzas) {
            if (trasaPasazera == null) return null;
            if (obecnyCzas > trasaPasazera[0].CzasOczekiwania + czasOstatniegoStworzeniaTrasy)
            {
                przystanekPoczatkowy = obecnyPrzystanek;
                trasaPasazera = ZnajdzTrase(graf, obecnyCzas);

                if (trasaPasazera == null) return null;
            }
            return ZwrocLinieNastepnegoElementu(ZwrocNastepnyElementTrasy());
        }
    }
}