using ModelTransportuPublicznego.Model;

namespace ModelTransportuPublicznego.Implementacja {
    public class PasazerDjikstry : Pasazer {
        public PasazerDjikstry(Linia oczekiwanaLinia) : base(oczekiwanaLinia) { }

        public PasazerDjikstry(Linia oczekiwanaLinia, int czasWsiadania, int czasWysiadania) 
            : base(oczekiwanaLinia, czasWsiadania, czasWysiadania) { }

        public PasazerDjikstry(Linia oczekiwanaLinia, int czasWsiadania, int czasWysiadania, Przystanek przystanekPoczatkowy, Przystanek przystanekKoncowy) 
            : base(oczekiwanaLinia, czasWsiadania, czasWysiadania, przystanekPoczatkowy, przystanekKoncowy) { }
        
        
    }
}