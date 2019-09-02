using AplikacjaPomocniczaWPF.Commands;
using AplikacjaPomocniczaWPF.Helpers;
using AplikacjaPomocniczaWPF.Models;
using AplikacjaPomocniczaWPF.ViewModels.Base;
using System;
using System.Collections.Generic;
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
            DeletePrzyspieszeniaRow = new ParameteredRelayCommand<DataGridRow>((row) =>
            {
                Przyspieszenia.Remove(row.Item as ProgAutobusu);
                OnPropertyChanged("Przyspieszenia");
            });
        }

        public PageType CurrentPage { get; set; }

        public string Model
        {
            get { return autobus.ModelAutobusu; }
            set { autobus.ModelAutobusu = value; }
        }

        public int MaksymalnaPojemnosc
        {
            get { return autobus.MaksymalnaPojemnosc; }
            set { autobus.MaksymalnaPojemnosc = value; }
        }

        public int IloscDrzwi
        {
            get { return autobus.IloscDrzwi; }
            set { autobus.IloscDrzwi = value; }
        }

        public double DlugoscAutobusu
        {
            get { return autobus.DlugoscAutobusu; }
            set { autobus.DlugoscAutobusu = value; }
        }

        public double Przyspieszenie
        {
            get { return autobus.Przyspieszenie; }
            set { autobus.Przyspieszenie = value; }
        }

        public double DrogaHamowania
        {
            get { return autobus.DrogaHamowania; }
            set { autobus.DrogaHamowania = value; }
        }

        public double PredkoscMaksymalna
        {
            get { return autobus.PredkoscMaksymalna; }
            set { autobus.PredkoscMaksymalna = value; }
        }

        public ICollection<ProgAutobusu> Przyspieszenia
        {
            get { return autobus.Przyspieszenia; }
            set { autobus.Przyspieszenia = value; }
        }

        public ICollection<ProgAutobusu> Hamowania
        {
            get { return autobus.Hamowania; }
            set { autobus.Hamowania = value; }
        }

        public RelayCommand OpenAccelerations { get; set; }

        public RelayCommand SaveAutobus { get; set; }

        public RelayCommand GoToMenu { get; set; }

        public ParameteredRelayCommand<DataGridRow> DeletePrzyspieszeniaRow { get; set; }
    }
}
