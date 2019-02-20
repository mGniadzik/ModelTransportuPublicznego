using System;
using System.Collections.Generic;
using System.Linq;

namespace ModelTransportuPublicznego.Model {
    public abstract class Autobus {
        protected string idAutobusu;
        protected int maksymalnaPojemnosc;
        protected List<Pasazer> obecniPasazerowie;
        protected int iloscDzwi;
        
        public Autobus(string idAutobusu, int maksymalnaPojemnosc, int iloscDzwi) {
            this.idAutobusu = idAutobusu;
            this.maksymalnaPojemnosc = maksymalnaPojemnosc;
            this.iloscDzwi = iloscDzwi;
            obecniPasazerowie = new List<Pasazer>();
        }

        protected Autobus(string idAutobusu, int maksymalnaPojemnosc, int iloscDzwi, IEnumerable<Pasazer> obecniPasazerowie) 
            : this(idAutobusu, maksymalnaPojemnosc, iloscDzwi) {
            
            foreach (var pasazer in obecniPasazerowie) {
                this.obecniPasazerowie.Add(pasazer);
            }
        }

        public virtual List<Pasazer> StworzListeWsiadajacychPasazerow(Przystanek obecnyPrzystanek, Linia liniaAutobusu) {
            var listaWsiadajacych = new List<Pasazer>();

            if (obecniPasazerowie.Count < maksymalnaPojemnosc) {
                foreach (var pasazer in obecnyPrzystanek.ZwrocPasazerowOczekujacychNaLinie(liniaAutobusu)) {
                    if (obecniPasazerowie.Count < maksymalnaPojemnosc) {
                        listaWsiadajacych.Add(pasazer);
                    }
                    else {
                        break;
                    }
                }

                foreach (var pasazer in listaWsiadajacych) {
                    obecnyPrzystanek.UsunPasazera(pasazer);
                }
            }

            return listaWsiadajacych;
        }

        public virtual List<Pasazer> StworzListeWysiadajacychPasazerow(Przystanek obecnyPrzystanek) {
            var listaWysiadajacych = new List<Pasazer>();
            
            foreach (var pasazer in obecniPasazerowie) {
                if (pasazer.OczekiwanyPrzystanek == obecnyPrzystanek) {
                    listaWysiadajacych.Add(pasazer);
                }
            }

            foreach (var pasazer in listaWysiadajacych) {
                obecniPasazerowie.Remove(pasazer);
            }
            
            return listaWysiadajacych;
        }

        public virtual int PobierzPasazerow(Przystanek obecnyPrzystanek, Linia liniaAutobusu) {
            var listaKolejekPasazerow = new List<List<Pasazer>>();
            var listaWsiadajacych = StworzListeWsiadajacychPasazerow(obecnyPrzystanek, liniaAutobusu);

            listaKolejekPasazerow = StworzListeKolejek();
            PodzielPasazerowNaKolejki(listaWsiadajacych, listaKolejekPasazerow);

            foreach (var lista in listaKolejekPasazerow) {
                foreach (var pasazer in lista) {
                    obecniPasazerowie.Add(pasazer);
                }
            }
            
            return ObliczCzasWsiadaniaPasazerow(listaKolejekPasazerow);
        }

        public virtual int WysadzPasazerow(Przystanek obecnyPrzystanek) {
            var listaKolejkaPasazerow = new List<List<Pasazer>>();
            var listaWysiadajacych = StworzListeWysiadajacychPasazerow(obecnyPrzystanek);

            listaKolejkaPasazerow = StworzListeKolejek();
            PodzielPasazerowNaKolejki(listaWysiadajacych, listaKolejkaPasazerow);

            foreach (var lista in listaKolejkaPasazerow) {
                foreach (var pasazer in lista) {
                    if (pasazer.PrzystanekKoncowy != obecnyPrzystanek) {
                        obecnyPrzystanek.DodajPasazera(pasazer);
                    }
                }
            }

            return ObliczCzasWysiadaniaPasazerow(listaKolejkaPasazerow);
        }

        protected virtual int ObliczCzasWsiadaniaPasazerow(IEnumerable<IEnumerable<Pasazer>> listaKolejek) {
            return ObliczCzas(listaKolejek, PoliczDlaWsiadajacych);
        }

        protected virtual int ObliczCzasWysiadaniaPasazerow(IEnumerable<IEnumerable<Pasazer>> listaKolejek) {
            return ObliczCzas(listaKolejek, PoliczDlaWysiadajacych);
        }

        protected virtual int ObliczCzas(IEnumerable<IEnumerable<Pasazer>> listaKolejek,
            Func<IEnumerable<IEnumerable<Pasazer>>, IEnumerable<int>> metodaObliczania) {
            var czasKoncowy = 0;

            foreach (var liczba in metodaObliczania(listaKolejek)) {
                czasKoncowy += liczba;
            }

            return czasKoncowy;
        }

        protected virtual IEnumerable<int> PoliczDlaWysiadajacych(
            IEnumerable<IEnumerable<Pasazer>> listaKolejek) {
            return listaKolejek.Select(lista => { return lista.Sum(pasazer => pasazer.CzasWysiadania); });
        }

        protected virtual IEnumerable<int> PoliczDlaWsiadajacych(
            IEnumerable<IEnumerable<Pasazer>> listaKolejek) {
            return listaKolejek.Select(lista => { return lista.Sum(pasazer => pasazer.CzasWsiadania); });
        }

        protected virtual List<List<Pasazer>> StworzListeKolejek() {
            var lista = new List<List<Pasazer>>();
            
            for (var i = 0; i < iloscDzwi; i++) { lista.Add(new List<Pasazer>()); }

            return lista;
        }

        protected virtual void PodzielPasazerowNaKolejki(IEnumerable<Pasazer> listaWsiadajacych, List<List<Pasazer>> listaKolejek) {
            foreach (var pasazer in listaWsiadajacych) {
                pasazer.WybierzKolejke(listaKolejek);
            }
        }

        protected virtual void UsunPasazera(Pasazer pasazer) {
            this.obecniPasazerowie.Remove(pasazer);
        }

        public virtual int IloscPasazerow() {
            return obecniPasazerowie.Count;
        }

        public abstract int PrzejedzTrase(Trasa trasa);
    }
}