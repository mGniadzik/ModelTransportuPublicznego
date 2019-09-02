using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplikacjaPomocniczaWPF.Models
{
    class Firma
    {
        public string Nazwa { get; set; }

        public int LiczbaKierowcow { get; set; }

        public ICollection<WpisTaboru> Tabor { get; set; }
    }

    public struct WpisTaboru
    {
        public string SciezkaPliku { get; set; }

        public int LiczbaPojazdow { get; set; }
    }
}
