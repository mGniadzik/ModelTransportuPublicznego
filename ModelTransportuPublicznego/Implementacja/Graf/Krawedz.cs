using System;
using ModelTransportuPublicznego.Model;

namespace ModelTransportuPublicznego.Implementacja.Graf {
    public class Krawedz {
        public Wierzcholek wierzcholekStartowy;
        public Wierzcholek wierzcholekKoncowy;
        public TimeSpan spodziewanyCzasPrzejazdu;
        public TimeSpan waga;
        public WpisRozkladuJazdy przejazdWykonywany;

        public Krawedz(Wierzcholek wierzcholekStartowy, Wierzcholek wierzcholekKoncowy,
            TimeSpan spodziewanyCzasPrzejazdu) {
            this.wierzcholekStartowy = wierzcholekStartowy;
            this.wierzcholekKoncowy = wierzcholekKoncowy;
            this.spodziewanyCzasPrzejazdu = spodziewanyCzasPrzejazdu;
        }
    }
}