using AplikacjaPomocniczaWPF.Commands;
using AplikacjaPomocniczaWPF.Helpers;
using AplikacjaPomocniczaWPF.Models;
using AplikacjaPomocniczaWPF.ViewModels.Base;
using AplikacjaPomocniczaWPF.ViewModels.CollectionElementViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

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

        public RelayCommand DodajWpis { get; set; }

        public RelayCommand WyczyscWpisy { get; set; }

        public ParameteredRelayCommand<DataGrid> UsunWpis { get; set; }

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

        public ObservableCollection<PunktTrasyViewModel> PunktyTrasy
        {
            get { return trasa.PunktyTrasy; }
            set
            {
                trasa.PunktyTrasy = value;
                OnPropertyChanged("PunktyTrasy");
            }
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
            DodajWpis = new RelayCommand(() =>
            {
                trasa.PunktyTrasy.Add(new PunktTrasyViewModel());
                OnPropertyChanged("PunktyTrasy");
            });
            WyczyscWpisy = new RelayCommand(() =>
            {
                trasa.PunktyTrasy.Clear();
                OnPropertyChanged("PunktyTrasy");
            });
            UsunWpis = new ParameteredRelayCommand<DataGrid>((dGrid) =>
            {
                var item = dGrid.SelectedItem;
                if (item != null && item is PunktTrasyViewModel)
                {
                    PunktyTrasy.Remove((PunktTrasyViewModel)item);
                    OnPropertyChanged("PunktyTrasy");
                }
            });
        }
    }
}
