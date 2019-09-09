using AplikacjaPomocniczaWPF.Models.CollectionModels;
using AplikacjaPomocniczaWPF.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplikacjaPomocniczaWPF.ViewModels.CollectionElementViewModels
{
    class ProgAutobusuViewModel : BaseViewModel
    {
        private ProgAutobusu progAutobusu;

        public ProgAutobusu ProgAutobusu
        {
            get { return progAutobusu; }
            set
            {
                progAutobusu = value;
                OnPropertyChanged("ProgAutobusu");
            }
        }

        public ProgAutobusuViewModel()
        {
            progAutobusu = new ProgAutobusu();
        }

        public double Zapelnienie
        {
            get { return progAutobusu.Zapelnienie; }
            set
            {
                progAutobusu.Zapelnienie = value;
                OnPropertyChanged("Zapelnienie");
            }
        }

        public double Efektywnosc
        {
            get { return progAutobusu.Efektywnosc; }
            set
            {
                progAutobusu.Efektywnosc = value;
                OnPropertyChanged("Efektywnosc");
            }
        }
    }
}
