using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplikacjaPomocniczaWPF.Models
{
    class Przejazdy
    {
        public ICollection<Przejazd> ListaPrzejazdow { get; set; }
    }

    public struct Przejazd
    {
        public DateTime CzasRozpoczecia { get; set; }

        public string Firma { get; set; }

        public string Linia { get; set; }

        public string Autobus { get; set; }
    }
}
