using System;
using System.Collections.Generic;
using ModelTransportuPublicznego.Model;

namespace ModelTransportuPublicznego.Implementacja.Autobusy {
    public class AutobusLiniowy : Autobus {
        private double przyspieszenie;
        private double trasaHamowania100;
        private double predkoscMaksymalna;
        private double aHamowania;

        public AutobusLiniowy(string idAutobusu, int maksymalnaPojemnosc, int iloscDzwi, double przyspieszenie, 
            double trasaHamowania100, double predkoscMaksymalna) : base(idAutobusu, maksymalnaPojemnosc, iloscDzwi) {

            this.przyspieszenie = przyspieszenie;
            this.trasaHamowania100 = trasaHamowania100;
            this.predkoscMaksymalna = predkoscMaksymalna;
            aHamowania = (Math.Pow(100, 2) / 3.6) / (2 * trasaHamowania100);
        }

        public AutobusLiniowy(string idAutobusu, int maksymalnaPojemnosc, int iloscDzwi, double przyspieszenie, 
            double trasaHamowania100, double predkoscMaksymalna, IEnumerable<Pasazer> obecniPasazerowie) 
            : this (idAutobusu, maksymalnaPojemnosc, iloscDzwi, przyspieszenie, trasaHamowania100, predkoscMaksymalna) {

            foreach (var pasazer in obecniPasazerowie) {
                this.obecniPasazerowie.Add(pasazer);
            }
        }

        public override int PrzejedzTrase(Trasa trasa) {
            var tPrzysp = CzasPrzyspieszania(trasa);
            var tHamowania = CzasHamowania(trasa);
            double tVMax = 0;
            var sPrzysp = (przyspieszenie * Math.Pow(tPrzysp, 2));
            var sHamowania = (aHamowania * Math.Pow(tHamowania, 2)) / 2;
            var sPrzejazduVMax = trasa.DystansTrasy - (sPrzysp + sHamowania);

            if (sPrzejazduVMax > 0)
            {
                tVMax = CzasPrzejazduZVMax(trasa);
                return (int)Math.Ceiling(tPrzysp + tVMax + tHamowania);
            }
            else
            {
                tPrzysp = (aHamowania * Math.Sqrt((2 * trasa.DystansTrasy) / aHamowania)) / (przyspieszenie + aHamowania);
                double vMax = przyspieszenie * tPrzysp;
                tHamowania = CzasHamowania(vMax);

                return (int)Math.Ceiling(tPrzysp + tHamowania);
            }
        }

        protected virtual double CzasPrzejazduZVMax(Trasa trasa)
        {
            return trasa.DystansTrasy / Math.Min(predkoscMaksymalna, trasa.VMaxTrasy);
        }

        protected virtual double CzasPrzyspieszania(Trasa trasa)
        {
            return Math.Min(predkoscMaksymalna, trasa.VMaxTrasy) / przyspieszenie;
        }

        protected virtual double CzasHamowania(Trasa trasa)
        {
            return Math.Min(predkoscMaksymalna, trasa.VMaxTrasy) / (aHamowania);
        }

        protected virtual double CzasHamowania(double predkosc)
        {
            return predkosc / aHamowania;
        }
    }
}