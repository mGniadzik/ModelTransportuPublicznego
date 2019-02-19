namespace ModelTransportuPublicznego.Model {
    public class Trasa {
        protected Przystanek przystanekPierwszy;
        protected Przystanek przystanekDrugi;
        protected int dystansTrasy;

        public Przystanek PrzystanekPierwszy => przystanekPierwszy;
        public Przystanek PrzystanekDrugi => przystanekDrugi;

        public int DystansTrasy => dystansTrasy;

        public Trasa(Przystanek przystanekPierwszy, Przystanek przystanekDrugi, int dystansTrasy) {
            this.przystanekPierwszy = przystanekPierwszy;
            this.przystanekDrugi = przystanekDrugi;
            this.dystansTrasy = dystansTrasy;
        }
    }
}