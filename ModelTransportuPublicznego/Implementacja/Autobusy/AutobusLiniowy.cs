using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using ModelTransportuPublicznego.Model;

namespace ModelTransportuPublicznego.Implementacja.Autobusy {
    [DataContract]
    public class AutobusLiniowy : Autobus {
        [DataMember]
        private double przyspieszenie;
        [DataMember]
        private double trasaHamowania100;
        [DataMember]
        private double predkoscMaksymalna;
        [DataMember]
        private SortedDictionary<int, int> spowolnieniaPrzyspieszenia;
        [DataMember]
        private SortedDictionary<int, int> wydluzenieHamowania;

        public AutobusLiniowy(string idAutobusu, int maksymalnaPojemnosc, int iloscDzwi, double przyspieszenie, 
            double trasaHamowania100, double predkoscMaksymalna, double dlugoscAutobusu, IEnumerable<KeyValuePair<int, int>> spowolnieniaPrzyspieszenia = null, 
            IEnumerable<KeyValuePair<int, int>> wydluzenieHamowania = null) : base(idAutobusu, maksymalnaPojemnosc, iloscDzwi, dlugoscAutobusu) {

            this.przyspieszenie = przyspieszenie;
            this.trasaHamowania100 = trasaHamowania100;
            this.predkoscMaksymalna = predkoscMaksymalna;
            this.spowolnieniaPrzyspieszenia = new SortedDictionary<int, int>();
            this.wydluzenieHamowania = new SortedDictionary<int, int>();

            if (spowolnieniaPrzyspieszenia != null)
            {
                foreach (var kvp in spowolnieniaPrzyspieszenia)
                {
                    this.spowolnieniaPrzyspieszenia.Add(kvp.Key, kvp.Value);
                }
            }

            if (wydluzenieHamowania != null)
            {
                foreach (var kvp in wydluzenieHamowania)
                {
                    this.wydluzenieHamowania.Add(kvp.Key, kvp.Value);
                }
            }

            //aHamowania = (Math.Pow(100, 2) / 3.6) / (2 * trasaHamowania100);
        }

        public AutobusLiniowy(string idAutobusu, int maksymalnaPojemnosc, int iloscDzwi, double przyspieszenie, 
            double trasaHamowania100, double predkoscMaksymalna, double dlugoscAutobusu, IEnumerable<Pasazer> obecniPasazerowie) 
            : this (idAutobusu, maksymalnaPojemnosc, iloscDzwi, przyspieszenie, trasaHamowania100, predkoscMaksymalna, dlugoscAutobusu) {

            foreach (var pasazer in obecniPasazerowie) {
                this.obecniPasazerowie.Add(pasazer);
            }
        }

        public override int PrzejedzTrase(Trasa trasa) {
            var tPrzysp = CzasPrzyspieszania(trasa);
            var tHamowania = CzasHamowania(trasa);
            double tVMax = 0;
            var sPrzysp = (AktualnePrzyspieszenie() * Math.Pow(tPrzysp, 2));
            var sHamowania = (AktualneHamowanie() * Math.Pow(tHamowania, 2)) / 2;
            var sPrzejazduVMax = trasa.DystansTrasy - (sPrzysp + sHamowania);

            if (sPrzejazduVMax > 0)
            {
                tVMax = CzasPrzejazduZVMax(trasa);
                return (int)Math.Ceiling(tPrzysp + tVMax + tHamowania);
            }
            else
            {
                var aktualnePrzyspieszenie = AktualnePrzyspieszenie();
                tPrzysp = (AktualneHamowanie() * Math.Sqrt((2 * trasa.DystansTrasy) / aktualnePrzyspieszenie)) / (przyspieszenie + aktualnePrzyspieszenie);
                double vMax = aktualnePrzyspieszenie * tPrzysp;
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
            return Math.Min(predkoscMaksymalna, trasa.VMaxTrasy) / AktualnePrzyspieszenie();
        }

        protected virtual double CzasHamowania(Trasa trasa)
        {
            return Math.Min(predkoscMaksymalna, trasa.VMaxTrasy) / (AktualneHamowanie());
        }

        protected virtual double CzasHamowania(double predkosc)
        {
            return predkosc / AktualneHamowanie();
        }

        private double AktualnePrzyspieszenie()
        {
            return przyspieszenie * (1 + AktualneSpowolnieniePrzyspieszenia());
        }

        private double AktualneHamowanie()
        {
            return (Math.Pow(100, 2) / 3.6) / (2 * AktualnaTrasaHamowania());
        }

        private double AktualnaTrasaHamowania()
        {
            var procentZapelnienia = ProcentZapelnieniaAutobusu;
            double zwiekszenieTrasyHamowania = 0;
            foreach (var kvp in wydluzenieHamowania)
            {
                if (kvp.Key > procentZapelnienia)
                {
                    return zwiekszenieTrasyHamowania;
                } else
                {
                    zwiekszenieTrasyHamowania = kvp.Value;
                }
            }

            return zwiekszenieTrasyHamowania;
        }

        private double AktualneSpowolnieniePrzyspieszenia()
        {
            var procentZapelnienia = ProcentZapelnieniaAutobusu;
            double spowolnienie = 0;
            foreach (var kvp in spowolnieniaPrzyspieszenia)
            {
                if (kvp.Key > procentZapelnienia)
                {
                    return spowolnienie;
                } else
                {
                    spowolnienie = kvp.Value;
                }
            }

            return spowolnienie;
        }
    }
}