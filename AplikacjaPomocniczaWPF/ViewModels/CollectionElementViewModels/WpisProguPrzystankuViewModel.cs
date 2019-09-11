using AplikacjaPomocniczaWPF.Models.CollectionModels;
using AplikacjaPomocniczaWPF.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplikacjaPomocniczaWPF.ViewModels.CollectionElementViewModels
{
    class WpisProguPrzystankuViewModel : BaseViewModel
    {
        private WpisProguPrzystanku wpisProguPrzystanku;

        public WpisProguPrzystankuViewModel()
        {
            wpisProguPrzystanku = new WpisProguPrzystanku();
        }

        public WpisProguPrzystanku WpisProguPrzystanku
        {
            get { return wpisProguPrzystanku; }
            set
            {
                wpisProguPrzystanku = value;
                OnPropertyChanged("WpisProguPrzystanku");
            }
        }

        public double Prog
        {
            get { return wpisProguPrzystanku.Prog; }
            set
            {
                wpisProguPrzystanku.Prog = value;
                OnPropertyChanged("Prog");
            }
        }

        public Color Kolor
        {
            get { return wpisProguPrzystanku.Kolor; }
            set
            {
                wpisProguPrzystanku.Kolor = value;
                OnPropertyChanged("Kolor");
            }
        }
    }
}
