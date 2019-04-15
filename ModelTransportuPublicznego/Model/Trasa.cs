using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

namespace ModelTransportuPublicznego.Model {
    public class Trasa {
        protected string nazwaTrasy;
        protected Przystanek.Przystanek przystanekLewy;
        protected Przystanek.Przystanek przystanekPrawy;
        protected int sTrasy;
        protected double vMaxTrasy;
        protected List<Point> punktyTrasy;

        public string NazwaTrasy => nazwaTrasy;
        public virtual Przystanek.Przystanek PrzystanekLewy { get { return przystanekLewy; } set { przystanekLewy = value; } }
        public virtual Przystanek.Przystanek PrzystanekPrawy { get { return przystanekPrawy; } set { przystanekPrawy = value; } }
        public virtual double VMaxTrasy => vMaxTrasy;
        public virtual int DystansTrasy => sTrasy;
        public virtual Trasa TrasaOdwrotna => OdwrocTrase();

        public virtual IEnumerable<Point> PunktyTrasy => punktyTrasy;

        public Trasa()
        {
            punktyTrasy = new List<Point>();
        }

        public Trasa(string nazwaTrasy, Przystanek.Przystanek przystanekLewy, Przystanek.Przystanek przystanekPrawy, int sTrasy, 
            double vMaxTrasy, IEnumerable<Point> punktyTrasy = null) : this() {
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

        public Trasa(string nazwaTrasy, int sTrasy, double vMaxTrasy, IEnumerable<Point> punktyTrasy) : this()
        {
            this.nazwaTrasy = nazwaTrasy;
            this.sTrasy = sTrasy;
            this.vMaxTrasy = vMaxTrasy;

            foreach (var p in punktyTrasy)
            {
                this.punktyTrasy.Add(p);
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

        public virtual bool Zapisz(StreamWriter sw)
        {
            try
            {
                sw.WriteLine($"{0}|{1}|{2}", nazwaTrasy, sTrasy, vMaxTrasy);

                var last = punktyTrasy.Last();
                foreach (var p in punktyTrasy)
                {
                    sw.Write($"{0}:{1}", p.X, p.Y);

                    if (p != last)
                    {
                        sw.Write("|");
                    }
                }

            } catch (Exception e)
            {
                System.Console.WriteLine(e);

                return false;
            }

            return true;
        }

        public static Trasa OdczytajPlik(string sciezkaPliku)
        {
            Trasa trasa;

            using (var sr = File.OpenText(sciezkaPliku))
            {
                var dane = sr.ReadLine().Split('|');
                var punkty = new List<Point>();

                do
                {
                    var danePoint = sr.ReadLine().Split(':');
                    punkty.Add(new Point(Convert.ToInt32(danePoint[0]), Convert.ToInt32(danePoint[1])));
                } while (!sr.EndOfStream);

                trasa = new Trasa(dane[0], Convert.ToInt32(dane[1]), Convert.ToDouble(dane[2]), punkty);
            }

            return trasa;
        }
    }
}