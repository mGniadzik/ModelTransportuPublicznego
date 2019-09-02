using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplikacjaPomocniczaWPF.Models
{
    class Przystanek
    {
        public string Nazwa { get; set; }

        public int X { get; set; }

        public int Y { get; set; }

        public double DlugoscZatoki { get; set; }

        public int MaksymalnaPojemnoscPasazerow { get; set; }
    }
}
