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
    class ZarzadViewModel : BaseViewModel
    {
        private static ZarzadViewModel instance = null;

        private ZarzadTransportu zarzadTransportu = null;

        public static ZarzadViewModel Instance { get { return instance ?? (instance = new ZarzadViewModel()); } }

        public ZarzadTransportu ZarzadTransportu { get { return zarzadTransportu ?? (zarzadTransportu = new ZarzadTransportu()); } }

        public PageType CurrentPage { get; set; }

        public string Nazwa
        {
            get { return zarzadTransportu.Nazwa; }
            set { zarzadTransportu.Nazwa = value; }
        }

        public ICollection<WpisSieci> SiecPrzystankow
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
        }
    }
}
