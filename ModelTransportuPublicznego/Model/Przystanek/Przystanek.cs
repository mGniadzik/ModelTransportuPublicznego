using System;
using System.Collections.Generic;
using System.Linq;
using ModelTransportuPublicznego.Implementacja.Graf;
using ModelTransportuPublicznego.Implementacja.Pasazerowie;
using ModelTransportuPublicznego.Misc;

namespace ModelTransportuPublicznego.Model {
    public class Przystanek {
        protected string nazwaPrzystanku;
        protected List<Pasazer> oczekujacyPasazerowie;
        protected List<Trasa> trasy;
        protected RozkladJazdy rozkladJazdy;
        protected List<Autobus> obecneAutobusy;
        protected List<PrzyplywPasazerow> przyplywyPasazerow;
        protected ZarzadTransportu zt;

        public string NazwaPrzystanku => nazwaPrzystanku;

        public RozkladJazdy RozkladJazdy => rozkladJazdy;

        public IEnumerable<Autobus> ObecneAutobusy => obecneAutobusy;

        public Przystanek(string nazwaPrzystanku, ZarzadTransportu zt) {
            this.nazwaPrzystanku = nazwaPrzystanku;
            oczekujacyPasazerowie = new List<Pasazer>();
            trasy = new List<Trasa>();
            rozkladJazdy = new RozkladJazdy();
            obecneAutobusy = new List<Autobus>();
            przyplywyPasazerow = new List<PrzyplywPasazerow>();
            this.zt = zt;
        }

        protected Przystanek(string nazwaPrzystanku, IEnumerable<Trasa> trasy, ZarzadTransportu zt) : this(nazwaPrzystanku, zt) {
            foreach (var trasa in trasy) {
                this.trasy.Add(trasa);
            }
        }

        protected Przystanek(string nazwaPrzystanku, IEnumerable<Trasa> trasy, IEnumerable<Pasazer> oczekujacyPasazerowie, ZarzadTransportu zt) : this(nazwaPrzystanku, trasy, zt) {
            foreach (var pasazer in oczekujacyPasazerowie) {
                this.oczekujacyPasazerowie.Add(pasazer);
            }
        }

        protected IEnumerable<Trasa> ZwrocTrasyPrzystanku() {
            return trasy;
        }

        public virtual void UsunPasazera(Pasazer pasazer) {
            this.oczekujacyPasazerowie.Remove(pasazer);
        }
        
        public virtual void DodajPasazera(Pasazer pasazer) {
            this.oczekujacyPasazerowie.Add(pasazer);
        }

        public virtual void DodajTrase(Trasa trasa) {
            trasy.Add(trasa);
        }

        public virtual IEnumerable<Pasazer> ZwrocPasazerowOczekujacychNaLinie(Linia linia, TimeSpan obecnyCzas) {
            var oczekujacyNaLinie = new List<Pasazer>();
            
            foreach (var pasazer in oczekujacyPasazerowie) {
                if (pasazer.OczekiwanaLinia(obecnyCzas) == linia) {
                    oczekujacyNaLinie.Add(pasazer);
                }
            }

            return oczekujacyNaLinie;
        }

        public virtual int IloscPasazerowOczekujacych() {
            return oczekujacyPasazerowie.Count;
        }

        public virtual Trasa ZnajdzTraseDoNastepnegoPrzystanku(Przystanek nastepnyPrzystanek) {
            foreach (var trasa in trasy) {
                if (trasa.PrzystanekPrawy == nastepnyPrzystanek) {
                    return trasa;
                }
            }

            return null;
        }

        public virtual void DodajAutobus(Autobus autobus) {
            obecneAutobusy.Add(autobus);
        }

        public virtual void UsunAutobus(Autobus autobus) {
            obecneAutobusy.Remove(autobus);
        }

        public virtual IEnumerable<WpisRozkladuJazdy> PozostalePrzejazdy() {
            return rozkladJazdy.Where(w => !w.CzyWykonany).ToList();
        }

