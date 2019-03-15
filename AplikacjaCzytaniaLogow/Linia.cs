using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplikacjaCzytaniaLogow
{
    class Linia : IEnumerable<Przejazd>
    {
        public readonly string idLinii;
        public List<Przejazd> przejazdy;

        private Linia()
        {
            przejazdy = new List<Przejazd>();
        }

        public Linia(string idLinii) : this()
        {
            this.idLinii = idLinii;
        }

        public Linia(string idLinii, IEnumerable<Przejazd> przejazdy) : this(idLinii)
        {
            foreach (var p in przejazdy)
            {
                this.przejazdy.Add(p);
            }
        }

        public Przejazd this[int i]
        {
            get
            {
                return przejazdy[i];
            }
        }


        public int ZwrocIndexPrzejazdu(string idPrzejazdu)
        {
            for (int i = 0; i < przejazdy.Count; i++)
                if (przejazdy[i].idPrzejazdu == idPrzejazdu) return i;
            return -1;
        }

        public Przejazd ZwrocPrzejazd(string idPrzejazdu)
        {
            foreach (var p in przejazdy)
                if (p.idPrzejazdu == idPrzejazdu) return p;
            return null;
        }

        public Przejazd ZwrocPrzejazdGodzina(string czas)
        {
            foreach (var p in przejazdy)
                if (p.ZwrocCzasZaczeciaPrzejazdu().ToString() == czas) return p;
            return null;
        }

        public void DodajPrzejazd(Przejazd p)
        {
            przejazdy.Add(p);
        }

        public bool CzyIstniejePrzejazd(string idPrzejazdu)
        {
            foreach (var p in przejazdy)
                if (p.idPrzejazdu == idPrzejazdu) return true;
            return false;
        }

        public IEnumerator<Przejazd> GetEnumerator()
        {
            return przejazdy.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
