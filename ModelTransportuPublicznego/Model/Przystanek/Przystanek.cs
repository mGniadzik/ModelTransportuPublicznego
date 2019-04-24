using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using ModelTransportuPublicznego.Implementacja.Graf;
using ModelTransportuPublicznego.Implementacja.Pasazerowie;
using ModelTransportuPublicznego.Implementacja.Wyjatki;
using System.IO;

namespace ModelTransportuPublicznego.Model.Przystanek
{
    public class Przystanek {
        protected int pozycjaX;
        protected int pozycjaY;
        protected int maksymalnaPojemnoscPasazerow;
        protected string nazwaPrzystanku;
        protected string sciezkaPlikuKonfiguracyjnego;
        protected List<Pasazer> oczekujacyPasazerowie;
        protected List<Trasa> trasy;
        protected RozkladJazdy rozkladJazdy;
        protected List<Autobus> obecneAutobusy;
        protected List<PrzyplywPasazerow> przyplywyPasazerow;
        protected double dlugoscZatoki;
        protected Queue<Autobus> autobusyOczekujace;
        protected ZarzadTransportu zt;
        protected SortedDictionary<int, Color> zapelnieniaPasazerow;
        protected SortedDictionary<int, Color> zapelnieniaAutobusow;

        public string NazwaPrzystanku => nazwaPrzystanku;

        public RozkladJazdy RozkladJazdy => rozkladJazdy;

        public IEnumerable<Autobus> ObecneAutobusy => obecneAutobusy;

        public IEnumerable<Autobus> AutobusyOczekujace => autobusyOczekujace;

        public int PoziomZapelnieniaPasazerow
        {
            get
            {
                if (oczekujacyPasazerowie.Count >= maksymalnaPojemnoscPasazerow)
                {
                    return 100;
                }
                else
                {
                    return Convert.ToInt32(Math.Ceiling(oczekujacyPasazerowie.Count / (double)maksymalnaPojemnoscPasazerow));
                }
            }
        }

        public int PoziomZapelnieniaAutobusow
        {
            get
            {
                return Convert.ToInt32(Math.Floor((dlugoscZatoki - ZwrocDlugoscWolnegoMiejscaZatoki()) / dlugoscZatoki));
            }
        }

        public string SciezkaPlikuKonfiguracyjnego => sciezkaPlikuKonfiguracyjnego;

        public Queue<Autobus> AutobusyOczekujaceQueue => autobusyOczekujace;

        public Color ZapelnieniePasazerow => ZwrocKolorZapelnienia(zapelnieniaPasazerow, PoziomZapelnieniaPasazerow);

        public Color ZapelnienieAutobusow => ZwrocKolorZapelnienia(zapelnieniaAutobusow, PoziomZapelnieniaAutobusow);

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
            zapelnieniaPasazerow = new SortedDictionary<int, Color>();
            zapelnieniaAutobusow = new SortedDictionary<int, Color>();
        }

