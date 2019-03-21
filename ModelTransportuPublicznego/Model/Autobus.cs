using System;
using System.Collections.Generic;
using System.Linq;

namespace ModelTransportuPublicznego.Model {
    public abstract class Autobus {
        protected string idAutobusu;
        protected int maksymalnaPojemnosc;
        protected List<Pasazer> obecniPasazerowie;
        protected int iloscDzwi;
        public Linia liniaAutobusu;
        public Kierowca kierowcaAutobusu;

        public Kierowca KierowcaAutobusu => kierowcaAutobusu;

        public string IdAutobusu => idAutobusu;

        public virtual int IloscPasazerow => obecniPasazerowie.Count;

        public List<Pasazer> ObecniPasazerowie => obecniPasazerowie;

        public Autobus(string idAutobusu, int maksymalnaPojemnosc, int iloscDzwi) {
            this.idAutobusu = idAutobusu;
            this.maksymalnaPojemnosc = maksymalnaPojemnosc;
            this.iloscDzwi = iloscDzwi;
            obecniPasazerowie = new List<Pasazer>();
        }

        public Autobus(Autobus autobus, Linia liniaAutobusu, Kierowca kierowcaAutobusu) : this(autobus.idAutobusu, autobus.maksymalnaPojemnosc, autobus.iloscDzwi) {
            this.liniaAutobusu = liniaAutobusu;
            this.kierowcaAutobusu = kierowcaAutobusu;
        }

        protected Autobus(string idAutobusu, int maksymalnaPojemnosc, int iloscDzwi, IEnumerable<Pasazer> obecniPasazerowie) 
            : this(idAutobusu, maksymalnaPojemnosc, iloscDzwi) {
            
            foreach (var pasazer in obecniPasazerowie) {
                this.obecniPasazerowie.Add(pasazer);
            }
        }

        public virtual List<Pasazer> StworzListeWsiadajacychPasazerow(Przystanek obecnyPrzystanek, Linia liniaAutobusu, TimeSpan obecnyCzas) {
            var listaWsiadajacych = new List<Pasazer>();

            foreach (var pasazer in obecnyPrzystanek.ZwrocPasazerowOczekujacychNaLinie(liniaAutobusu, obecnyCzas)) {
                if ((obecniPasazerowie.Count + listaWsiadajacych.Count) < maksymalnaPojemnosc) {
                    listaWsiadajacych.Add(pasazer);
                }
                else {
                    break;
                }
            }

            foreach (var pasazer in listaWsiadajacych) {
                obecnyPrzystanek.UsunPasazera(pasazer);
                pasazer.Wsiadz(this, obecnyCzas);
            }

            return listaWsiadajacych;
        }

        public virtual void WypuscWszystkichPasazerow(Przystanek p)
        {
            WysadzPasazerow(p, obecniPasazerowie);
        }

        public virtual List<Pasazer> StworzListeWysiadajacychPasazerow(Przystanek obecnyPrzystanek) {
            var listaWysiadajacych = new List<Pasazer>();
            
            foreach (var pasazer in obecniPasazerowie) {
                if (pasazer.OczekiwanyPrzystanek == obecnyPrzystanek || pasazer.OczekiwanyPrzystanek == null) {
                    listaWysiadajacych.Add(pasazer);
                    pasazer.Wysiadz(obecnyPrzystanek);
                }
            }

            foreach (var pasazer in listaWysiadajacych) {
                obecniPasazerowie.Remove(pasazer);
            }
            
            return listaWysiadajacych;
        }

        public virtual int PobierzPasazerow(Przystanek obecnyPrzystanek, Linia liniaAutobusu, IEnumerable<Pasazer> listaWsiadajacych) {
            var listaKolejekPasazerow = StworzListeKolejek();
            PodzielPasazerowNaKolejki(listaWsiadajacych, listaKolejekPasazerow);

            foreach (var lista in listaKolejekPasazerow) {
                foreach (var pasazer in lista) {
                    obecniPasazerowie.Add(pasazer);
                }
            }
            
            return ObliczCzasWsiadaniaPasazerow(listaKolejekPasazerow);
        }

        public virtual int WysadzPasazerow(Przystanek obecnyPrzystanek, IEnumerable<Pasazer> listaWysiadajacych) {
            var listaKolejkaPasazerow = StworzListeKolejek();
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
        
        protected virtual IEnumerable<int> PoliczDlaWysiadajacych(
            IEnumerable<IEnumerable<Pasazer>> listaKolejek) {
            return listaKolejek.Select(lista => { return lista.Sum(pasazer => pasazer.CzasWysiadania); });
        }

        protected virtual IEnumerable<int> PoliczDlaWsiadajacych(
            IEnumerable<IEnumerable<Pasazer>> listaKolejek) {
            return listaKolejek.Select(lista => { return lista.Sum(pasazer => pasazer.CzasWsiadania); });
        }

        protected virtual int ObliczCzas(IEnumerable<IEnumerable<Pasazer>> listaKolejek,
            Func<IEnumerable<IEnumerable<Pasazer>>, IEnumerable<int>> metodaObliczania) {
            var czasKoncowy = 0;

            foreach (var czas in metodaObliczania(listaKolejek)) {
                if (czas > czasKoncowy) {
                    czasKoncowy = czas;
                }
            }

            return czasKoncowy;
        }

        protected virtual int ObliczIloscPasazerow(IEnumerable<List<Pasazer>> listaPasazerow) {
            return listaPasazerow.Sum(lista => lista.Count);
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
            obecniPasazerowie.Remove(pasazer);
        }

        public abstract int PrzejedzTrase(Trasa trasa);
    }
}