using System;
using System.Collections.Generic;
using System.Linq;
using ModelTransportuPublicznego.Implementacja.Graf;
using ModelTransportuPublicznego.Implementacja.Wyjatki;
using ModelTransportuPublicznego.Model;
using ModelTransportuPublicznego.Model.Przystanek;

namespace ModelTransportuPublicznego.Implementacja.Pasazerowie
{
    public class PasazerKrotkodystansowy : PasazerDijkstryBazowy
    {
        private Graf<ulong> graf;
            
        public PasazerKrotkodystansowy(IEnumerable<ElementTrasy> trasaPasazera, TimeSpan czasUtworzenia, int czasWsiadania, int czasWysiadania) : base(trasaPasazera, czasUtworzenia, czasWsiadania, czasWysiadania)
        { }

        public PasazerKrotkodystansowy(int czasWsiadania, int czasWysiadania, Przystanek przystanekPoczatkowy,
            Przystanek przystanekKoncowy, Graf<ulong> graf, TimeSpan czasOstatniegoStworzeniaTrasy) : base(czasWsiadania, czasWysiadania, przystanekPoczatkowy, przystanekKoncowy,
            czasOstatniegoStworzeniaTrasy)
        {
            this.graf = graf;
            var temp = CzyTrasaObliczona(przystanekPoczatkowy, przystanekKoncowy);
            
            if (temp == null)
            {
                trasaPasazera = ZnajdzTrase(graf);

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

        public PasazerKrotkodystansowy(int czasWsiadania, int czasWysiadania, Przystanek przystanekPoczatkowy,
            Przystanek przystanekKoncowy, IEnumerable<Przystanek> siecPrzystankow, IEnumerable<Linia> linie, TimeSpan czasOstatniegoStworzeniaTrasy) 
            : this(czasWsiadania, czasWysiadania, przystanekPoczatkowy, przystanekKoncowy, new Graf<ulong>(siecPrzystankow, linie, ulong.MaxValue), czasOstatniegoStworzeniaTrasy)
        { }

        public TrasaPasazera ZnajdzTrase(Graf<ulong> graf)
        {
            return ZnajdzNajwygodniejszaTrase(graf);
        }
        
        public TrasaPasazera ZnajdzNajwygodniejszaTrase(Graf<ulong> graf)
        {
            var wStartowy = graf.ZnajdzWierzcholekZawierajacyPrzystanek(przystanekPoczatkowy);
            wStartowy.waga = ulong.MinValue;

            try
            {
                AlgorytmDijkstry(graf.OdwiedzNajmniejszy(), graf, 0L);
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

        public virtual List<ElementTrasy> KonwertujWynikAlgorytmuNaTrase(Wierzcholek<ulong> wKoncowy)
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

        protected void AlgorytmDijkstry(Wierzcholek<ulong> wierzcholek, Graf.Graf<ulong> graf, ulong dystans)
        {
            var rezultat = new List<ElementTrasy>();
            ulong min = 0;
            
            if (wierzcholek.przystanek != przystanekKoncowy)
            {

                foreach (var k in wierzcholek.krawedzie) {
                    if (k.wierzcholekKoncowy.czyOdwiedzony) continue;

                    var trasa =
                        k.wierzcholekStartowy.przystanek.ZnajdzTraseDoNastepnegoPrzystanku(k.wierzcholekKoncowy
                            .przystanek);
                    
                    k.wierzcholekKoncowy.waga = dystans + (ulong) trasa.DystansTrasy;

                    if (k.wierzcholekKoncowy.waga < min) min = k.wierzcholekKoncowy.waga;
                    
                    k.wierzcholekKoncowy.elementTrasy = new ElementTrasy(k.wierzcholekStartowy.przystanek.
                            ZnajdzLinieDoPrzystanku(k.wierzcholekKoncowy.przystanek), TimeSpan.Zero,
                        TimeSpan.Zero, k.wierzcholekKoncowy.przystanek);
                    k.wierzcholekKoncowy.poprzedniWierzcholek = wierzcholek;
                }
                
                AlgorytmDijkstry(graf.OdwiedzNajmniejszy(), graf, min);
            }
        }

        public override Linia OczekiwanaLinia(TimeSpan obecnyCzas)
        {
            if (trasaPasazera == null) return null;
            return ZwrocLinieNastepnegoElementu(ZwrocNastepnyElementTrasy());
        }
    }
}