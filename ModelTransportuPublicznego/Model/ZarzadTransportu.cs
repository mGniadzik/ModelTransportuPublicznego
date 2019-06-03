using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ModelTransportuPublicznego.Model {
    public abstract class ZarzadTransportu {

        protected string nazwaZarzadu;
        protected List<Przystanek.Przystanek> siecPrzystankow;
        protected List<Firma.Firma> listaFirm;
        protected List<Linia> listaLinii;
        protected string sciezkaPliku;
        protected bool czyLinieOdwrotneZostalyDodane;

        public string NazwaZarzadu => nazwaZarzadu;

        public IEnumerable<Przystanek.Przystanek> SiecPrzystankow => siecPrzystankow;
        public IEnumerable<Firma.Firma> ListaFirm => listaFirm;

        public IEnumerable<Linia> ListaLinii => listaLinii;

        public string SciezkaPlikuKonfiguracyjnego => sciezkaPliku;


        public ZarzadTransportu(string nazwaFirmy) {
            this.nazwaZarzadu = nazwaFirmy;
            siecPrzystankow = new List<Przystanek.Przystanek>();
            listaLinii = new List<Linia>();
            listaFirm = new List<Firma.Firma>();
            czyLinieOdwrotneZostalyDodane = false;
        }

        public ZarzadTransportu(string nazwaFirmy, string sciezkaPliku) : this(nazwaFirmy)
        {
            this.sciezkaPliku = sciezkaPliku;
        }

        public ZarzadTransportu(string nazwaFirmy, IEnumerable<Przystanek.Przystanek> siecPrzystankow) : this(nazwaFirmy) {
            foreach (var przystanek in siecPrzystankow) {
                this.siecPrzystankow.Add(przystanek);
            }
            
            listaFirm = new List<Firma.Firma>();
        }

        public ZarzadTransportu(string nazwaFirmy, IEnumerable<Firma.Firma> listaFirm) : this(nazwaFirmy) {
            foreach (var firma in listaFirm) {
                this.listaFirm.Add(firma);
            }
            
            siecPrzystankow = new List<Przystanek.Przystanek>();
        }

        protected ZarzadTransportu(string nazwaFirmy, IEnumerable<Przystanek.Przystanek> siecPrzystankow, IEnumerable<Firma.Firma> listaFirm) : this(nazwaFirmy) {
            foreach (var przystanek in siecPrzystankow) {
                this.siecPrzystankow.Add(przystanek);
            }

            foreach (var firma in listaFirm) {
                this.listaFirm.Add(firma);
            }
        }

        public virtual void DodajPrzystanek(Przystanek.Przystanek przystanek) {
            siecPrzystankow.Add(przystanek);
        }

        public virtual void DodajPrzystanek(IEnumerable<Przystanek.Przystanek> przystanki) {
            foreach (var przystanek in przystanki) {
                siecPrzystankow.Add(przystanek);
            }
        }

        public virtual void UsunPrzystanek(Przystanek.Przystanek przystanek) {
            siecPrzystankow.Remove(przystanek);
        }

        public virtual void DodajFirme(Firma.Firma firma) {
            listaFirm.Add(firma);
        }

        public virtual void DodajFirme(IEnumerable<Firma.Firma> firmy) {
            foreach (var firma in firmy) {
                listaFirm.Add(firma);
            }
        }

        public virtual void UsunFirme(Firma.Firma firma) {
            listaFirm.Remove(firma);
        }

        public virtual Firma.Firma ZwrocFirmePoNazwie(string nazwaFirmy)
        {
            foreach (var f in listaFirm)
            {
                if (f.NazwaFirmy == nazwaFirmy) return f;
            }

            return null;
        }

        public virtual void DodajLinie(Linia linia)
        {
            listaLinii.Add(linia);
        }

        public virtual void DodajLinie(IEnumerable<Linia> linie)
        {
            foreach (var l in linie)
            {
                listaLinii.Add(l);
            }
        }

        public virtual void UsunLinie(Linia linia)
        {
            listaLinii.Remove(linia);
        }

        public virtual IEnumerable<Linia> ZwrocLinie() {
            return listaLinii;
        }

        public virtual Linia ZwrocLiniePoID(string id)
        {
            foreach (var l in listaLinii)
            {
                if (l.IdLinii == id) return l;
            }

            return null;
        }

        public abstract void StworzListePrzejazdow();

        public abstract void DodajPrzejazdDoListy(Przejazd przejazd);

        public abstract void DodajPrzejazdDoListy(string czas, string nazwaFirmy, string idLinii, string modelAutobusu = null);

        public abstract void WykonajPrzejazdy();

        public virtual void StworzRozkladJazdyNaPrzystankach() {
            foreach (var firma in listaFirm) {
                firma.UstawLinieNaPrzystankach();
            }
        }

        public virtual void DodajLiniePowrotne() {
            if (czyLinieOdwrotneZostalyDodane)
            {
                return;
            }

            listaLinii.AddRange(listaLinii.Select(linia => linia.LiniaOdwrotna));
            czyLinieOdwrotneZostalyDodane = true;
        }

        public virtual Przystanek.Przystanek ZwrocPrzystanekPodanejSpecyfikacji(string sciezkaPlikuKonfiguracjiPrzystanku)
        {
            foreach (var p in siecPrzystankow)
            {
                if (p.SciezkaPlikuKonfiguracyjnego == sciezkaPlikuKonfiguracjiPrzystanku)
                {
                    return p;
                }
            }

            return null;
        }

        public virtual Przystanek.Przystanek ZwrocPrzystanekPodanejNazwy(string nazwa)
        {
            foreach (var p in siecPrzystankow)
            {
                if (p.NazwaPrzystanku == nazwa) return p;
            }

            return null;
        }

        public virtual void Zapisz(StreamWriter sw)
        {
            sw.WriteLine(nazwaZarzadu);

            {
                var last = siecPrzystankow.Last();
                foreach (var p in siecPrzystankow)
                {
                    sw.Write(p.SciezkaPlikuKonfiguracyjnego);
                    if (p != last) sw.Write('|');
                }

                sw.WriteLine();
            }

            {
                var last = listaLinii.Last();
                foreach (var l in listaLinii)
                {
                    sw.Write(l.SciezkaPlikuKonfiguracyjnego);
                    if (l != last) sw.Write('|');
                }

                sw.WriteLine();
            }

            {
                var last = listaFirm.Last();
                foreach (var f in listaFirm)
                {
                    sw.Write(f.SciezkaPlikuKonfiguracyjnego);
                    if (f != last) sw.Write('|');
                }

                sw.WriteLine();
            }
        }
    }
}