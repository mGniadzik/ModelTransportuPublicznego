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
    class ZarzadViewModel : BaseViewModel
    {
        private static ZarzadViewModel instance = null;

        private ZarzadTransportu zarzadTransportu = null;

        public static ZarzadViewModel Instance { get { return instance ?? (instance = new ZarzadViewModel()); } }

        public ZarzadTransportu ZarzadTransportu { get { return zarzadTransportu ?? (zarzadTransportu = new ZarzadTransportu()); } }

        public RelayCommand DodajWpis { get; set; }

        public RelayCommand WyczyscWpisy { get; set; }

        public ParameteredRelayCommand<DataGrid> UsunWpis { get; set; }

        public PageType CurrentPage { get; set; }

        public string Nazwa
        {
            get { return zarzadTransportu.Nazwa; }
            set { zarzadTransportu.Nazwa = value; }
        }

        public ObservableCollection<WpisSieciViewModel> SiecPrzystankow
        {
            get { return zarzadTransportu.SiecPrzystankow; }
            set { zarzadTransportu.SiecPrzystankow = value; }
        }

        public RelayCommand GoToMenu { get; set; }

        private ZarzadViewModel()
        {
            CurrentPage = PageType.ZarzadData;
            zarzadTransportu = new ZarzadTransportu();
            GoToMenu = new RelayCommand(() =>
            {
                CurrentPage = PageType.ZarzadData;
                OnPropertyChanged("CurrentPage");
                zarzadTransportu = new ZarzadTransportu();
                OnPropertyChanged("ZarzadTransportu");
                MainWindowViewModel.Instance.CurrentPage = PageType.MainPage;
                MainWindowViewModel.Instance.OnPropertyChanged("CurrentPage");
            });
            DodajWpis = new RelayCommand(() =>
            {
                zarzadTransportu.SiecPrzystankow.Add(new WpisSieciViewModel());
                OnPropertyChanged("SiecPrzystankow");
            });
            WyczyscWpisy = new RelayCommand(() =>
            {
                zarzadTransportu.SiecPrzystankow.Clear();
                OnPropertyChanged("SiecPrzystankow");
            });
            UsunWpis = new ParameteredRelayCommand<DataGrid>((dGrid) =>
            {
                var item = dGrid.SelectedItem;
                if (item != null && item is WpisSieciViewModel)
                {
                    SiecPrzystankow.Remove((WpisSieciViewModel)item);
                    OnPropertyChanged("SiecPrzystankow");
                }
            });
        }
    }
}
