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

        protected void AlgorytmDijkstry(Wierzcholek<byte> wierzcholek, Graf.Graf<byte> graf, byte iloscPrzesiadek, Linia linia)
        {
            var rezultat = new List<ElementTrasy>();
            Linia liniaWynikowa = null;
            var min = byte.MaxValue;
            
            if (wierzcholek.przystanek != przystanekKoncowy)
            {

                foreach (var k in wierzcholek.krawedzie) {
                    if (k.wierzcholekKoncowy.czyOdwiedzony) continue;

                    liniaWynikowa =
                        k.wierzcholekStartowy.przystanek.ZnajdzLinieDoPrzystanku(k.wierzcholekKoncowy.przystanek);

                    k.wierzcholekKoncowy.waga = liniaWynikowa == linia ? iloscPrzesiadek : ++iloscPrzesiadek;

                    if (iloscPrzesiadek < min) min = iloscPrzesiadek;
                    
                    k.wierzcholekKoncowy.elementTrasy = new ElementTrasy(liniaWynikowa, TimeSpan.Zero,
                        TimeSpan.Zero, k.wierzcholekKoncowy.przystanek);
                    k.wierzcholekKoncowy.poprzedniWierzcholek = wierzcholek;
                }
                
                AlgorytmDijkstry(graf.OdwiedzNajmniejszy(), graf, min, liniaWynikowa);
            }
        }

        public override Linia OczekiwanaLinia(TimeSpan obecnyCzas)
        {
            if (trasaPasazera == null) return null;
            return ZwrocLinieNastepnegoElementu(ZwrocNastepnyElementTrasy());
        }
    }
}