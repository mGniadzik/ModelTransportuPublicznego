using System;
using System.Collections.Generic;
using ModelTransportuPublicznego.Implementacja;
using ModelTransportuPublicznego.Implementacja.Autobusy;
using ModelTransportuPublicznego.Implementacja.Graf;
using ModelTransportuPublicznego.Implementacja.Pasazerowie;
using ModelTransportuPublicznego.Model;

namespace ModelTransportuPublicznego {

    internal static class Program {
        public static void Main(string[] args) {
            ZarzadTransportu zt = new DomyslnyZarzadTranspotu("ZT1");

            var p1 = new Przystanek("P1", zt);
            var p2 = new Przystanek("P2", zt);
            var p3 = new Przystanek("P3", zt);
            
            var t1 = new Trasa("t1", p1, p2, 1000);
            var t2 = new Trasa("t2", p2, p3, 1000);
            
            p1.DodajTrase(t1);
            p2.DodajTrase(t2);

             var r1 = new RozkladPrzejazdow(new List<TimeSpan> {new TimeSpan(8, 0, 0), new TimeSpan(10, 0, 0)});
             
             var p4 = new Przystanek("P4", zt);
             var p5 = new Przystanek("P5", zt);

             var t3 = new Trasa("t3", p4, p2, 1000);
             var t4 = new Trasa("t4", p2, p5, 1000);
             
             p4.DodajTrase(t3);
             p2.DodajTrase(t4);

             var prz1 = new List<PrzyplywPasazerow>
                 {new PrzyplywPasazerow(new TimeSpan(7, 50, 0), 20), 
//                     new PrzyplywPasazerow(new TimeSpan(8, 5, 0), 20),
//                     new PrzyplywPasazerow(new TimeSpan(8, 20, 0), 30)
                 };
             
             p1.DodajPrzyplywy(prz1);
             p2.DodajPrzyplywy(prz1);
             p3.DodajPrzyplywy(prz1);
             p4.DodajPrzyplywy(prz1);
             p5.DodajPrzyplywy(prz1);
             
             var r2 = new RozkladPrzejazdow(new List<TimeSpan>{new TimeSpan(9, 0, 0), new TimeSpan(9, 30, 0)});
             
             var l2 = new Linia("L2", new List<WpisLinii>{new WpisLinii(p4, new TimeSpan(0)), 
                 new WpisLinii(p2, new TimeSpan(0, 5, 0)), new WpisLinii(p5, new TimeSpan(0, 10, 0))}, r2);
            
            var l1 = new Linia("L1", new List<WpisLinii>{new WpisLinii(p1, new TimeSpan(0)), 
                new WpisLinii(p2, new TimeSpan(0, 10, 0)), new WpisLinii(p3, 
                    new TimeSpan(0, 15, 0))}, r1);

            var lk1 = new List<Kierowca> {new Kierowca(), new Kierowca(), new Kierowca(), new Kierowca(), new Kierowca(), new Kierowca(), new Kierowca(), new Kierowca()};
            var ta1 = new List<Autobus> {
                new AutobusLiniowy("A1", 80, 4, 3, 100, 50),
                new AutobusLiniowy("A2", 80, 4, 3, 100, 50),
                new AutobusLiniowy("A3", 80, 4, 3, 100, 50),
                new AutobusLiniowy("A4", 80, 4, 3, 100, 50),
                new AutobusLiniowy("A5", 80, 4, 3, 100, 50),
                new AutobusLiniowy("A6", 80, 4, 3, 100, 50),
                new AutobusLiniowy("A7", 80, 4, 3, 100, 50),
                new AutobusLiniowy("A8", 80, 4, 3, 100, 50)
            };
            
            var f1 = new FirmaLosowa("F1", ta1, lk1, new List<Linia> {l1});
            f1.DodajLinie(new List<Linia> {l2});
            zt.DodajFirme(f1);
            zt.DodajPrzystanki(new List<Przystanek> {p1, p2, p3, p4, p5});
            zt.DodajLiniePowrotne();
            
            var g1 = new Graf(zt.SiecPrzystankow);
            g1.DodajKrawedzie(zt.ZwrocLinie());
            
            var pasD1 = new PasazerDijkstry(5, 5, p5, p1, g1);
            
//            var list = pasD1.ZnajdzNajkrotszaTrase(g1);
//            g1.ZresetujGraf();
//            var pasL1 = new PasazerLosowy(7, 7, p1, p5);
            
//            p5.DodajPasazera(pasD1);
//            p5.DodajPasazera(pasL1);
            
            zt.StworzRozkladJazdyNaPrzystankach();
            
            zt.StworzListePrzejazdow();
            zt.WykonajPrzejazdy();
        }
    }


}