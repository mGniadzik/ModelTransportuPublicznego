using AplikacjaPomocniczaWPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AplikacjaPomocniczaWPF.Views.Zarzad
{
    /// <summary>
    /// Logika interakcji dla klasy ZarzadContainer.xaml
    /// </summary>
    public partial class ZarzadContainer : UserControl
    {
        public ZarzadContainer()
        {
            InitializeComponent();
            DataContext = ZarzadViewModel.Instance;
        }
    }
}
