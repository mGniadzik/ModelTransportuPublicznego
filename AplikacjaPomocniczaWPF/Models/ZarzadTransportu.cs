using AplikacjaPomocniczaWPF.ViewModels.CollectionElementViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplikacjaPomocniczaWPF.Models
{
    class ZarzadTransportu
    {
        public string Nazwa { get; set; }

        public ZarzadTransportu()
        {
            SiecPrzystankow = new ObservableCollection<WpisSieciViewModel>();
        }

        public ObservableCollection<WpisSieciViewModel> SiecPrzystankow { get; set; }
    }
}
