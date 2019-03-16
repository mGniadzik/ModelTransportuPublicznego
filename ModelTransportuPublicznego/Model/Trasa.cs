namespace ModelTransportuPublicznego.Model {
    public class Trasa {
        protected string nazwaTrasy;
        protected Przystanek przystanekLewy;
        protected Przystanek przystanekPrawy;
        protected double sTrasy;
        protected double vMaxTrasy;

        public string NazwaTrasy => nazwaTrasy;
        public Przystanek PrzystanekLewy => przystanekLewy;
        public Przystanek PrzystanekPrawy => przystanekPrawy;
        public double VMaxTrasy => vMaxTrasy;
        public double DystansTrasy => sTrasy;
        public virtual Trasa TrasaOdwrotna => OdwrocTrase();

        public Trasa(string nazwaTrasy, Przystanek przystanekLewy, Przystanek przystanekPrawy, double sTrasy, double vMaxTrasy) {
            this.nazwaTrasy = nazwaTrasy;
            this.przystanekLewy = przystanekLewy;
            this.przystanekPrawy = przystanekPrawy;
            this.sTrasy = sTrasy;
            this.vMaxTrasy = vMaxTrasy;
        }

        protected virtual Trasa OdwrocTrase() {
            return new Trasa(nazwaTrasy, PrzystanekPrawy, przystanekLewy, sTrasy, vMaxTrasy);
        }
    }
}