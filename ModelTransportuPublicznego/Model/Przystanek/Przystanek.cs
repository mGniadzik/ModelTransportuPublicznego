using System;
using System.Collections.Generic;
using System.Linq;
using ModelTransportuPublicznego.Implementacja.Graf;
using ModelTransportuPublicznego.Implementacja.Pasazerowie;

namespace ModelTransportuPublicznego.Model
{
    public class Przystanek {
        protected int pozycjaX;
        protected int pozycjaY;
        protected int maksymalnaPojemnoscPasazerow;
        protected string nazwaPrzystanku;
        protected List<Pasazer> oczekujacyPasazerowie;
        protected List<Trasa> trasy;
        protected RozkladJazdy rozkladJazdy;
        protected List<Autobus> obecneAutobusy;
        protected List<PrzyplywPasazerow> przyplywyPasazerow;
        protected double dlugoscZatoki;
        protected Queue<Autobus> autobusyOczekujace;
        protected ZarzadTransportu zt;

        public string NazwaPrzystanku => nazwaPrzystanku;

        public RozkladJazdy RozkladJazdy => rozkladJazdy;

        public IEnumerable<Autobus> ObecneAutobusy => obecneAutobusy;

        public IEnumerable<Autobus> AutobusyOczekujace => autobusyOczekujace;

        public int MaksymalnaPojemnoscPasazerow => maksymalnaPojemnoscPasazerow;

        public int X => pozycjaX;

        public int Y => pozycjaY;

        public Przystanek()
        {
            oczekujacyPasazerowie = new List<Pasazer>();
            trasy = new List<Trasa>();
            rozkladJazdy = new RozkladJazdy();
            obecneAutobusy = new List<Autobus>();
            przyplywyPasazerow = new List<PrzyplywPasazerow>();
            autobusyOczekujace = new Queue<Autobus>();
        }

        public Przystanek(string nazwaPrzystanku, ZarzadTransportu zt, double dlugoscZatoki, int pozycjaX = 0, int pozycjaY = 0, int maksymalnaPojemnoscPasazerow = 200) : this() {
            this.nazwaPrzystanku = nazwaPrzystanku;
            this.zt = zt;
            this.dlugoscZatoki = dlugoscZatoki;
            this.maksymalnaPojemnoscPasazerow = maksymalnaPojemnoscPasazerow;
            this.pozycjaX = pozycjaX;
            this.pozycjaY = pozycjaY;
        }

        protected Przystanek(string nazwaPrzystanku, IEnumerable<Trasa> trasy, ZarzadTransportu zt, double dlugoscZatoki, int pozycjaX = 0, int pozycjaY = 0, int maksymalnaPojemnoscPasazerow = 100) 
            : this(nazwaPrzystanku, zt, dlugoscZatoki, pozycjaX, pozycjaY, maksymalnaPojemnoscPasazerow) {
            foreach (var trasa in trasy) {
                this.trasy.Add(trasa);
            }
        }

        protected Przystanek(string nazwaPrzystanku, IEnumerable<Trasa> trasy, IEnumerable<Pasazer> oczekujacyPasazerowie, ZarzadTransportu zt, double dlugoscZatoki, int pozycjaX = 0, int pozycjaY = 0) 
            : this(nazwaPrzystanku, trasy, zt, dlugoscZatoki, pozycjaX, pozycjaY) {
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

        protected virtual double ZwrocDlugoscWolnegoMiejscaZatoki()
        {
            return dlugoscZatoki - obecneAutobusy.Sum((a) => a.DlugoscAutobusu);
        }

        public virtual void DodajAutobusDoZatoki()
        {
            if (autobusyOczekujace.Any())
            {
                var autobus = autobusyOczekujace.Peek();
                if (autobus.DlugoscAutobusu <= ZwrocDlugoscWolnegoMiejscaZatoki())
                {
                    obecneAutobusy.Add(autobusyOczekujace.Dequeue());
                }
            }
        }

        public virtual void DodajAutobus(Autobus a)
        {
            if (a.DlugoscAutobusu <= ZwrocDlugoscWolnegoMiejscaZatoki())
            {
                obecneAutobusy.Add(a);
            }
            else
            {
                autobusyOczekujace.Enqueue(a);
            }
        }

        public virtual void UsunPrasazerowBezTrasy()
        {
            oczekujacyPasazerowie.RemoveAll(p => !p.CzyPosiadaTrase);
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

        public virtual Linia ZnajdzLinieDoPrzystanku(Przystanek przystanek)
        {
            return rozkladJazdy.ZwrocLinie().FirstOrDefault(linia => linia.ZwrocNastepnyPrzystanek(this) == przystanek);
        }

        protected virtual void WykonajPrzyplyw(PrzyplywPasazerow przyplyw, TimeSpan czas) {
            for (int i = 0; i < przyplyw.IloscPasazerow; i++) {
                DodajPasazera(WygenerujPasazera(czas));
            }
        }

        protected virtual PasazerDijkstryBazowy WygenerujPasazera(TimeSpan czas) {
            var rand = new Random();
            
            
            Przystanek pKoncowy;

            do {
                pKoncowy = zt.SiecPrzystankow.ToList()[rand.Next(zt.SiecPrzystankow.Count())];
            } while (pKoncowy == this);

            var rng = rand.Next(100);

            //if (rng < 33)
            //{
            var grafTS = new Graf<TimeSpan>(zt.SiecPrzystankow, TimeSpan.MaxValue);
            grafTS.DodajKrawedzie(zt.ZwrocLinie());
            return new PasazerDijkstry(rand.Next(2, 11), rand.Next(2, 11), this, pKoncowy, grafTS, czas);
            //} else if (rng< 66)
            //{
            //    var grafB = new Graf<byte>(zt.SiecPrzystankow, byte.MaxValue);
            //    grafB.DodajKrawedzie(zt.ZwrocLinie());
            //    return new PasazerWygodnicki(rand.Next(2, 11), rand.Next(2, 11), this, pKoncowy, grafB, czas);
            //}

            //var grafUL = new Graf<ulong>(zt.SiecPrzystankow, ulong.MaxValue);
            //grafUL.DodajKrawedzie(zt.ZwrocLinie());
            //return new PasazerKrotkodystansowy(rand.Next(2, 11), rand.Next(2, 11), this, pKoncowy, grafUL, czas);
        }
    }
}