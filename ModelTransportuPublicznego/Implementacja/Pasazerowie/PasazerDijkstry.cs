using System.Collections.Generic;
using ModelTransportuPublicznego.Model;

namespace ModelTransportuPublicznego.Implementacja.Pasazerowie.PasazerowieOparciNaGrafie {
    public class PasazerDjikstry : Pasazer {

        private static List<TrasaPasazera> obliczoneTrasy;
        
        public PasazerDjikstry(TrasaPasazera trasaPasazera) : base(trasaPasazera) {
            obliczoneTrasy = new List<TrasaPasazera>();
        }

        public PasazerDjikstry(TrasaPasazera trasaPasazera, int czasWsiadania, int czasWysiadania) : base(trasaPasazera, czasWsiadania, czasWysiadania) {
            obliczoneTrasy = new List<TrasaPasazera>();
        }

        private PasazerDjikstry(TrasaPasazera trasaPasazera, int czasWsiadania, int czasWysiadania,
            Przystanek przystanekPoczatkowy, Przystanek przystanekKoncowy)
            : base(trasaPasazera, czasWsiadania, czasWysiadania, przystanekPoczatkowy, przystanekKoncowy) {
            obliczoneTrasy = new List<TrasaPasazera>();
        }

        private bool CzyTrasaObliczona(Przystanek przystanekStartowy, Przystanek przystanekKoncowy) {
            foreach (var otrasa in obliczoneTrasy) {
                if (otrasa.przystanekPoczatkowy == przystanekStartowy &&
                    otrasa.ZwrocPrzystanekKoncowy() == przystanekKoncowy) {
                    return true;
                }
            }

            return false;
        }
    }
}