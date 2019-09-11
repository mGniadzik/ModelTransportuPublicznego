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
    class AutobusViewModel : BaseViewModel
    {
        private static AutobusViewModel instance = null;

        private static Autobus autobus = null;

        public static AutobusViewModel Instance { get { return instance ?? (instance = new AutobusViewModel()); } }

        public static Autobus Autobus { get { return autobus ?? (autobus = new Autobus()); } }

        private AutobusViewModel()
        {
            CurrentPage = PageType.AutobusConstants;
            autobus = new Autobus();
            OpenAccelerations = new RelayCommand(() =>
            {
                CurrentPage = PageType.AutobusAcceleration;
                OnPropertyChanged("CurrentPage");
            });
            SaveAutobus = new RelayCommand(() =>
            {
                CurrentPage = PageType.AutobusConstants;
                autobus = null;
                OnPropertyChanged("Autobus");
                OnPropertyChanged("CurrentPage");
            });
            GoToMenu = new RelayCommand(() =>
            {
                CurrentPage = PageType.AutobusConstants;
                OnPropertyChanged("CurrentPage");
                MainWindowViewModel.Instance.CurrentPage = PageType.MainPage;
                MainWindowViewModel.Instance.OnPropertyChanged("CurrentPage");
                autobus = new Autobus();
                OnPropertyChanged("Autobus");
            });
            DodajWpisAcc = new RelayCommand(() =>
            {
                autobus.Przyspieszenia.Add(new ProgAutobusuViewModel());
                OnPropertyChanged("PunktyTrasy");
            });
            WyczyscWpisyAcc = new RelayCommand(() =>
            {
                autobus.Przyspieszenia.Clear();
                OnPropertyChanged("PunktyTrasy");
            });
            UsunWpisAcc = new ParameteredRelayCommand<DataGrid>((dGrid) =>
            {
                var item = dGrid.SelectedItem;
                if (item != null && item is ProgAutobusuViewModel)
                {
                    Przyspieszenia.Remove((ProgAutobusuViewModel)item);
                    OnPropertyChanged("PunktyTrasy");
                }
            });
            DodajWpisBrk = new RelayCommand(() =>
            {
                autobus.Hamowania.Add(new ProgAutobusuViewModel());
                OnPropertyChanged("PunktyTrasy");
            });
            WyczyscWpisyBrk = new RelayCommand(() =>
            {
                autobus.Hamowania.Clear();
                OnPropertyChanged("PunktyTrasy");
            });
            UsunWpisBrk = new ParameteredRelayCommand<DataGrid>((dGrid) =>
            {
                var item = dGrid.SelectedItem;
                if (item != null && item is ProgAutobusuViewModel)
                {
                    autobus.Hamowania.Remove((ProgAutobusuViewModel)item);
                    OnPropertyChanged("PunktyTrasy");
                }
            });
        }

        public PageType CurrentPage { get; set; }

        public string Model
        {
            get { return autobus.ModelAutobusu; }
            set
            {
                autobus.ModelAutobusu = value;
                OnPropertyChanged("Model");
            }
        }

        public int MaksymalnaPojemnosc
        {
            get { return autobus.MaksymalnaPojemnosc; }
            set
            {
                autobus.MaksymalnaPojemnosc = value;
                OnPropertyChanged("MaksymalnaPojemnosc");
            }
        }

        public int IloscDrzwi
        {
            get { return autobus.IloscDrzwi; }
            set
            {
                autobus.IloscDrzwi = value;
                OnPropertyChanged("IloscDrzwi");
            }
        }

        public double DlugoscAutobusu
        {
            get { return autobus.DlugoscAutobusu; }
            set
            {
                autobus.DlugoscAutobusu = value;
                OnPropertyChanged("DlugoscAutobusu");
            }
        }

        public double Przyspieszenie
        {
            get { return autobus.Przyspieszenie; }
            set
            {
                autobus.Przyspieszenie = value;
                OnPropertyChanged("Przyspieszenie");
            }
        }

        public double DrogaHamowania
        {
            get { return autobus.DrogaHamowania; }
            set
            {
                autobus.DrogaHamowania = value;
                OnPropertyChanged("DrogaHamowania");
            }
        }

        public double PredkoscMaksymalna
        {
            get { return autobus.PredkoscMaksymalna; }
            set
            {
                autobus.PredkoscMaksymalna = value;
                OnPropertyChanged("PredkoscMaksymalna");
            }
        }

        public ObservableCollection<ProgAutobusuViewModel> Przyspieszenia
        {
            get { return autobus.Przyspieszenia; }
            set { autobus.Przyspieszenia = value; }
        }

        public ObservableCollection<ProgAutobusuViewModel> Hamowania
        {
            get { return autobus.Hamowania; }
            set { autobus.Hamowania = value; }
        }

        public RelayCommand OpenAccelerations { get; set; }

        public RelayCommand SaveAutobus { get; set; }

        public RelayCommand GoToMenu { get; set; }

        public RelayCommand DodajWpisAcc { get; set; }

        public ParameteredRelayCommand<DataGrid> UsunWpisAcc { get; set; }

        public RelayCommand WyczyscWpisyAcc { get; set; }

        public RelayCommand DodajWpisBrk { get; set; }

        public ParameteredRelayCommand<DataGrid> UsunWpisBrk { get; set; }

        public RelayCommand WyczyscWpisyBrk { get; set; }
    }
}
