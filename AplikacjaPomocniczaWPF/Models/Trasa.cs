using AplikacjaPomocniczaWPF.ViewModels.CollectionElementViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplikacjaPomocniczaWPF.Models
{
    class Trasa
    {
        public Trasa()
        {
            PunktyTrasy = new ObservableCollection<PunktTrasyViewModel>();
        } 
        public string Nazwa { get; set; }

        public double Dlugosc { get; set; }

        public double PredkoscMaksymalna { get; set; }

        public ObservableCollection<PunktTrasyViewModel> PunktyTrasy { get; set; }
    }
}
