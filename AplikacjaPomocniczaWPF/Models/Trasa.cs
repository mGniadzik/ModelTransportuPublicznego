using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplikacjaPomocniczaWPF.Models
{
    class Trasa
    {
        public string Nazwa { get; set; }

        public double Dlugosc { get; set; }

        public double PredkoscMaksymalna { get; set; }

        public ICollection<Point> PunktyTrasy { get; set; }
    }
}
