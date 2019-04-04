namespace ModelTransportuPublicznego.Model {
    public class Trasa {
        protected string nazwaTrasy;
        protected Przystanek.Przystanek przystanekLewy;
        protected Przystanek.Przystanek przystanekPrawy;
        protected int sTrasy;
        protected double vMaxTrasy;

        public string NazwaTrasy => nazwaTrasy;
        public Przystanek.Przystanek PrzystanekLewy => przystanekLewy;
        public Przystanek.Przystanek PrzystanekPrawy => przystanekPrawy;
        public double VMaxTrasy => vMaxTrasy;
        public int DystansTrasy => sTrasy;
        public virtual Trasa TrasaOdwrotna => OdwrocTrase();

        public Trasa(string nazwaTrasy, Przystanek.Przystanek przystanekLewy, Przystanek.Przystanek przystanekPrawy, int sTrasy, double vMaxTrasy) {
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