using System;
using System.Collections.Generic;
using System.Linq;
using ModelTransportuPublicznego.Implementacja.Graf;
using ModelTransportuPublicznego.Implementacja.Wyjatki;
using ModelTransportuPublicznego.Model;

namespace ModelTransportuPublicznego.Implementacja.Pasazerowie
{
    public class PasazerWygodnicki : PasazerDijkstryBazowy
    {
        
        private static List<TrasaPasazera> obliczoneTrasy = new List<TrasaPasazera>(); 
        private Graf<byte> graf; 
            
        public PasazerWygodnicki(IEnumerable<ElementTrasy> trasaPasazera, TimeSpan czasUtworzenia, int czasWsiadania, int czasWysiadania) 
            : base(trasaPasazera, czasUtworzenia, czasWsiadania, czasWysiadania)
        { }

        public PasazerWygodnicki(int czasWsiadania, int czasWysiadania, Przystanek przystanekPoczatkowy,
            Przystanek przystanekKoncowy, Graf.Graf<byte> graf, TimeSpan czasOstatniegoStworzeniaTrasy)
            : base(czasWsiadania, czasWysiadania, przystanekPoczatkowy, przystanekKoncowy,
                czasOstatniegoStworzeniaTrasy)
        {
            this.graf = graf;
            trasaPasazera = ZnajdzTrase(graf);
        }

        public TrasaPasazera ZnajdzTrase(Graf<byte> graf)
        {
            return ZnajdzNajwygodniejszaTrase(graf);
        }
        
        public TrasaPasazera ZnajdzNajwygodniejszaTrase(Graf<byte> graf)
        {
            var wStartowy = graf.ZnajdzWierzcholekZawierajacyPrzystanek(przystanekPoczatkowy);
            wStartowy.waga = Byte.MinValue;

            try
            {
                AlgorytmDijkstry(graf.OdwiedzNajmniejszy(), graf, 0, null);
            }
            catch (TrasaNieZnalezionaWyjatek)
            {
                czyPosiadaTrase = false;
                return null;
            }

            var wKoncowy = graf.WynikAlgorytmuDijkstry();

            if (wKoncowy == null) return null;

            var rezultat = KonwertujWynikAlgorytmuNaTrase(wKoncowy);
            
            graf.ZresetujGraf(byte.MaxValue);

            if (rezultat.Count == 0)
            {
                czyPosiadaTrase = false;
                return null;
            }
            
            return new TrasaPasazera(rezultat, TimeSpan.MaxValue);
        }

        public virtual List<ElementTrasy> KonwertujWynikAlgorytmuNaTrase(Wierzcholek<byte> wKoncowy)
        {
            var rezultat = new List<ElementTrasy>();

            for (var w1 = wKoncowy; w1.poprzedniWierzcholek != null; w1 = w1.poprzedniWierzcholek)
            {
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

        protected void AlgorytmDijkstry(Wierzcholek<byte> wierzcholek, Graf.Graf<byte> graf, byte iloscPrzesiadek, Linia linia)
        {
            var rezultat = new List<ElementTrasy>();
            
            if (wierzcholek.przystanek != przystanekKoncowy)
            {

                byte minWaga = byte.MinValue;
                WpisRozkladuJazdy min = null;

                foreach (var k in wierzcholek.krawedzie) {
                    if (k.wierzcholekKoncowy.czyOdwiedzony) continue;

                    var pozostalePrzejazdy = ZwrocPozostalePrzejazdy(k);


                    if (!pozostalePrzejazdy.Any()) throw new TrasaNieZnalezionaWyjatek();
                    
                    min = null;
                    minWaga = byte.MaxValue;

                    foreach (var wrj in pozostalePrzejazdy)
                    {
                        var liniaPrzejazdu = wrj.LiniaObslugujaca;

                        k.wierzcholekKoncowy.waga = linia == liniaPrzejazdu ? iloscPrzesiadek : ++iloscPrzesiadek;

                        if (iloscPrzesiadek < minWaga) {
                            min = wrj;
                            minWaga = iloscPrzesiadek;
                        }   
                    }

                    k.wierzcholekKoncowy.waga = minWaga;
                    k.wierzcholekKoncowy.elementTrasy = new ElementTrasy(min?.LiniaObslugujaca, TimeSpan.Zero,
                        TimeSpan.Zero, k.wierzcholekKoncowy.przystanek);
                    k.wierzcholekKoncowy.poprzedniWierzcholek = wierzcholek;
                }
                
                AlgorytmDijkstry(graf.OdwiedzNajmniejszy(), graf, minWaga, min?.LiniaObslugujaca);
            }
        }

        public override Linia OczekiwanaLinia(TimeSpan obecnyCzas)
        {
            if (trasaPasazera == null) return null;
            return ZwrocLinieNastepnegoElementu(ZwrocNastepnyElementTrasy());
        }
    }
}