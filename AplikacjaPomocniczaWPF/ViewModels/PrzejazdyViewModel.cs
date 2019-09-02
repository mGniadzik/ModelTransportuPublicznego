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
    class PrzejazdyViewModel : BaseViewModel
    {
        private static PrzejazdyViewModel instance = null;

        private Przejazdy przejazdy = null;

        public Przejazdy Przejazdy { get; set; }

        public static PrzejazdyViewModel Instance { get { return instance ?? (instance = new PrzejazdyViewModel()); } }

        public PageType CurrentPage { get; set; }

        public RelayCommand GoToMenu { get; set; }

        public ICollection<Przejazd> ListaPrzejazdow
        {
            get { return przejazdy.ListaPrzejazdow; }
            set { przejazdy.ListaPrzejazdow = value; }
        }

        private PrzejazdyViewModel()
        {
            CurrentPage = PageType.PrzejazdyData;
            przejazdy = new Przejazdy();
            GoToMenu = new RelayCommand(() =>
            {
                przejazdy = new Przejazdy();
                OnPropertyChanged("Przejazdy");
                CurrentPage = PageType.PrzejazdyData;
                OnPropertyChanged("CurrentPage");
                MainWindowViewModel.Instance.CurrentPage = PageType.MainPage;
                MainWindowViewModel.Instance.OnPropertyChanged("CurrentPage");
            });
        }
    }
}
