using AplikacjaPomocniczaWPF.ViewModels;
using System.Windows.Controls;

namespace AplikacjaPomocniczaWPF.Views.Autobus
{
    /// <summary>
    /// Logika interakcji dla klasy AutobusConstants.xaml
    /// </summary>
    public partial class AutobusConstants : UserControl
    {
        public AutobusConstants()
        {
            InitializeComponent();
            DataContext = AutobusViewModel.Instance;
        }
    }
}
