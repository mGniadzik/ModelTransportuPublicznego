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
    class LiniaViewModel : BaseViewModel
    {
        private static LiniaViewModel instance = null;

        private static Linia linia;

        public static Linia Linia { get { return linia ?? (linia = new Linia()); } }

        public static LiniaViewModel Instance { get { return instance ?? (instance = new LiniaViewModel()); } }

        public PageType CurrentPage { get; set; }

        public RelayCommand GoToMenu { get; set; }

        public string IdLinii
        {
            get { return linia.IdLinii; }
            set { linia.IdLinii = value; }
        }

        public int MinimalnaLiczbaPasazerow
        {
            get { return linia.MinimalnaLiczbaPasazerow; }
            set { linia.MinimalnaLiczbaPasazerow = value; }
        }

        private LiniaViewModel()
        {
            CurrentPage = PageType.LiniaData;
            linia = new Linia();
            GoToMenu = new RelayCommand(() =>
            {
                linia = new Linia();
                OnPropertyChanged("Linia");
                CurrentPage = PageType.LiniaData;
                OnPropertyChanged("CurrentPage");
                MainWindowViewModel.Instance.CurrentPage = PageType.MainPage;
                MainWindowViewModel.Instance.OnPropertyChanged("CurrentPage");
            });
        }
    }
}
