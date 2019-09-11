using AplikacjaPomocniczaWPF.Commands;
using AplikacjaPomocniczaWPF.Helpers;
using AplikacjaPomocniczaWPF.Models;
using AplikacjaPomocniczaWPF.ViewModels.Base;
using AplikacjaPomocniczaWPF.ViewModels.CollectionElementViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

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

        public RelayCommand DodajWpisPasazerowie { get; set; }

        public ParameteredRelayCommand<DataGrid> UsunWpisPasazerowie { get; set; }

        public RelayCommand WyczyscWpisyPasazerowie { get; set; }

        public RelayCommand DodajWpisAutobusy { get; set; }

        public ParameteredRelayCommand<DataGrid> UsunWpisAutobusy { get; set; }

        public RelayCommand WyczyscWpisyAutobusy { get; set; }

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
            DodajWpisPasazerowie = new RelayCommand(() =>
            {
                ProgiPasazerow.Add(new WpisProguPrzystankuViewModel());
                OnPropertyChanged("ProgiPasazerow");
            });
            WyczyscWpisyPasazerowie = new RelayCommand(() =>
            {
                przystanek.ProgiPasazerow.Clear();
                OnPropertyChanged("ProgiPasazerow");
            });
            UsunWpisPasazerowie = new ParameteredRelayCommand<DataGrid>((dGrid) =>
            {
                var item = dGrid.SelectedItem;
                if (item != null && item is WpisProguPrzystankuViewModel)
                {
                    przystanek.ProgiPasazerow.Remove((WpisProguPrzystankuViewModel)item);
                    OnPropertyChanged("ProgiPasazerow");
                }
            });
            DodajWpisAutobusy = new RelayCommand(() =>
            {
                ProgiAutobusow.Add(new WpisProguPrzystankuViewModel());
                OnPropertyChanged("ProgiAutobusow");
            });
            WyczyscWpisyAutobusy = new RelayCommand(() =>
            {
                przystanek.ProgiAutobusow.Clear();
                OnPropertyChanged("ProgiAutobusow");
            });
            UsunWpisPasazerowie = new ParameteredRelayCommand<DataGrid>((dGrid) =>
            {
                var item = dGrid.SelectedItem;
                if (item != null && item is WpisProguPrzystankuViewModel)
                {
                    przystanek.ProgiAutobusow.Remove((WpisProguPrzystankuViewModel)item);
                    OnPropertyChanged("ProgiAutobusow");
                }
            });
        }

        public string Nazwa
        {
            get { return przystanek.Nazwa; }
            set
            {
                przystanek.Nazwa = value;
                OnPropertyChanged("Nazwa");
            }
        }

        public int X
        {
            get { return przystanek.X; }
            set
            {
                przystanek.X = value;
                OnPropertyChanged("X");
            }
        }

        public int Y
        {
            get { return przystanek.Y; }
            set
            {
                przystanek.Y = value;
                OnPropertyChanged("Y");
            }
        }

        public double DlugoscZatoki
        {
            get { return przystanek.DlugoscZatoki; }
            set
            {
                przystanek.DlugoscZatoki = value;
                OnPropertyChanged("DlugoscZatoki");
            }
        }

        public int MaksymalnaPojemnoscPasazerow
        {
            get { return przystanek.MaksymalnaPojemnoscPasazerow; }
            set
            {
                przystanek.MaksymalnaPojemnoscPasazerow = value;
                OnPropertyChanged("MaksymalnaPojemnoscPasazerow");
            }
        }

        public ObservableCollection<WpisProguPrzystankuViewModel> ProgiPasazerow
        {
            get { return przystanek.ProgiPasazerow; }
            set { przystanek.ProgiPasazerow = value; }
        }

        public ObservableCollection<WpisProguPrzystankuViewModel> ProgiAutobusow
        {
            get { return przystanek.ProgiAutobusow; }
            set { przystanek.ProgiAutobusow = value; }
        }
    }
}