        public IEnumerable<WpisRozkladuJazdy> PozostalePrzejazdy(IEnumerable<Linia> wybraneLinie) {
            return rozkladJazdy.Where(w => !w.CzyWykonany && wybraneLinie.Contains(w.LiniaObslugujaca));
        }

        public IEnumerable<WpisRozkladuJazdy> PozostalePrzejazdy(IEnumerable<Linia> wybraneLinie, TimeSpan czas) {
            return rozkladJazdy.Where(w => !w.CzyWykonany && wybraneLinie.Contains(w.LiniaObslugujaca) && w.CzasPrzyjazdu >= czas);
        }
        
        

        public virtual IEnumerable<Linia> PozostaleLiniePrzejazdow() {
            var rezultat = new List<Linia>();

            foreach (var wpis in PozostalePrzejazdy()) {
                if (rezultat.Contains(wpis.LiniaObslugujaca)) continue;

                if (!wpis.LiniaObslugujaca.JestPrzystankiemKoncowym(this)) {
                    rezultat.Add(wpis.LiniaObslugujaca);
                }
            }

            return rezultat;
        }

        public virtual TimeSpan ZwrocPierwszyPrzejazdDanejLinii(Linia linia) {
            return rozkladJazdy.Where(w => w.LiniaObslugujaca == linia && !w.CzyWykonany).Min().CzasPrzyjazdu;
        }

        public virtual Trasa ZwrocTraseDo(Przystanek przystanek) {
            foreach (var trasa in trasy) {
                if (trasa.PrzystanekPrawy == przystanek) return trasa;
            }
            
            throw new ArgumentException($"Przystanek {nazwaPrzystanku} nie posiada trasy do przystanku {przystanek.NazwaPrzystanku}!");
        } 

        public virtual void OznaczPrzejazdJakoWykonany(Linia linia) {
            var lista = rozkladJazdy.ZwrocRozkladJazdy().Where(wpis => wpis.CzyWykonany = false)
                .OrderBy(wpis => wpis.CzasPrzyjazdu).ToList();

            foreach (var wpis in lista) {
                if (wpis.LiniaObslugujaca == linia) {
                    wpis.CzyWykonany = true;
                    return;
                }
            }
        }

        public virtual void DodajPrzyplyw(TimeSpan czas, int ilosc) {
            przyplywyPasazerow.Add(new PrzyplywPasazerow(czas, ilosc));
            przyplywyPasazerow.Sort();
        }

        public virtual void DodajPrzyplyw(PrzyplywPasazerow przyplywPasazerow) {
            przyplywyPasazerow.Add(przyplywPasazerow);
            przyplywyPasazerow.Sort();
        }

        public virtual void DodajPrzyplywy(IEnumerable<PrzyplywPasazerow> przyplywyPasazerow) {
            foreach (var przyplyw in przyplywyPasazerow) {
                this.przyplywyPasazerow.Add(przyplyw);
            }
            
            this.przyplywyPasazerow.Sort();
        }

        public virtual void WykonajPrzyplywy(TimeSpan czas) {
            foreach (var przyplyw in przyplywyPasazerow.Where(p => p.CzyWykonany == false && p.CzasPrzyplywu < czas).ToList()) {
                WykonajPrzyplyw(przyplyw, czas);   
            }
        }

        protected virtual void WykonajPrzyplyw(PrzyplywPasazerow przyplyw, TimeSpan czas) {
            for (int i = 0; i < przyplyw.IloscPasazerow; i++) {
                DodajPasazera(WygenerujPasazeraDijkstry(czas));
            }
        }

        protected virtual PasazerDijkstry WygenerujPasazeraDijkstry(TimeSpan czas) {
            var rand = new Random();
            
            var graf = new Graf(zt.SiecPrzystankow);
            graf.DodajKrawedzie(zt.ZwrocLinie());
            Przystanek pKoncowy;

            do {
                pKoncowy = zt.SiecPrzystankow.ToList()[rand.Next(zt.SiecPrzystankow.Count())];
            } while (pKoncowy == this);
            
            return new PasazerDijkstry(rand.Next(2, 11), rand.Next(2, 11), this, pKoncowy, graf, czas);
        }
    }
}