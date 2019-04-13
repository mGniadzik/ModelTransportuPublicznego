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
        protected List<WpisLinii> trasaLinii;

        public string IdLinii => idLinii;

        public Linia LiniaOdwrotna => ZwrocLiniePowrotna();

        public WpisLinii this[int indeks] => trasaLinii[indeks];

        public int Count => trasaLinii.Count;

        public string SciezkaPlikuKonfiguracyjnego => sciezkaPlikuKonfiguracyjnego;

        public Linia(string idLinii, string sciezkaPlikuKonfiguracyjnego) {
            this.idLinii = idLinii;
            trasaLinii = new List<WpisLinii>();
        }

        public Linia(string idLinii, string sciezkaPlikuKonfiguracyjnego, IEnumerable<WpisLinii> trasaLinii) : this(idLinii, sciezkaPlikuKonfiguracyjnego) {

            foreach (var przystanek in trasaLinii) {
                this.trasaLinii.Add(przystanek);
            }
        }

        public virtual Przystanek.Przystanek ZwrocOstatniPrzystanek() {
            return ZwrocPrzystanekIndeks(trasaLinii.Count - 1);
        }

        public virtual IEnumerable<WpisLinii> ZwrocWpisy() {
            return trasaLinii;
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
            
            var rezultat = new Linia(idLinii + "R", sciezkaPlikuKonfiguracyjnego, wpisyLinii);
            
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
            return new TimeSpan(trasaLinii.Sum(w => w.czasPrzyjaduDoPrzystanku.Ticks));
        }

        public virtual bool Zapisz(StreamWriter sw)
        {
            try
            {
                sw.WriteLine(idLinii);

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
            var wpisy = new List<WpisLinii>();

            using (var sr = File.OpenText(sciezkaPliku))
            {
                id = sr.ReadLine();

                do
                {
                    wpisy.Add(WpisLinii.Odczytaj(sr, zt));
                } while (!sr.EndOfStream);
            }

            return new Linia(id, sciezkaPliku, wpisy);
        }
    }
}