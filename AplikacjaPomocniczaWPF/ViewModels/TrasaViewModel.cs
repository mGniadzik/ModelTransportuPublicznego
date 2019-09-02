using AplikacjaPomocniczaWPF.Commands;
using AplikacjaPomocniczaWPF.Helpers;
using AplikacjaPomocniczaWPF.Models;
using AplikacjaPomocniczaWPF.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplikacjaPomocniczaWPF.ViewModels
{
    class TrasaViewModel : BaseViewModel
    {
        private static TrasaViewModel instance = null;

        private static Trasa trasa;

        public static TrasaViewModel Instance { get { return instance ?? (instance = new TrasaViewModel()); } }

        public static Trasa Trasa { get { return trasa ?? (trasa = new Trasa()); } }

        public PageType CurrentPage { get; set; }

        public RelayCommand GoToMenu { get; set; }

        public RelayCommand Zapisz { get; set; }

        public string Nazwa
        {
            get { return trasa.Nazwa; }
            set { trasa.Nazwa = value; }
        }

        public double Dlugosc
        {
            get { return trasa.Dlugosc; }
            set { trasa.Dlugosc = value; }
        }

        public double PredkoscMaksymalna
        {
            get { return trasa.PredkoscMaksymalna; }
            set { trasa.PredkoscMaksymalna = value; }
        }

        public ICollection<Point> PunktyTrasy
        {
            get { return trasa.PunktyTrasy; }
            set { trasa.PunktyTrasy = value; }
        }

        private TrasaViewModel()
        {
            CurrentPage = PageType.TrasaData;
            trasa = new Trasa();
            GoToMenu = new RelayCommand(() =>
            {
                trasa = new Trasa();
                OnPropertyChanged("Trasa");
                CurrentPage = PageType.TrasaData;
                OnPropertyChanged("CurrentPage");
                MainWindowViewModel.Instance.CurrentPage = PageType.MainPage;
                MainWindowViewModel.Instance.OnPropertyChanged("CurrentPage");
            });
        }
    }
}
