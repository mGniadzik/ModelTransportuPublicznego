using System;
using System.Collections.Generic;
using ModelTransportuPublicznego.Model;

namespace ModelTransportuPublicznego.Implementacja.Autobusy {
    public sealed class AutobusLiniowy : Autobus {
        private double przyspieszenie;
        private double trasaHamowania100;
        private double predkoscMaksymalna;
        
        public AutobusLiniowy(string idAutobusu, int maksymalnaPojemnosc, int iloscDzwi, double przyspieszenie, 
            double trasaHamowania100, double predkoscMaksymalna) : base(idAutobusu, maksymalnaPojemnosc, iloscDzwi) {

            this.przyspieszenie = przyspieszenie;
            this.trasaHamowania100 = trasaHamowania100;
            this.predkoscMaksymalna = predkoscMaksymalna;
        }

        public AutobusLiniowy(string idAutobusu, int maksymalnaPojemnosc, int iloscDzwi, double przyspieszenie, 
            double trasaHamowania100, double predkoscMaksymalna, IEnumerable<Pasazer> obecniPasazerowie) 
            : this (idAutobusu, maksymalnaPojemnosc, iloscDzwi, przyspieszenie, trasaHamowania100, predkoscMaksymalna) {

            foreach (var pasazer in obecniPasazerowie) {
                this.obecniPasazerowie.Add(pasazer);
            }
        }
        
        public double TrasaPrzyspieszaniaDoPredkosciMaksymalnej() {
            return predkoscMaksymalna / przyspieszenie;
        }

        public double TrasaHamowaniaAutobusu() {
            return predkoscMaksymalna / ObliczWspolczynnikHamowaniaAutobusu();
        }

        public double ObliczWspolczynnikHamowaniaAutobusu() {
            return -Math.Pow(100, 2) / (2 * trasaHamowania100);
        }

        public double CzasJazdyZPredkosciaMaksymalna(int dystans) {
            return dystans * predkoscMaksymalna;
        }

        public double CzasHamowania(double predkosc) {
            return predkosc / ObliczWspolczynnikHamowaniaAutobusu();
        }
        
        public void CzasHamowania(int dystans) {
            
        }
        
        public double CzasJazdyZMaksymalnaPredkosciaNaDystansie(int dystans) {
            return dystans * predkoscMaksymalna;
        }

        public override int PrzejedzTrase(Trasa trasa) {
            return 0;
        }
    }
}