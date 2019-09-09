using AplikacjaPomocniczaWPF.ViewModels.CollectionElementViewModels;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace AplikacjaPomocniczaWPF.Models
{
    class Autobus
    {
        public Autobus()
        {
            Przyspieszenia = new ObservableCollection<ProgAutobusuViewModel>();
            Hamowania = new ObservableCollection<ProgAutobusuViewModel>();
        }

        public string ModelAutobusu { get; set; }

        public int MaksymalnaPojemnosc { get; set; }

        public int IloscDrzwi { get; set; }

        public double DlugoscAutobusu { get; set; }

        public double Przyspieszenie { get; set; }

        public double DrogaHamowania { get; set; }

        public double PredkoscMaksymalna { get; set; }

        public ObservableCollection<ProgAutobusuViewModel> Przyspieszenia { get; set; }

        public ObservableCollection<ProgAutobusuViewModel> Hamowania { get; set; }
    }
}
