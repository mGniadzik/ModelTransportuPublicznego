using ModelTransportuPublicznego.Model.Przystanek;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelTransportuPublicznego.Implementacja.LiniaImpl
{
    public class WpisStatusuLinii
    {
        private bool czyPrzejazdUwarunkowany;
        private TimeSpan czas;
        private TimeSpan czasStartu;
        private double dostepnaDlugoscZatoki;
        private PowodBrakuUwarunkowania powod;
        private Przystanek przystanekWpisu;
        public WpisStatusuLinii(bool czyPrzejazdUwarunkowany, TimeSpan czas, TimeSpan czasStartu, double dostepnaDlugoscZatoki, Przystanek przystanekWpisu, 
            PowodBrakuUwarunkowania powod = PowodBrakuUwarunkowania.LiczbaPasazerow)
        {
            this.czyPrzejazdUwarunkowany = czyPrzejazdUwarunkowany;
            this.czasStartu = czasStartu;
            this.czas = czas;
            this.dostepnaDlugoscZatoki = dostepnaDlugoscZatoki;
            this.powod = powod;
            this.przystanekWpisu = przystanekWpisu;
        }

        public bool CzyPrzejazdUwarunkowany => czyPrzejazdUwarunkowany;
        public TimeSpan Czas => czas;

        public TimeSpan CzasStartu => czasStartu;
        public double DostepnaDlugoscZatoki => dostepnaDlugoscZatoki;

        public Przystanek Przystanek => przystanekWpisu;

        public PowodBrakuUwarunkowania Powod;
    }

    public enum PowodBrakuUwarunkowania
    {
        LiczbaPasazerow,
        DlugoscAutobusu,
        Brak
    }
}
