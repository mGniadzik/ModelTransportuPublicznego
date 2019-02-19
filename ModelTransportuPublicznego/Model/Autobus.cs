using System;

namespace ModelTransportuPublicznego.Model {
    public abstract class Autobus {
        protected string idAutobusu;
        protected string modelAutobusu;
        protected int maksymalnaPojemnosc;
        protected int obecnaIloscPasazerow;
        protected int iloscDzwi;
        
        protected Autobus(string idAutobusu) {
            this.idAutobusu = idAutobusu;
        }
    }
}