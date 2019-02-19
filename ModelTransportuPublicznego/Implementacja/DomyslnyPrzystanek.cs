using System.Collections.Generic;
using ModelTransportuPublicznego.Model;

namespace ModelTransportuPublicznego.Implementacja {
    
    public class DomyslnyPrzystanek : Przystanek {
        public DomyslnyPrzystanek(string nazwaPrzystanku) : base(nazwaPrzystanku) { }
        
        public DomyslnyPrzystanek(string nazwaPrzystanku, IEnumerable<Trasa> trasy) : base(nazwaPrzystanku, trasy) { }
    }
}