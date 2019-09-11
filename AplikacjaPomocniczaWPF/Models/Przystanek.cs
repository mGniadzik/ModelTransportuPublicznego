using AplikacjaPomocniczaWPF.ViewModels.CollectionElementViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplikacjaPomocniczaWPF.Models
{
    class Przystanek
    {
        public Przystanek()
        {
            ProgiPasazerow = new ObservableCollection<WpisProguPrzystankuViewModel>();
            ProgiAutobusow = new ObservableCollection<WpisProguPrzystankuViewModel>();
        }

        public string Nazwa { get; set; }

        public int X { get; set; }

        public int Y { get; set; }

        public double DlugoscZatoki { get; set; }

        public int MaksymalnaPojemnoscPasazerow { get; set; }

        public ObservableCollection<WpisProguPrzystankuViewModel> ProgiPasazerow;

        public ObservableCollection<WpisProguPrzystankuViewModel> ProgiAutobusow;
    }
}
