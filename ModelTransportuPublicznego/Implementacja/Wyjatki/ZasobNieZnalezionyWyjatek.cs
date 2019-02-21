using System;

namespace ModelTransportuPublicznego.Implementacja.Wyjatki {
    public class ZasobNieZnalezionyWyjatek : Exception {
        public ZasobNieZnalezionyWyjatek() { }
        public ZasobNieZnalezionyWyjatek(string text) : base(text) { }
        public ZasobNieZnalezionyWyjatek(string text, Exception inner) : base(text, inner) { }
    }
}