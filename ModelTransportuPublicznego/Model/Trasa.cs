namespace ModelTransportuPublicznego.Model {
    public abstract class Trasa {
        protected Przystanek przystanekPierwszy;
        protected Przystanek przystanekDrugi;

        public Przystanek PrzystanekPierwszy => przystanekPierwszy;
        public Przystanek PrzystanekDrugi => przystanekDrugi;

        public Trasa(Przystanek przystanekPierwszy, Przystanek przystanekDrugi) {
            this.przystanekPierwszy = przystanekPierwszy;
            this.przystanekDrugi = przystanekDrugi;
        }
    }
}