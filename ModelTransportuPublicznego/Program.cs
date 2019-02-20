using System;
using System.Collections.Generic;
using ModelTransportuPublicznego.Implementacja;
using ModelTransportuPublicznego.Implementacja.Autobusy;
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
            
            // var r1 = new RozkladJazdy(new List<TimeSpan> {new TimeSpan(8, 0, 0)});
            
            //var l1 = new Linia("L1", new List<Przystanek> { p1, p2, p3 }, r1, new List<TimeSpan> {
              //  new TimeSpan(0, 0, 0), new TimeSpan(0, 0, 0), new TimeSpan(0, 0, 0) });
            
            var l1 = new Linia("L1", new List<WpisLinii>{new WpisLinii(p1, new TimeSpan(0)), 
                new WpisLinii(p2, new TimeSpan(0, 10, 0)), new WpisLinii(p3, 
                    new TimeSpan(0, 15, 0))}, r1);

            var lk1 = new List<Kierowca> {new Kierowca(), new Kierowca()};
            var ta1 = new List<Autobus> {
                new AutobusLiniowy("A1", 80, 4, 3, 100, 50),
                new AutobusLiniowy("A1", 80, 4, 3, 100, 50)};
            
            var tp1 = new TrasaPasazera(p1, new List<Przystanek>{p3}, new List<Linia>{l1});
            
            var pas1 = new Pasazer(tp1, 5, 5, p1, p3);
            
            p1.DodajPasazera(pas1);
            
            var f1 = new FirmaLosowa("F1", ta1, lk1, new List<Linia> {l1});
            f1.UstawLinieNaPrzystankach();
            zt.DodajFirme(f1);
            
            zt.StworzListePrzejazdow();
            zt.WykonajPrzejazdy();
        }
    }


}