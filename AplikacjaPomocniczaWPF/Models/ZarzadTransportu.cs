using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplikacjaPomocniczaWPF.Models
{
    class ZarzadTransportu
    {
        public string Nazwa { get; set; }

        public ICollection<WpisSieci> SiecPrzystankow { get; set; }
    }

    public struct WpisSieci
    {
        public string NazwaPrzystanku { get; set; }

        public string SciezkaPliku { get; set; }
    }
}
