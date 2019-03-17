using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;

namespace ModelTransportuPublicznego.Model {
    public class Linia : IEnumerable {
        protected string idLinii;
        protected RozkladPrzejazdow rozkladPrzejazdow;
        protected List<WpisLinii> trasaLinii;

        public RozkladPrzejazdow RozkladPrzejazdow => rozkladPrzejazdow;

        public string IdLinii => idLinii;

        public Linia LiniaOdwrotna => ZwrocLiniePowrotna();

        public WpisLinii this[int indeks] => trasaLinii[indeks];

        public int Count => trasaLinii.Count;

        public Linia(string idLinii) {
            this.idLinii = idLinii;
            trasaLinii = new List<WpisLinii>();
        }

        public Linia(string idLinii, IEnumerable<WpisLinii> trasaLinii) : this(idLinii) {

            foreach (var przystanek in trasaLinii) {
                this.trasaLinii.Add(przystanek);
            }
        }

        public Linia(string idLinii, IEnumerable<WpisLinii> trasaLinii, RozkladPrzejazdow rozkladPrzejazdow) 
            : this(idLinii, trasaLinii) {
            
            this.rozkladPrzejazdow = rozkladPrzejazdow;
        }

        public virtual Przystanek ZwrocOstatniPrzystanek() {
            return ZwrocPrzystanekIndeks(trasaLinii.Count - 1);
        }

        public virtual IEnumerable<WpisLinii> ZwrocWpisy() {
            return trasaLinii;
        }

        public virtual int ZwrocIndeksPrzystanku(Przystanek przystanek) {
            for (int i = 0; i < trasaLinii.Count; i++) {
                if (trasaLinii[i].przystanek == przystanek) {
                    return i;
                }
            }
            return -1;
        }

        public virtual Przystanek ZwrocPrzystanekIndeks(int indeks) {
            return trasaLinii[indeks].przystanek;
        }

        public IEnumerator GetEnumerator() {
            return trasaLinii.GetEnumerator();
        }

        public TimeSpan SpodziewanyCzasPrzejazduDoPrzystanku(Przystanek przystanek) {
            var rezultat = TimeSpan.Zero;
            
            foreach (var wpis in trasaLinii) {
                rezultat += wpis.czasPrzyjaduDoPrzystanku;
                if (wpis.przystanek == przystanek) return rezultat;
            }
            
            throw new ArgumentException($"Przystanek {przystanek.NazwaPrzystanku} nie występuje na trasie linii {idLinii}.");
        }

        public Przystanek ZwrocNastepnyPrzystanek(Przystanek przystanek) {
            var rezultat = ZnajdzIndexPrzystanku(przystanek);

            if (rezultat == -1 || rezultat == trasaLinii.Count - 1) {
                throw new ArgumentOutOfRangeException();
            }

            return trasaLinii[rezultat + 1].przystanek;
        }

        public virtual int ZnajdzIndexPrzystanku(Przystanek przystanek) {
            var rezultat = 0;

            foreach (var wpis in trasaLinii) {
                if (przystanek == wpis.przystanek) {
                    return rezultat;
                }

                rezultat++;
            }

            return -1;
        }

        public virtual void DodajWpisDoRozkladuPrzystankowLinii() {
            foreach (var czas in rozkladPrzejazdow) {
                var suma = TimeSpan.Zero;
                foreach (var wpis in trasaLinii) {
                    suma += wpis.czasPrzyjaduDoPrzystanku;
                    wpis.przystanek.RozkladJazdy.DodajWpisDoRozkladu(new WpisRozkladuJazdy(this, czas + suma));
                }
            }
        }

        public virtual bool JestPrzystankiemKoncowym(Przystanek przystanek) {
            return przystanek == trasaLinii[trasaLinii.Count - 1].przystanek;
        }

        protected virtual Linia ZwrocLiniePowrotna() {
            var rozkladPrzejazdow = new RozkladPrzejazdow(this.rozkladPrzejazdow);
            var wpisyLinii = new List<WpisLinii>();

            foreach (var wpis in trasaLinii) {
                wpisyLinii.Add(new WpisLinii(wpis));   
            }
            
            wpisyLinii.Reverse();
            OdwrocCzasyPrzejazdow(wpisyLinii);
            
            var rezultat = new Linia(idLinii + "R", wpisyLinii, rozkladPrzejazdow);
            
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

        public virtual IEnumerable<Przystanek> ZwrocPozostalePrzystanki(Przystanek przystanek) {
            var rezultat = new List<Przystanek>();
            var czyZnaleziony = false;
            
            foreach (var wpis in trasaLinii) {
                if (czyZnaleziony) rezultat.Add(wpis.przystanek);
                if (wpis.przystanek == przystanek) czyZnaleziony = true;
            }

            return rezultat;
        }

        public virtual bool CzyPrzystanekPozostalDoOdwiedzenia(Przystanek przystanekObecny,
            Przystanek przystanekDocelowy) {
            return ZwrocIndeksPrzystanku(przystanekObecny) < ZnajdzIndexPrzystanku(przystanekDocelowy);
        }

        public virtual TimeSpan CzasPrzejazduPoMiedzyPrzystankami(Przystanek pStartowy, Przystanek pKoncowy) {
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

        protected virtual bool CzyPrzystanekkNalezyDoLinii(Przystanek p) {
            foreach (var w in trasaLinii) {
                if (w.przystanek == p) return true;
            }

            return false;
        }

        public virtual TimeSpan ZwrocSpodziewanyCzasPrzejazduLinii() {
            return new TimeSpan(trasaLinii.Sum(w => w.czasPrzyjaduDoPrzystanku.Ticks));
        }
    }
}