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
    class PrzystanekViewModel : BaseViewModel
    {
        private static PrzystanekViewModel instance = null;

        private static Przystanek przystanek = null;

        public static Przystanek Przystanek { get { return przystanek ?? (przystanek = new Przystanek()); } }

        public static PrzystanekViewModel Instance { get { return instance ?? (instance = new PrzystanekViewModel()); } }

        public PageType CurrentPage { get; set; }

        public RelayCommand GoToMenu { get; set; }

        public RelayCommand OpenThresholds { get; set; }

        private PrzystanekViewModel()
        {
            CurrentPage = PageType.PrzystanekConstants;
            przystanek = new Przystanek();
            GoToMenu = new RelayCommand(() =>
            {
                przystanek = new Przystanek();
                OnPropertyChanged("Przystanek");
                CurrentPage = PageType.PrzystanekConstants;
                OnPropertyChanged("CurrentPage");
                MainWindowViewModel.Instance.CurrentPage = PageType.MainPage;
                MainWindowViewModel.Instance.OnPropertyChanged("CurrentPage");
            });
            OpenThresholds = new RelayCommand(() =>
            {
                CurrentPage = PageType.PrzystanekThresholds;
                OnPropertyChanged("CurrentPage");
            });
        }

        public string Nazwa
        {
            get { return przystanek.Nazwa; }
            set { przystanek.Nazwa = value; }
        }

        public int X
        {
            get { return przystanek.X; }
            set { przystanek.X = value; }
        }

        public int Y
        {
            get { return przystanek.Y; }
            set { przystanek.Y = value; }
        }

        public double DlugoscZatoki
        {
            get { return przystanek.DlugoscZatoki; }
            set { przystanek.DlugoscZatoki = value; }
        }

        public int MaksymalnaPojemnoscPasazerow
        {
            get { return przystanek.MaksymalnaPojemnoscPasazerow; }
            set { przystanek.MaksymalnaPojemnoscPasazerow = value; }
        }
    }
}
