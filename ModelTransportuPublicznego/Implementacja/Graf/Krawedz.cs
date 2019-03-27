using System;
using ModelTransportuPublicznego.Model;

namespace ModelTransportuPublicznego.Implementacja.Graf {
    public class Krawedz<T> where T : IComparable<T> {
        public Wierzcholek<T> wierzcholekStartowy;
        public Wierzcholek<T> wierzcholekKoncowy;
        public TimeSpan spodziewanyCzasPrzejazdu;
        public TimeSpan waga;
        public WpisRozkladuJazdy przejazdWykonywany;

        public Krawedz(Wierzcholek<T> wierzcholekStartowy, Wierzcholek<T> wierzcholekKoncowy,
            TimeSpan spodziewanyCzasPrzejazdu) {
            this.wierzcholekStartowy = wierzcholekStartowy;
            this.wierzcholekKoncowy = wierzcholekKoncowy;
            this.spodziewanyCzasPrzejazdu = spodziewanyCzasPrzejazdu;
        }
    }
}