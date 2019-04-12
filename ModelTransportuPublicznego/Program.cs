using System;
using System.Collections.Generic;
using ModelTransportuPublicznego.Implementacja;
using ModelTransportuPublicznego.Implementacja.Autobusy;
using ModelTransportuPublicznego.Implementacja.Firmy;
using ModelTransportuPublicznego.Implementacja.Graf;
using ModelTransportuPublicznego.Model;
using ModelTransportuPublicznego.Model.Przystanek;

namespace ModelTransportuPublicznego
{

    internal static class Program {
        public static void Main(string[] args) {
//            ZarzadTransportu zt = new DomyslnyZarzadTranspotu("ZT1");
//
//            var p1 = new Przystanek("P1", zt, 20, 100, 200);
//            var p2 = new Przystanek("P2", zt, 30, 320, 320);
//            var p3 = new Przystanek("P3", zt, 30, 300, 500);
//            
//            var t1 = new Trasa("t1", p1, p2, 1000, 50);
//            var t2 = new Trasa("t2", p2, p3, 1000, 50);
//            
//            p1.DodajTrase(t1);
//            p2.DodajTrase(t2);
//
//            var r1 = new RozkladPrzejazdow(new List<TimeSpan> {new TimeSpan(8, 0, 0), new TimeSpan(9, 0, 0), new TimeSpan(9, 30, 0), new TimeSpan(10, 0, 0)});
//             
//            var p4 = new Przystanek("P4", zt, 30, 400, 250);
//            var p5 = new Przystanek("P5", zt, 30, 500, 300);
//            var p6 = new Przystanek("P6", zt, 30, 150, 150);
//            var p7 = new Przystanek("P7", zt, 30, 250, 400);
//            var p8 = new Przystanek("P8", zt, 30, 350, 350);
//
//            var t3 = new Trasa("t3", p4, p2, 1000, 50);
//            var t4 = new Trasa("t4", p2, p5, 1000, 50);
//            var t5 = new Trasa("t5", p3, p6, 1000, 50);
//            var t6 = new Trasa("t5", p6, p7, 1000, 50);
//            var t7 = new Trasa("t5", p7, p8, 1000, 50);
//
//            p4.DodajTrase(t3);
//            p2.DodajTrase(t4);
//            p3.DodajTrase(t5);
//            p6.DodajTrase(t6);
//            p7.DodajTrase(t7);
//
//            var prz1 = new List<PrzyplywPasazerow>
//                {new PrzyplywPasazerow(new TimeSpan(7, 50, 0), 20), 
//                    new PrzyplywPasazerow(new TimeSpan(8, 5, 0), 20),
//                    new PrzyplywPasazerow(new TimeSpan(8, 20, 0), 30)
//                };
//             
//            p1.DodajPrzyplywy(prz1);
//            p2.DodajPrzyplywy(prz1);
//            p3.DodajPrzyplywy(prz1);
//            p4.DodajPrzyplywy(prz1);
//            p5.DodajPrzyplywy(prz1);
////             
//            var r2 = new RozkladPrzejazdow(new List<TimeSpan>{new TimeSpan(9, 0, 0), new TimeSpan(9, 30, 0)});
//             
//            var l2 = new Linia("L2", new List<WpisLinii>{new WpisLinii(p4, TimeSpan.Zero), 
//                new WpisLinii(p2, new TimeSpan(0, 5, 0)), new WpisLinii(p5, new TimeSpan(0, 10, 0))}, r2);
//            
//            var l1 = new Linia("L1", new List<WpisLinii>{new WpisLinii(p1, TimeSpan.Zero), 
//                new WpisLinii(p2, new TimeSpan(0, 10, 0)), new WpisLinii(p3, 
//                    new TimeSpan(0, 15, 0)), new WpisLinii(p6, new TimeSpan(0, 20, 0)), new WpisLinii(p7, new TimeSpan(0, 10, 0)), new WpisLinii(p8, new TimeSpan(0, 5, 0))}, r1);
//
//            var lk1 = new List<Kierowca> {new Kierowca(), new Kierowca(), new Kierowca(), new Kierowca(), new Kierowca(), new Kierowca(), new Kierowca(), new Kierowca(), new Kierowca(), new Kierowca(), new Kierowca(), new Kierowca()};
//            var ta1 = new List<Autobus> {
//                new AutobusLiniowy("A1", 80, 4, 3, 100, 50, 10.0),
//                new AutobusLiniowy("A2", 80, 4, 3, 100, 50, 10.0),
//                new AutobusLiniowy("A3", 80, 4, 3, 100, 50, 10.0),
//                new AutobusLiniowy("A4", 80, 4, 3, 100, 50, 10.0),
//                new AutobusLiniowy("A5", 80, 4, 3, 100, 50, 10.0),
//                new AutobusLiniowy("A6", 80, 4, 3, 100, 50, 10.0),
//                new AutobusLiniowy("A7", 80, 4, 3, 100, 50, 10.0),
//                new AutobusLiniowy("A8", 80, 4, 3, 100, 50, 10.0),
//                new AutobusLiniowy("A9", 80, 4, 3, 100, 50, 10.0),
//                new AutobusLiniowy("A10", 80, 4, 3, 100, 50, 10.0),
//                new AutobusLiniowy("A11", 80, 4, 3, 100, 50, 10.0),
//                new AutobusLiniowy("A12", 80, 4, 3, 100, 50, 10.0),
//                new AutobusLiniowy("A13", 80, 4, 3, 100, 50, 10.0),
//                new AutobusLiniowy("A14", 80, 4, 3, 100, 50, 10.0),
//                new AutobusLiniowy("A15", 80, 4, 3, 100, 50, 10.0)
//            };
//            
//            var f1 = new FirmaLosowa("F1", ta1, lk1, new List<Linia> {l1});
//            f1.DodajLinie(new List<Linia> {l2});
//            zt.DodajFirme(f1);
//            zt.DodajPrzystanki(new List<Przystanek> {p1, p2, p3, p4, p5, p6, p7, p8});
//            zt.DodajLiniePowrotne();
//            
//            var g1 = new Graf<TimeSpan>(zt.SiecPrzystankow, TimeSpan.MaxValue);
//            g1.DodajKrawedzie(zt.ZwrocLinie());
//            
////            var list = pasD1.ZnajdzNajkrotszaTrase(g1);
////            g1.ZresetujGraf();
////            var pasL1 = new PasazerLosowy(7, 7, p1, p5);
//            
////            p5.DodajPasazera(pasD1);
////            p5.DodajPasazera(pasL1);
//            
//            zt.StworzRozkladJazdyNaPrzystankach();
//
//            //            var pasD1 = new PasazerDijkstry(5, 5, p2, p4, g1, new TimeSpan(7, 0, 0));
//            //            p1.DodajPasazera(pasD1);
//
//            zt.StworzListePrzejazdow();
//            zt.WykonajPrzejazdy();
        }
    }


}