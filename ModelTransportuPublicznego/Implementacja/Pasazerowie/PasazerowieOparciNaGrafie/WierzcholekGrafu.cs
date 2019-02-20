using System.Collections.Generic;
using ModelTransportuPublicznego.Model;

namespace ModelTransportuPublicznego.Implementacja.Pasazerowie.PasazerowieOparciNaGrafie {
    public struct WierzcholekGrafu {
        public Przystanek przystanek;
        public List<KrawedzGrafu> krawedzie;
    }
}