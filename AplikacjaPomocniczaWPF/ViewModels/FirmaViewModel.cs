using AplikacjaPomocniczaWPF.Commands;
using AplikacjaPomocniczaWPF.Helpers;
using AplikacjaPomocniczaWPF.Models;
using AplikacjaPomocniczaWPF.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplikacjaPomocniczaWPF.ViewModels
{
    class FirmaViewModel : BaseViewModel
    {
        private static FirmaViewModel instance = null;

        private Firma firma;

        public static FirmaViewModel Instance { get { return instance ?? (instance = new FirmaViewModel()); } }

        public Firma Firma { get; set; }

        public PageType CurrentPage { get; set; }

        public RelayCommand GoToMenu { get; set; }

        public string Nazwa
        {
            get { return firma.Nazwa; }
            set { firma.Nazwa = value; }
        }

        public int LiczbaKierowcow
        {
            get { return firma.LiczbaKierowcow; }
            set { firma.LiczbaKierowcow = value; }
        }

        public ICollection<WpisTaboru> Tabor
        {
            get { return firma.Tabor; }
            set { firma.Tabor = value; }
        }

        private FirmaViewModel()
        {
            CurrentPage = PageType.FirmaData;
            firma = new Firma();
            GoToMenu = new RelayCommand(() =>
            {
                CurrentPage = PageType.FirmaData;
                OnPropertyChanged("CurrentPage");
                firma = new Firma();
                OnPropertyChanged("Firma");
                MainWindowViewModel.Instance.CurrentPage = PageType.MainPage;
                MainWindowViewModel.Instance.OnPropertyChanged("CurrentPage");
            });
        }
    }
}
