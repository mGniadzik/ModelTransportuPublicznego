using AplikacjaPomocniczaWPF.Models.CollectionModels;
using AplikacjaPomocniczaWPF.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplikacjaPomocniczaWPF.ViewModels.CollectionElementViewModels
{
    class WpisSieciViewModel : BaseViewModel
    {
        private WpisSieci wpisSieci;

        public WpisSieci WpisSieci
        {
            get { return wpisSieci; }
            set
            {
                wpisSieci = value;
                OnPropertyChanged("WpisSieci");
            }
        }

        public string NazwaPrzystanku
        {
            get { return wpisSieci.NazwaPrzystanku; }
            set
            {
                wpisSieci.NazwaPrzystanku = value;
                OnPropertyChanged("NazwaPrzystanku");
            }
        }

        public string SciezkaPliku
        {
            get { return wpisSieci.SciezkaPliku; }
            set
            {
                wpisSieci.SciezkaPliku = value;
                OnPropertyChanged("SciezkaPliku");
            }
        }

        public WpisSieciViewModel()
        {
            wpisSieci = new WpisSieci();
        }
    }
}
