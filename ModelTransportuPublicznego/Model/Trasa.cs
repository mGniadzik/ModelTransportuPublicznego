namespace ModelTransportuPublicznego.Model {
    public class Trasa {
        protected string nazwaTrasy;
        protected Przystanek przystanekLewy;
        protected Przystanek przystanekPrawy;
        protected int dystansTrasy;

        public string NazwaTrasy => nazwaTrasy;
        public Przystanek PrzystanekLewy => przystanekLewy;
        public Przystanek PrzystanekPrawy => przystanekPrawy;

        public virtual Trasa TrasaOdwrotna => OdwrocTrase();

        public int DystansTrasy => dystansTrasy;

        public Trasa(string nazwaTrasy, Przystanek przystanekLewy, Przystanek przystanekPrawy, int dystansTrasy) {
            this.nazwaTrasy = nazwaTrasy;
            this.przystanekLewy = przystanekLewy;
            this.przystanekPrawy = przystanekPrawy;
            this.dystansTrasy = dystansTrasy;
        }

        protected virtual Trasa OdwrocTrase() {
            return new Trasa(nazwaTrasy, PrzystanekPrawy, przystanekLewy, dystansTrasy);
        }
    }
}