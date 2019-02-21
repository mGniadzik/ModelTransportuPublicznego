using System;
using ModelTransportuPublicznego.Model;

namespace ModelTransportuPublicznego.Implementacja.Wyjatki {
    public class AutobusNieZnalezionyWyjatek : ZasobNieZnalezionyWyjatek {
        public AutobusNieZnalezionyWyjatek() { }
        public AutobusNieZnalezionyWyjatek(string message) : base(message) { }
        public AutobusNieZnalezionyWyjatek(string message, Exception inner) : base(message, inner) { }
    }
}