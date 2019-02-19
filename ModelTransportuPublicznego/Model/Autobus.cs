using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;

namespace ModelTransportuPublicznego.Model {
    public abstract class Autobus {
        protected string idAutobusu;
        protected int maksymalnaPojemnosc;
        protected List<Pasazer> obecniPasazerowie;
        protected int iloscDzwi;
        protected Autobus(string idAutobusu, int maksymalnaPojemnosc, int iloscDzwi) {
            this.idAutobusu = idAutobusu;
            this.maksymalnaPojemnosc = maksymalnaPojemnosc;
            this.iloscDzwi = iloscDzwi;
            obecniPasazerowie = new List<Pasazer>();
        }

        protected Autobus(string idAutobusu, int maksymalnaPojemnosc, int iloscDzwi, IEnumerable<Pasazer> obecniPasazerowie) : this(idAutobusu, maksymalnaPojemnosc, iloscDzwi) {
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
                        obecnyPrzystanek.UsunPasazera(pasazer);
                    }
                    else {
                        break;
                    }
                }
            }

            return listaWsiadajacych;
        }

        public virtual List<Pasazer> StworzListeWysiadajacychPasazerow(Przystanek obecnyPrzystanek) {
            var listaWysiadajacych = new List<Pasazer>();
            
            foreach (var pasazer in obecniPasazerowie) {
                if (pasazer.OczekiwanyPrzystanek == obecnyPrzystanek) {
                    obecniPasazerowie.Remove(pasazer);
                    listaWysiadajacych.Add(pasazer);
                }
            }
            
            return listaWysiadajacych;
        }

        public virtual int PobierzPasazerow(Przystanek obecnyPrzystanek, Linia liniaAutobusu) {
            int czasPobierania = 0;
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
            int czasWysadzania = 0;
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
            return ObliczCzas(listaKolejek, StworzListeTaskowDlaWsiadajacych);
        }

        protected virtual int ObliczCzasWysiadaniaPasazerow(IEnumerable<IEnumerable<Pasazer>> listaKolejek) {
            return ObliczCzas(listaKolejek, StworzListeTaskowDlaWysiadajacych);
        }

        protected virtual int ObliczCzas(IEnumerable<IEnumerable<Pasazer>> listaKolejek,
            Func<IEnumerable<IEnumerable<Pasazer>>, IEnumerable<Task<int>>> stworzListeTaskow) {
            var czasKoncowy = 0;
            
            var listaTaskow = stworzListeTaskow(listaKolejek);

            foreach (var task in listaTaskow) {
                task.Start();
            }

            Task.WaitAll(listaTaskow.ToArray());

            foreach (var task in listaTaskow) {
                czasKoncowy += task.Result;
            }

            return czasKoncowy;
        }

        protected virtual IEnumerable<Task<int>> StworzListeTaskowDlaWysiadajacych(
            IEnumerable<IEnumerable<Pasazer>> listaKolejek) {
            return listaKolejek.Select(lista => new Task<int>(() => { return lista.Sum(pasazer => pasazer.CzasWysiadania); }));
        }

        protected virtual IEnumerable<Task<int>> StworzListeTaskowDlaWsiadajacych(
            IEnumerable<IEnumerable<Pasazer>> listaKolejek) {
            return listaKolejek.Select(lista => new Task<int>(() => {
                return lista.Sum(pasazer => pasazer.CzasWsiadania);
            }));
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
    }
}