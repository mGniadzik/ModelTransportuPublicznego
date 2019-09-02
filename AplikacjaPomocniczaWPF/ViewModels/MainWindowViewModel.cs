using AplikacjaPomocniczaWPF.Commands;
using AplikacjaPomocniczaWPF.Helpers;
using AplikacjaPomocniczaWPF.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplikacjaPomocniczaWPF.ViewModels
{
    class MainWindowViewModel : BaseViewModel
    {
        private static MainWindowViewModel instance;

        public static MainWindowViewModel Instance
        {
            get
            {
                return instance ?? (instance = new MainWindowViewModel()); 
            }
        }

        public PageType CurrentPage { get; set; }

        public RelayCommand AutobusCommand { get; set; }

        public RelayCommand PrzystanekCommand { get; set; }

        public RelayCommand TrasaCommand { get; set; }

        public RelayCommand LiniaCommand { get; set; }

        public RelayCommand FirmaCommand { get; set; }

        public RelayCommand PrzejazdyCommand { get; set; }

        public RelayCommand ZarzadCommand { get; set; }

        public RelayCommand KonfiguracjaCommand { get; set; }

        public RelayCommand MainWindowCommand { get; set; }


        private MainWindowViewModel()
        {
            CurrentPage = PageType.MainPage;
            AutobusCommand = new RelayCommand(() =>
            {
                CurrentPage = PageType.AutobusContainer;
                OnPropertyChanged("CurrentPage");
            });
            PrzystanekCommand = new RelayCommand(() =>
            {
                CurrentPage = PageType.PrzystanekContainer;
                OnPropertyChanged("CurrentPage");
            });
            TrasaCommand = new RelayCommand(() =>
            {
                CurrentPage = PageType.TrasaContainer;
                OnPropertyChanged("CurrentPage");
            });
            LiniaCommand = new RelayCommand(() =>
            {
                CurrentPage = PageType.LiniaContainer;
                OnPropertyChanged("CurrentPage");
            });
            FirmaCommand = new RelayCommand(() =>
            {
                CurrentPage = PageType.FirmaContainer;
                OnPropertyChanged("CurrentPage");
            });
            PrzejazdyCommand = new RelayCommand(() =>
            {
                CurrentPage = PageType.PrzejazdyContainer;
                OnPropertyChanged("CurrentPage");
            });
            ZarzadCommand = new RelayCommand(() =>
            {
                CurrentPage = PageType.ZarzadContainer;
                OnPropertyChanged("CurrentPage");
            });
            KonfiguracjaCommand = new RelayCommand(() =>
            {
                CurrentPage = PageType.KonfiguracjaContainer;
                OnPropertyChanged("CurrentPage");
            });
            MainWindowCommand = new RelayCommand(() =>
            {
                CurrentPage = PageType.MainPage;
                OnPropertyChanged("CurrentPage");
            });
        }
    }
}
