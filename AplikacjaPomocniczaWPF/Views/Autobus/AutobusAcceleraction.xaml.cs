using AplikacjaPomocniczaWPF.ViewModels;
using System.Windows.Controls;

namespace AplikacjaPomocniczaWPF.Views.Autobus
{
    /// <summary>
    /// Logika interakcji dla klasy AutobusAcceleraction.xaml
    /// </summary>
    public partial class AutobusAcceleraction : UserControl
    {
        public AutobusAcceleraction()
        {
            InitializeComponent();
            DataContext = AutobusViewModel.Instance;
        }
    }
}
