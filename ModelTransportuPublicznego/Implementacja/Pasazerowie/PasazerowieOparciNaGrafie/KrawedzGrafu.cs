using System;

namespace ModelTransportuPublicznego.Implementacja.Pasazerowie.PasazerowieOparciNaGrafie {
    public struct KrawedzGrafu {
        public WierzcholekGrafu wierzcholekStartowy;
        public WierzcholekGrafu wierzcholekKoncowy;
        public TimeSpan spodziewanyCzasPrzejazdu;
    }
}