        public Przystanek(string nazwaPrzystanku, ZarzadTransportu zt, double dlugoscZatoki, int pozycjaX = 0, int pozycjaY = 0, 
            int maksymalnaPojemnoscPasazerow = 200, string sciezkaPlikuKonfiguracyjnego = null, IEnumerable<KeyValuePair<int, Color>> zapelnieniePasazerow = null, 
            IEnumerable<KeyValuePair<int, Color>> zapelnienieAutobusow = null) : this() {
            this.nazwaPrzystanku = nazwaPrzystanku;
            this.zt = zt;
            this.dlugoscZatoki = dlugoscZatoki;
            this.maksymalnaPojemnoscPasazerow = maksymalnaPojemnoscPasazerow;
            this.pozycjaX = pozycjaX;
            this.pozycjaY = pozycjaY;
            this.sciezkaPlikuKonfiguracyjnego = sciezkaPlikuKonfiguracyjnego;
            
            if (zapelnieniePasazerow != null)
            {
                foreach (var kvp in zapelnieniePasazerow)
                {
                    this.zapelnieniaPasazerow.Add(kvp.Key, kvp.Value);
                }
            }

            if (zapelnienieAutobusow != null)
            {
                foreach (var kvp in zapelnienieAutobusow)
                {
                    this.zapelnieniaAutobusow.Add(kvp.Key, kvp.Value);
                }
            }
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

        public void UstawZarzadTransportu(ZarzadTransportu zt)
        {
            this.zt = zt;
        }

        protected IEnumerable<Trasa> ZwrocTrasyPrzystanku() {
            return trasy;
        }

        public virtual void UsunPasazera(Pasazer pasazer) {
            oczekujacyPasazerowie.Remove(pasazer);
        }
        
        public virtual void DodajPasazera(Pasazer pasazer) {
            oczekujacyPasazerowie.Add(pasazer);
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

        public virtual bool DodajAutobusDoZatoki()
        {
            if (autobusyOczekujace.Any())
            {
                var autobus = autobusyOczekujace.Peek();
                if (autobus.DlugoscAutobusu <= ZwrocDlugoscWolnegoMiejscaZatoki())
                {
                    obecneAutobusy.Add(autobusyOczekujace.Dequeue());
                    return true;
                }
            }

            return false;
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

        public virtual void DodajZapelnieniaPasazerow(IEnumerable<KeyValuePair<int, Color>> dane)
        {
            DodajZapelnienia(dane, zapelnieniaPasazerow);
        }

        public virtual void DodajZapelnieniaAutobusow(IEnumerable<KeyValuePair<int, Color>> dane)
        {
            DodajZapelnienia(dane, zapelnieniaAutobusow);
        }

        protected virtual void DodajZapelnienia(IEnumerable<KeyValuePair<int, Color>> dane, SortedDictionary<int, Color> rezultat)
        {
            foreach (var kvp in dane)
            {
                rezultat.Add(kvp.Key, kvp.Value);
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
            return rozkladJazdy.Where(w => !w.czyWykonany).ToList();
        }

        public IEnumerable<WpisRozkladuJazdy> PozostalePrzejazdy(IEnumerable<Linia> wybraneLinie) {
            return rozkladJazdy.Where(w => !w.czyWykonany && wybraneLinie.Contains(w.LiniaObslugujaca));
        }

        public IEnumerable<WpisRozkladuJazdy> PozostalePrzejazdy(IEnumerable<Linia> wybraneLinie, TimeSpan czas) {
            return rozkladJazdy.Where(w => !w.czyWykonany && wybraneLinie.Contains(w.LiniaObslugujaca) && w.CzasPrzyjazdu >= czas);
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

        public virtual TimeSpan ZwrocPierwszyPrzejazdDanejLinii(Linia linia)
        {
            var minPrzejazd = rozkladJazdy.Where(w => w.LiniaObslugujaca == linia && !w.czyWykonany).Min();
            if (minPrzejazd != null)
            {
                return minPrzejazd.CzasPrzyjazdu;
            }

            throw new TrasaNieZnalezionaWyjatek();
        }

        public virtual Trasa ZwrocTraseDo(Przystanek przystanek) {
            foreach (var trasa in trasy) {
                if (trasa.PrzystanekPrawy == przystanek) return trasa;
            }
            
            throw new ArgumentException($"Przystanek {nazwaPrzystanku} nie posiada trasy do przystanku {przystanek.NazwaPrzystanku}!");
        } 

        public virtual void OznaczPrzejazdJakoWykonany(Linia linia) {
            var lista = rozkladJazdy.ZwrocRozkladJazdy().Where(wpis => wpis.czyWykonany = false)
                .OrderBy(wpis => wpis.CzasPrzyjazdu).ToList();

            foreach (var wpis in lista) {
                if (wpis.LiniaObslugujaca == linia) {
                    wpis.czyWykonany = true;
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

        public virtual void DodajPrzyplywy(IEnumerable<PrzyplywPasazerow> pPasazerow) {
            foreach (var przyplyw in pPasazerow) {
                przyplywyPasazerow.Add(przyplyw);
            }
            
            przyplywyPasazerow.Sort();
        }

        public virtual void WykonajPrzyplywy(TimeSpan czas) {
            foreach (var przyplyw in przyplywyPasazerow.Where(p => p.CzyWykonany == false && p.czasPrzyplywu < czas).ToList()) {
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

        protected virtual Color ZwrocKolorZapelnienia(SortedDictionary<int, Color> dict, int val)
        {
            foreach (var kvp in dict)
            {
                if (val <= kvp.Key)
                {
                    return kvp.Value;
                }
            }

            return zapelnieniaPasazerow.First().Value;
        }

        public virtual void DodajProgKolorZapelnieniaPasazerow(int prog, Color kolor)
        {
            DodajProgKolor(prog, kolor, zapelnieniaPasazerow);
        }

        public virtual void DodajProgKolorZapelnieniaAutobusow(int prog, Color kolor)
        {
            DodajProgKolor(prog, kolor, zapelnieniaAutobusow);
        }

        protected virtual void DodajProgKolor(int prog, Color kolor, SortedDictionary<int, Color> cel)
        {
            cel.Add(prog, kolor);
        }

        public virtual bool Zapisz(StreamWriter sw)
        {
            try
            {
                sw.WriteLine(string.Format("{0}|{1}|{2}|{3}|{4}|{5}", pozycjaX, pozycjaY, maksymalnaPojemnoscPasazerow, nazwaPrzystanku, dlugoscZatoki, 
                    sciezkaPlikuKonfiguracyjnego));

                var last = zapelnieniaPasazerow.Last();
                foreach (var kvp in zapelnieniaPasazerow)
                {
                    sw.Write("{0}:{1}", kvp.Key, kvp.Value.ToArgb());
                    if (kvp.Key != last.Key)
                    {
                        sw.Write("|");
                    }
                }
                sw.WriteLine();

                last = zapelnieniaAutobusow.Last();
                foreach (var kvp in zapelnieniaAutobusow)
                {
                    sw.Write("{0}:{1}", kvp.Key, kvp.Value.ToArgb());
                    if (kvp.Key != last.Key)
                    {
                        sw.Write("|");
                    }
                }
            } catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }

            return true;
        }

        public static Przystanek OdczytajPlik(string nazwaPliku, ZarzadTransportu zt)
        {
            Przystanek rezultat = null;
            using (var sr = File.OpenText(nazwaPliku))
            {
                var stale = sr.ReadLine().Split('|');
                var zapelnieniaPasazerow = sr.ReadLine().Split('|');
                var zapelnieniaAutobusow = sr.ReadLine().Split('|');

                rezultat = new Przystanek(stale[3], zt, Convert.ToDouble(stale[4]), Convert.ToInt32(stale[0]), Convert.ToInt32(stale[1]), Convert.ToInt32(stale[2]), stale[5]);
                foreach (var val in zapelnieniaPasazerow)
                {
                    var elems = val.Split(':');
                    rezultat.DodajProgKolorZapelnieniaAutobusow(Convert.ToInt32(elems[0]), Color.FromArgb(Convert.ToInt32(elems[1])));

                }

                foreach (var val in zapelnieniaAutobusow)
                {
                    var elems = val.Split(':');
                    rezultat.DodajProgKolorZapelnieniaAutobusow(Convert.ToInt32(elems[0]), Color.FromArgb(Convert.ToInt32(elems[1])));

                }
            }

            return rezultat;
        }

        public virtual void ZresetujProgi()
        {
            zapelnieniaPasazerow = new SortedDictionary<int, Color>();
            zapelnieniaAutobusow = new SortedDictionary<int, Color>();
        }

        protected virtual Pasazer WygenerujPasazera(TimeSpan czas) {
            var rand = new Random();
            
            
            Przystanek pKoncowy;

            do {
                pKoncowy = zt.SiecPrzystankow.ToList()[rand.Next(zt.SiecPrzystankow.Count())];
            } while (pKoncowy == this);

            var rng = rand.Next(100);

            if (rng < 33)
            {
            var grafTs = new Graf<TimeSpan>(zt.SiecPrzystankow, TimeSpan.MaxValue);
            grafTs.DodajKrawedzie(zt.ZwrocLinie());
            return new PasazerDijkstry(rand.Next(2, 11), rand.Next(2, 11), this, pKoncowy, grafTs, czas);
            }
            if (rng< 66)
            {
                var grafB = new Graf<byte>(zt.SiecPrzystankow, byte.MaxValue);
                grafB.DodajKrawedzie(zt.ZwrocLinie());
                return new PasazerWygodnicki(rand.Next(2, 11), rand.Next(2, 11), this, pKoncowy, grafB, czas);
            }

            var grafUl = new Graf<ulong>(zt.SiecPrzystankow, ulong.MaxValue);
            grafUl.DodajKrawedzie(zt.ZwrocLinie());
            return new PasazerKrotkodystansowy(rand.Next(2, 11), rand.Next(2, 11), this, pKoncowy, grafUl, czas);
        }
    }
}