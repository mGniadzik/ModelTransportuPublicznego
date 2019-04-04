using System;

namespace ModelTransportuPublicznego.Implementacja.Wyjatki
{
    class TrasaNieZnalezionaWyjatek : Exception
    {
        public TrasaNieZnalezionaWyjatek() { }
        public TrasaNieZnalezionaWyjatek(string message) : base(message) { }
        public TrasaNieZnalezionaWyjatek(string message, Exception inner) : base(message, inner) { }
    }
}
