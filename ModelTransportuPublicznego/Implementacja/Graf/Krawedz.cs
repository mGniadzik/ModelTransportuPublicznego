using System;

namespace ModelTransportuPublicznego.Implementacja.Graf {
    public struct Krawedz {
        public Wierzcholek wierzcholekStartowy;
        public Wierzcholek wierzcholekKoncowy;
        public TimeSpan spodziewanyCzasPrzejazdu;

        public Krawedz(Wierzcholek wierzcholekStartowy, Wierzcholek wierzcholekKoncowy,
            TimeSpan spodziewanyCzasPrzejazdu) {
            this.wierzcholekStartowy = wierzcholekStartowy;
            this.wierzcholekKoncowy = wierzcholekKoncowy;
            this.spodziewanyCzasPrzejazdu = spodziewanyCzasPrzejazdu;
        }
    }
}