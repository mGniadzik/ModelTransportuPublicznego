namespace ModelTransportuPublicznego.Model {
    public class Trasa {
        protected string nazwaTrasy;
        protected Przystanek przystanekPierwszy;
        protected Przystanek przystanekDrugi;
        protected int dystansTrasy;

        public string NazwaTrasy => nazwaTrasy;
        public Przystanek PrzystanekPierwszy => przystanekPierwszy;
        public Przystanek PrzystanekDrugi => przystanekDrugi;

        public int DystansTrasy => dystansTrasy;

        public Trasa(string nazwaTrasy, Przystanek przystanekPierwszy, Przystanek przystanekDrugi, int dystansTrasy) {
            this.nazwaTrasy = nazwaTrasy;
            this.przystanekPierwszy = przystanekPierwszy;
            this.przystanekDrugi = przystanekDrugi;
            this.dystansTrasy = dystansTrasy;
        }
    }
}