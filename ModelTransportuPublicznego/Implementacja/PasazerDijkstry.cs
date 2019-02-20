using ModelTransportuPublicznego.Model;

namespace ModelTransportuPublicznego.Implementacja {
    public class PasazerDjikstry : Pasazer {
        public PasazerDjikstry(TrasaPasazera trasaPasazera) : base(trasaPasazera) {
        }

        public PasazerDjikstry(TrasaPasazera trasaPasazera, int czasWsiadania, int czasWysiadania) : base(trasaPasazera, czasWsiadania, czasWysiadania) {
        }

        public PasazerDjikstry(TrasaPasazera trasaPasazera, int czasWsiadania, int czasWysiadania, Przystanek przystanekPoczatkowy, Przystanek przystanekKoncowy) : base(trasaPasazera, czasWsiadania, czasWysiadania, przystanekPoczatkowy, przystanekKoncowy) {
        }
    }
}