using System.Collections.Generic;
using System.Drawing;

namespace ModelTransportuPublicznego.Model {
    public class Trasa {
        protected string nazwaTrasy;
        protected Przystanek.Przystanek przystanekLewy;
        protected Przystanek.Przystanek przystanekPrawy;
        protected int sTrasy;
        protected double vMaxTrasy;
        protected List<Point> punktyTrasy;

        public string NazwaTrasy => nazwaTrasy;
        public Przystanek.Przystanek PrzystanekLewy => przystanekLewy;
        public Przystanek.Przystanek PrzystanekPrawy => przystanekPrawy;
        public double VMaxTrasy => vMaxTrasy;
        public int DystansTrasy => sTrasy;
        public virtual Trasa TrasaOdwrotna => OdwrocTrase();

        public Trasa()
        {
            punktyTrasy = new List<Point>();
        }

        public Trasa(string nazwaTrasy, Przystanek.Przystanek przystanekLewy, Przystanek.Przystanek przystanekPrawy, int sTrasy, double vMaxTrasy, IEnumerable<Point> punktyTrasy = null) {
            this.nazwaTrasy = nazwaTrasy;
            this.przystanekLewy = przystanekLewy;
            this.przystanekPrawy = przystanekPrawy;
            this.sTrasy = sTrasy;
            this.vMaxTrasy = vMaxTrasy;

            if (punktyTrasy != null)
            {
                foreach (var p in punktyTrasy)
                {
                    this.punktyTrasy.Add(p);
                }
            }
        }

        protected virtual Trasa OdwrocTrase() {
            List<Point> punkty = new List<Point>();

            foreach (var p in punktyTrasy)
            {
                punkty.Insert(0, p);
            }

            return new Trasa(nazwaTrasy, PrzystanekPrawy, przystanekLewy, sTrasy, vMaxTrasy, punkty);
        }
    }
}