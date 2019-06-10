using ModelTransportuPublicznego.Implementacja.LiniaImpl;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ModelTransportuPublicznego.Model
{
    public class Linia : IEnumerable<WpisLinii> {
        protected string idLinii;
        protected string sciezkaPlikuKonfiguracyjnego;
        protected int minLiczbaPasazerowDlaPrzejazdu;
        protected List<WpisLinii> trasaLinii;
        protected List<WpisStatusuLinii> wpisyStatusuLinii;

        public string IdLinii => idLinii;

        public Linia LiniaOdwrotna => ZwrocLiniePowrotna();

        public WpisLinii this[int indeks] => trasaLinii[indeks];

        public virtual IEnumerable<WpisLinii> Wpisy => trasaLinii;

        public int Count => trasaLinii.Count;

        public IEnumerable<WpisStatusuLinii> WpisyStatusuLinii => wpisyStatusuLinii;

        public bool CzyPrzejazdUwarunkowany => trasaLinii.Sum(wpis => wpis.przystanek.IloscPasazerowOczekujacych) > minLiczbaPasazerowDlaPrzejazdu;

        public double MinWolnaDlugoscZatoki => trasaLinii.Min(wpis => wpis.przystanek.WolneMiejsceZatoki);

        public int MinLiczbaPasazerowDlaPrzejazdu => minLiczbaPasazerowDlaPrzejazdu;

        public Przystanek.Przystanek PierwszyPrzystanek => trasaLinii.ElementAt(0).przystanek;

        public string SciezkaPlikuKonfiguracyjnego => sciezkaPlikuKonfiguracyjnego;

        public Linia(string idLinii, int minLiczbaPasazerowDlaPrzejazdu, string sciezkaPlikuKonfiguracyjnego) {
            this.idLinii = idLinii;
            this.sciezkaPlikuKonfiguracyjnego = sciezkaPlikuKonfiguracyjnego;
            this.minLiczbaPasazerowDlaPrzejazdu = minLiczbaPasazerowDlaPrzejazdu;
            trasaLinii = new List<WpisLinii>();
            wpisyStatusuLinii = new List<WpisStatusuLinii>();
        }

        public Linia(string idLinii, int minLiczbaPasazerowDlaPrzejazdu, string sciezkaPlikuKonfiguracyjnego, IEnumerable<WpisLinii> trasaLinii) : this(idLinii, minLiczbaPasazerowDlaPrzejazdu, sciezkaPlikuKonfiguracyjnego) {

            foreach (var przystanek in trasaLinii) {
                this.trasaLinii.Add(przystanek);
            }

            for (int i = 0; i < this.trasaLinii.Count - 1; i++)
            {
                this.trasaLinii[i].trasa.PrzystanekLewy = this.trasaLinii[i].przystanek;
                this.trasaLinii[i].trasa.PrzystanekPrawy = this.trasaLinii[i + 1].przystanek;
            }
        }

        public virtual Przystanek.Przystanek ZwrocOstatniPrzystanek() {
            return ZwrocPrzystanekIndeks(trasaLinii.Count - 1);
        }

        public virtual int ZwrocIndeksPrzystanku(Przystanek.Przystanek przystanek) {
            for (int i = 0; i < trasaLinii.Count; i++) {
                if (trasaLinii[i].przystanek == przystanek) {
                    return i;
                }
            }
            return -1;
        }

        public virtual Przystanek.Przystanek ZwrocPrzystanekIndeks(int indeks) {
            return trasaLinii[indeks].przystanek;
        }

        IEnumerator<WpisLinii> IEnumerable<WpisLinii>.GetEnumerator()
        {
            return trasaLinii.GetEnumerator();
        }

        public IEnumerator GetEnumerator() {
            return trasaLinii.GetEnumerator();
        }

        public TimeSpan SpodziewanyCzasPrzejazduDoPrzystanku(Przystanek.Przystanek przystanek) {
            var rezultat = TimeSpan.Zero;
            
            foreach (var wpis in trasaLinii) {
                rezultat += wpis.czasPrzyjaduDoPrzystanku;
                if (wpis.przystanek == przystanek) return rezultat;
            }
            
            throw new ArgumentException($"Przystanek {przystanek.NazwaPrzystanku} nie występuje na trasie linii {idLinii}.");
        }

        public Przystanek.Przystanek ZwrocNastepnyPrzystanek(Przystanek.Przystanek przystanek) {
            var rezultat = ZnajdzIndexPrzystanku(przystanek);

            if (rezultat == -1 || rezultat >= trasaLinii.Count - 1)
            {
                return null;
            }

            return trasaLinii[rezultat + 1].przystanek;
        }

        public void DodajWpisStatusuLinii(WpisStatusuLinii wsl)
        {
            wpisyStatusuLinii.Add(wsl);
        }

        public void DodajWpisStatusuLinii(bool czyPrzejazdUwarunkowany, TimeSpan czas, double minDlugoscZatoki)
        {
            wpisyStatusuLinii.Add(new WpisStatusuLinii(czyPrzejazdUwarunkowany, czas, minDlugoscZatoki));
        }

        public void DodajWpisStatusuLinii(TimeSpan czas, double dlugoscNajkrotszegoAutobusu)
        {
            var czyIstniejePasujacyAutobus = MinWolnaDlugoscZatoki > dlugoscNajkrotszegoAutobusu;
            wpisyStatusuLinii.Add(new WpisStatusuLinii(CzyPrzejazdUwarunkowany && czyIstniejePasujacyAutobus, czas, MinWolnaDlugoscZatoki));
        }

        public virtual int ZnajdzIndexPrzystanku(Przystanek.Przystanek przystanek)
        {
            var rezultat = 0;

            foreach (var wpis in trasaLinii)
            {
                if (przystanek == wpis.przystanek)
                {
                    return rezultat;
                }

                rezultat++;
            }

            return -1;
        }

        public virtual bool JestPrzystankiemKoncowym(Przystanek.Przystanek przystanek) {
            return przystanek == trasaLinii[trasaLinii.Count - 1].przystanek;
        }

        protected virtual Linia ZwrocLiniePowrotna() {
            var wpisyLinii = new List<WpisLinii>();

            foreach (var wpis in trasaLinii) {
                wpisyLinii.Add(new WpisLinii(wpis));   
            }
            
            wpisyLinii.Reverse();
            OdwrocCzasyPrzejazdow(wpisyLinii);
            
            var rezultat = new Linia(idLinii + "R", minLiczbaPasazerowDlaPrzejazdu, sciezkaPlikuKonfiguracyjnego, wpisyLinii);
            
            rezultat.DodajTrasyPowrotne();

            return rezultat;
        }

        protected virtual void OdwrocCzasyPrzejazdow(List<WpisLinii> listaWpisow) {
            for (int i = 0; i < listaWpisow.Count / 2; i++) {
                var temp = listaWpisow[i].czasPrzyjaduDoPrzystanku;
                listaWpisow[i].czasPrzyjaduDoPrzystanku = listaWpisow[listaWpisow.Count - (i + 1)].czasPrzyjaduDoPrzystanku;
                listaWpisow[listaWpisow.Count - (i + 1)].czasPrzyjaduDoPrzystanku = temp;
            }
        }

        protected virtual void DodajTrasyPowrotne() {
            for (int i = 0; i < trasaLinii.Count - 1; i++) {
                var trasaOdwrotna = trasaLinii[i + 1].przystanek.ZwrocTraseDo(trasaLinii[i].przystanek).TrasaOdwrotna;
                trasaLinii[i].przystanek.DodajTrase(trasaOdwrotna);
            }
        }

        public virtual IEnumerable<Przystanek.Przystanek> ZwrocPozostalePrzystanki(Przystanek.Przystanek przystanek) {
            var rezultat = new List<Przystanek.Przystanek>();
            var czyZnaleziony = false;
            
            foreach (var wpis in trasaLinii) {
                if (czyZnaleziony) rezultat.Add(wpis.przystanek);
                if (wpis.przystanek == przystanek) czyZnaleziony = true;
            }

            return rezultat;
        }

        public virtual bool CzyPrzystanekPozostalDoOdwiedzenia(Przystanek.Przystanek przystanekObecny,
            Przystanek.Przystanek przystanekDocelowy) {
            return ZwrocIndeksPrzystanku(przystanekObecny) < ZnajdzIndexPrzystanku(przystanekDocelowy);
        }

        public virtual TimeSpan CzasPrzejazduPoMiedzyPrzystankami(Przystanek.Przystanek pStartowy, Przystanek.Przystanek pKoncowy) {
            if (!CzyPrzystanekkNalezyDoLinii(pStartowy) || !CzyPrzystanekkNalezyDoLinii(pKoncowy)) 
                throw new ArgumentException($"Przystanek {pStartowy.NazwaPrzystanku} lub " +
                                            $"{pKoncowy.NazwaPrzystanku} nie należy do linii {idLinii}.");
            
            if (ZwrocIndeksPrzystanku(pStartowy) > ZwrocIndeksPrzystanku(pKoncowy)) throw new ArgumentException(
                $"Przystanek {pKoncowy.NazwaPrzystanku} występuje przed {pStartowy.NazwaPrzystanku}.");

            var rezultat = TimeSpan.Zero;
            for (var i = ZwrocIndeksPrzystanku(pStartowy); i <= ZwrocIndeksPrzystanku(pKoncowy); i++) {
                rezultat += trasaLinii[i].czasPrzyjaduDoPrzystanku;
            }

            return rezultat;
        }

        protected virtual bool CzyPrzystanekkNalezyDoLinii(Przystanek.Przystanek p) {
            foreach (var w in trasaLinii) {
                if (w.przystanek == p) return true;
            }

            return false;
        }

        public virtual TimeSpan ZwrocSpodziewanyCzasPrzejazduLinii() {
            return new TimeSpan(trasaLinii.Sum(w => w.czasPrzyjaduDoPrzystanku.Ticks)); ;
        }

        public virtual bool Zapisz(StreamWriter sw)
        {
            try
            {
                sw.WriteLine(idLinii);
                sw.WriteLine(minLiczbaPasazerowDlaPrzejazdu);

                foreach (var wl in trasaLinii)
                {
                    wl.Zapisz(sw);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }

            return true;
        }

        public static Linia OdczytajPlik(string sciezkaPliku, ZarzadTransportu zt)
        {
            string id;
            int minLiczbaPasazerow;
            var wpisy = new List<WpisLinii>();

            using (var sr = File.OpenText(sciezkaPliku))
            {
                id = sr.ReadLine();
                minLiczbaPasazerow = Convert.ToInt32(sr.ReadLine());
                var tekstWpisow = sr.ReadLine().Split('|');

                foreach (var tW in tekstWpisow)
                {
                    wpisy.Add(WpisLinii.Odczytaj(tW, zt));
                }
            }

            for (int i = 0; i < wpisy.Count - 1; i++)
            {
                wpisy[i].trasa.PrzystanekLewy = wpisy[i].przystanek;
                wpisy[i].trasa.PrzystanekPrawy = wpisy[i + 1].przystanek;
            }

            return new Linia(id, minLiczbaPasazerow, sciezkaPliku, wpisy);
        }
    }
}