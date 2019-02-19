using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using ModelTransportuPublicznego.Implementacja;
using ModelTransportuPublicznego.Model;

namespace ModelTransportuPublicznego {

    internal static class Program {
        public static void Main(string[] args) {
            ZarzadTransportu zt = new DomyslnyZarzadTranspotu();

            var p1 = new Przystanek("P1");
            var p2 = new Przystanek("P2");
            var p3 = new Przystanek("P3");
            
            var t1 = new Trasa(p1, p2, 1000);
            var t2 = new Trasa(p2, p3, 1000);
            
            p1.DodajTrase(t1);
            p2.DodajTrase(t2);

            var r1 = new RozkladJazdy(new List<TimeSpan> {new TimeSpan(8, 0, 0), new TimeSpan(10, 0, 0)});
            
            // var r1 = new RozkladJazdy(new List<TimeSpan> {new TimeSpan(8, 0, 0)});
            
            var l1 = new Linia("L1", new List<Przystanek> { p1, p2, p3 }, r1, new List<TimeSpan> {
                new TimeSpan(0, 0, 0), new TimeSpan(0, 0, 0), new TimeSpan(0, 0, 0) });

            var lk1 = new List<Kierowca> {new Kierowca(), new Kierowca()};
            var ta1 = new List<Autobus> {
                new Autobus("A1", 80, 4, 3, 100, 50),
                new Autobus("A1", 80, 4, 3, 100, 50)};
            
            
            var f1 = new Firma("F1", ta1, lk1, new List<Linia> {l1});
            zt.DodajFirme(f1);
            
            zt.StworzListePrzejazdow();
            zt.WykonajPrzejazdy();
        }
    }


}