using System;

namespace ModelTransportuPublicznego.Implementacja.Wyjatki {
    public class KierowcaNieZnalezionyWyjatek : ZasobNieZnalezionyWyjatek {
        public KierowcaNieZnalezionyWyjatek() { }
        public KierowcaNieZnalezionyWyjatek(string message) : base(message) { }
        public KierowcaNieZnalezionyWyjatek(string message, Exception inner) : base(message, inner) { }
    }
}