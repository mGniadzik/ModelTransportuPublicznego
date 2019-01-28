using System.Collections.Generic;
using ModelTransportuPublicznego.Model;

namespace ModelTransportuPublicznego.Implementacja {
    
    public class DomyslnyZarzadTranspotu : ZarzadTransportu {
        
        public DomyslnyZarzadTranspotu() : base() { }

        public DomyslnyZarzadTranspotu(IEnumerable<Przystanek> listaPrzystankow) : base(listaPrzystankow) { }
        
        public DomyslnyZarzadTranspotu(IEnumerable<Firma> listaFirm) : base(listaFirm) { }
        
        public DomyslnyZarzadTranspotu(IEnumerable<Przystanek> siecPrzystankow, IEnumerable<Firma> listaFirm) 
            : base(siecPrzystankow, listaFirm) { }
    }
}