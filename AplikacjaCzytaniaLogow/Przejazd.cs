using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AplikacjaCzytaniaLogow
{
    class Przejazd : IEnumerable<WpisPrzejazdu>
    {
        public readonly string idPrzejazdu;
        private List<WpisPrzejazdu> wpisyPrzejazdu;

        private Przejazd()
        {
            wpisyPrzejazdu = new List<WpisPrzejazdu>();
        }

        private Przejazd(string idPrzejazdu) : this()
        {
            this.idPrzejazdu = idPrzejazdu;
        }

        public Przejazd(string idPrzejazdu, IEnumerable<WpisPrzejazdu> wpisy) : this(idPrzejazdu)
        {
            foreach (var wpis in wpisy)
            {
                wpisyPrzejazdu.Add(wpis);
            }
        }

        public Przejazd(string idPrzejazdu, params WpisPrzejazdu[] wpis) : this(idPrzejazdu)
        {
            wpisyPrzejazdu.AddRange(wpis);
        }

        public string ZwrocCzasZaczeciaPrzejazdu()
        {
            if (wpisyPrzejazdu.Count > 0)
                return wpisyPrzejazdu.OrderBy(w => w.czas).ToList()[0].czas.ToString();
            return "";
        }

        public void DodajWpis(WpisPrzejazdu wpis)
        {
            wpisyPrzejazdu.Add(wpis);
        }

        public void DodajWpis(params WpisPrzejazdu[] wpisy)
        {
            wpisyPrzejazdu.AddRange(wpisy);
        }

        public void DodajWpis(string przystanek, TimeSpan czas)
        {
            wpisyPrzejazdu.Add(new WpisPrzejazdu(przystanek, czas));
        }

        public void DodajWpis(string przystanek, string czas)
        {
            wpisyPrzejazdu.Add(new WpisPrzejazdu(przystanek, czas));
        }

        public void UsunWpis(WpisPrzejazdu wpis)
        {
            wpisyPrzejazdu.Remove(wpis);
        }

        public void UsunWpis(string przystanek, TimeSpan czas)
        {
            foreach (var wpis in wpisyPrzejazdu)
            {
                if (przystanek == wpis.przystanek && czas == wpis.czas)
                {
                    wpisyPrzejazdu.Remove(wpis);
                }
            }
        }

        public IEnumerator<WpisPrzejazdu> GetEnumerator()
        {
            return wpisyPrzejazdu.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
