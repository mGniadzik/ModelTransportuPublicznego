using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelTransportuPublicznego.Implementacja.Wyjatki
{
    class TrasaNieZnalezionaWyjatek : Exception
    {
        public TrasaNieZnalezionaWyjatek() { }
        public TrasaNieZnalezionaWyjatek(string message) : base(message) { }
        public TrasaNieZnalezionaWyjatek(string message, Exception inner) : base(message, inner) { }
    }
}
