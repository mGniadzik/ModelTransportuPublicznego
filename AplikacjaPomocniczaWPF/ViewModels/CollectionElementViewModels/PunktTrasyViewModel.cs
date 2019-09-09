using AplikacjaPomocniczaWPF.Models.CollectionModels;
using AplikacjaPomocniczaWPF.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplikacjaPomocniczaWPF.ViewModels.CollectionElementViewModels
{
    class PunktTrasyViewModel : BaseViewModel
    {
        private PunktTrasy punktTrasy;

        public PunktTrasy Punkt { get; set; }

        public PunktTrasyViewModel()
        {
            punktTrasy = new PunktTrasy();
        }

        public int X
        {
            get { return punktTrasy.X; }
            set
            {
                punktTrasy.X = value;
                OnPropertyChanged("X");
            }
        }

        public int Y
        {
            get { return punktTrasy.Y; }
            set
            {
                punktTrasy.Y = value;
                OnPropertyChanged("Y");
            }
        }
    }
}
