using System;
using System.Collections.Generic;
using System.Xml.Schema;
using ModelTransportuPublicznego.Implementacja;
using ModelTransportuPublicznego.Implementacja.Autobusy;
using ModelTransportuPublicznego.Implementacja.Graf;
using ModelTransportuPublicznego.Model;

namespace ModelTransportuPublicznego {

    internal static class Program {
        public static void Main(string[] args) {
            ZarzadTransportu zt = new DomyslnyZarzadTranspotu("ZT1");

            var p1 = new Przystanek("P1");
            var p2 = new Przystanek("P2");
            var p3 = new Przystanek("P3");
            
            var t1 = new Trasa(p1, p2, 1000);
            var t2 = new Trasa(p2, p3, 1000);
            
            p1.DodajTrase(t1);
            p2.DodajTrase(t2);

             var r1 = new RozkladJazdy(new List<TimeSpan> {new TimeSpan(8, 0, 0), new TimeSpan(10, 0, 0)});
             
             var p4 = new Przystanek("P4");
             var p5 = new Przystanek("P5");

             var t3 = new Trasa(p4, p2, 1000);
             var t4 = new Trasa(p2, p5, 1000);
             
             p4.DodajTrase(t3);
             p2.DodajTrase(t4);
             
             var r2 = new RozkladJazdy(new List<TimeSpan>{new TimeSpan(9, 0, 0), new TimeSpan(9, 30, 0)});
             
             var l2 = new Linia("L2", new List<WpisLinii>{new WpisLinii(p4, new TimeSpan(0)), 
                 new WpisLinii(p2, new TimeSpan(0, 5, 0)), new WpisLinii(p5, new TimeSpan(0, 10, 0))}, r2);
            
            // var r1 = new RozkladJazdy(new List<TimeSpan> {new TimeSpan(8, 0, 0)});
            
            //var l1 = new Linia("L1", new List<Przystanek> { p1, p2, p3 }, r1, new List<TimeSpan> {
              //  new TimeSpan(0, 0, 0), new TimeSpan(0, 0, 0), new TimeSpan(0, 0, 0) });
            
            var l1 = new Linia("L1", new List<WpisLinii>{new WpisLinii(p1, new TimeSpan(0)), 
                new WpisLinii(p2, new TimeSpan(0, 10, 0)), new WpisLinii(p3, 
                    new TimeSpan(0, 15, 0))}, r1);

            var lk1 = new List<Kierowca> {new Kierowca(), new Kierowca(), new Kierowca(), new Kierowca()};
            var ta1 = new List<Autobus> {
                new AutobusLiniowy("A1", 80, 4, 3, 100, 50),
                new AutobusLiniowy("A1", 80, 4, 3, 100, 50),
                new AutobusLiniowy("A1", 80, 4, 3, 100, 50),
                new AutobusLiniowy("A1", 80, 4, 3, 100, 50)
            };
            
            var tp1 = new TrasaPasazera(p1, new List<Przystanek>{p3}, new List<List<Linia>> {new List<Linia> {l1}});
            
            var pas1 = new Pasazer(tp1, 5, 5, p1, p3);
            
            p1.DodajPasazera(pas1);
            
            var f1 = new FirmaLosowa("F1", ta1, lk1, new List<Linia> {l1});
            f1.DodajLinie(new List<Linia> {l2});
            f1.UstawLinieNaPrzystankach();
            zt.DodajFirme(f1);
            zt.DodajPrzystanki(new List<Przystanek> {p1, p2, p3, p4, p5});
            
            var graf = new Graf(zt.SiecPrzystankow);
            graf.DodajKrawedzie(zt.ZwrocLinie());
            
            zt.StworzListePrzejazdow();
            zt.WykonajPrzejazdy();
        }
    }


}