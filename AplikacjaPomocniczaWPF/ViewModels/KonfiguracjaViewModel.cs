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
    class KonfiguracjaViewModel : BaseViewModel
    {
        private static KonfiguracjaViewModel instance = null;

        private Konfiguracja konfiguracja = null;

        public Konfiguracja Konfiguracja { get { return konfiguracja ?? (konfiguracja = new Konfiguracja()); } }

        public static KonfiguracjaViewModel Instance { get { return instance ?? (instance = new KonfiguracjaViewModel()); } }

        public RelayCommand GoToMenu { get; set; }

        public RelayCommand GoToZarzady { get; set; }

        public PageType CurrentPage { get; set; }

        public string ZdjecieObszaru
        {
            get { return konfiguracja.ZdjecieObszaru; }
            set
            {
                konfiguracja.ZdjecieObszaru = value;
                OnPropertyChanged("ZdjecieObszaru");
            }
        }

        public string Przejazdy
        {
            get { return konfiguracja.Przejazdy; }
            set
            {
                konfiguracja.Przejazdy = value;
                OnPropertyChanged("Przejazdy");
            }
        }

        public int SzerokoscMapy
        {
            get { return konfiguracja.SzerokoscMapy; }
            set
            {
                konfiguracja.SzerokoscMapy = value;
                OnPropertyChanged("SzerokoscMapy");
            }
        }

        public int WysokoscMapy
        {
            get { return konfiguracja.WysokoscMapy; }
            set
            {
                konfiguracja.WysokoscMapy = value;
                OnPropertyChanged("WysokoscMapy");
            }
        }

        public string PrzyplywyPasazerow
        {
            get { return konfiguracja.PrzyplywyPasazerow; }
            set
            {
                konfiguracja.PrzyplywyPasazerow = value;
                OnPropertyChanged("PrzyplywyPasazerow");
            }
        }

        public bool LinieOdwrotne
        {
            get { return konfiguracja.LinieOdwrotne; }
            set
            {
                konfiguracja.LinieOdwrotne = value;
                OnPropertyChanged("LinieOdwrotne");
            }
        }

        public ICollection<WpisZarzadu> Zarzady
        {
            get { return konfiguracja.Zarzady; }
            set
            {
                konfiguracja.Zarzady = value;
                OnPropertyChanged("Zarzady");
            }
        }

        private KonfiguracjaViewModel()
        {
            CurrentPage = PageType.KonfiguracjaConstants;
            konfiguracja = new Konfiguracja();
            GoToMenu = new RelayCommand(() =>
            {
                CurrentPage = PageType.KonfiguracjaConstants;
                OnPropertyChanged("CurrentPage");
                konfiguracja = new Konfiguracja();
                OnPropertyChanged("Konfiguracja");
                MainWindowViewModel.Instance.CurrentPage = PageType.MainPage;
                MainWindowViewModel.Instance.OnPropertyChanged("CurrentPage");
            });
            GoToZarzady = new RelayCommand(() =>
            {
                CurrentPage = PageType.KonfiguracjaZarzady;
                OnPropertyChanged("CurrentPage");
            });
        }
    }
}
