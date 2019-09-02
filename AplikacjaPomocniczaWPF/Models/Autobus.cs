using System.Collections.Generic;

namespace AplikacjaPomocniczaWPF.Models
{
    class Autobus
    {
        public Autobus()
        {
            Przyspieszenia = new List<ProgAutobusu>();
            Hamowania = new List<ProgAutobusu>();
        }

        public string ModelAutobusu { get; set; }

        public int MaksymalnaPojemnosc { get; set; }

        public int IloscDrzwi { get; set; }

        public double DlugoscAutobusu { get; set; }

        public double Przyspieszenie { get; set; }

        public double DrogaHamowania { get; set; }

        public double PredkoscMaksymalna { get; set; }

        public ICollection<ProgAutobusu> Przyspieszenia { get; set; }

        public ICollection<ProgAutobusu> Hamowania { get; set; }
    }
}
