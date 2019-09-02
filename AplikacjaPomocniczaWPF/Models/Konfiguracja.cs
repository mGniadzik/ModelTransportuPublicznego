using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplikacjaPomocniczaWPF.Models
{
    class Konfiguracja
    {
        public string ZdjecieObszaru { get; set; }

        public string Przejazdy { get; set; }

        public int SzerokoscMapy { get; set; }

        public int WysokoscMapy { get; set; }

        public string PrzyplywyPasazerow { get; set; }

        public bool LinieOdwrotne { get; set; }

        public ICollection<WpisZarzadu> Zarzady { get; set; }
    }

    public struct WpisZarzadu
    {
        public string Nazwa { get; set; }
        
        public string SciezkaPliku { get; set; }
    }
}
