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
        private double dostepnaDlugoscZatoki;
        private PowodBrakuUwarunkowania powod;
        public WpisStatusuLinii(bool czyPrzejazdUwarunkowany, TimeSpan czas, double dostepnaDlugoscZatoki, 
            PowodBrakuUwarunkowania powod = PowodBrakuUwarunkowania.LiczbaPasazerow)
        {
            this.czyPrzejazdUwarunkowany = czyPrzejazdUwarunkowany;
            this.czas = czas;
            this.dostepnaDlugoscZatoki = dostepnaDlugoscZatoki;
            this.powod = powod;
        }

        public bool CzyPrzejazdUwarunkowany => czyPrzejazdUwarunkowany;
        public TimeSpan Czas => czas;
        public double DostepnaDlugoscZatoki => dostepnaDlugoscZatoki;

        public PowodBrakuUwarunkowania Powod;
    }

    public enum PowodBrakuUwarunkowania
    {
        LiczbaPasazerow,
        DlugoscAutobusu,
        Brak
    }
}
