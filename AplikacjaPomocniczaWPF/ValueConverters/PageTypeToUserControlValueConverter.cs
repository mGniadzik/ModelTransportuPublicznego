using AplikacjaPomocniczaWPF.Helpers;
using AplikacjaPomocniczaWPF.ValueConverters.Base;
using AplikacjaPomocniczaWPF.ViewModels;
using AplikacjaPomocniczaWPF.Views;
using AplikacjaPomocniczaWPF.Views.Autobus;
using AplikacjaPomocniczaWPF.Views.Firma;
using AplikacjaPomocniczaWPF.Views.Konfiguracja;
using AplikacjaPomocniczaWPF.Views.Linia;
using AplikacjaPomocniczaWPF.Views.Przejazdy;
using AplikacjaPomocniczaWPF.Views.Przystanek;
using AplikacjaPomocniczaWPF.Views.Trasa;
using AplikacjaPomocniczaWPF.Views.Zarzad;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplikacjaPomocniczaWPF.ValueConverters
{
    class PageTypeToUserControlValueConverter : BaseValueConverter<PageTypeToUserControlValueConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch((PageType) value)
            {
                case PageType.MainPage:
                    return new MainPage();
                case PageType.AutobusContainer:
                    return new AutobusContainer();
                case PageType.AutobusConstants:
                    return new AutobusConstants();
                case PageType.AutobusAcceleration:
                    return new AutobusAcceleraction();
                case PageType.PrzystanekContainer:
                    return new PrzystanekContainer();
                case PageType.PrzystanekConstants:
                    return new PrzystanekConstants();
                case PageType.PrzystanekThresholds:
                    return new PrzystanekThresholds();
                case PageType.TrasaContainer:
                    return new TrasaContainer();
                case PageType.TrasaData:
                    return new TrasaData();
                case PageType.LiniaContainer:
                    return new LiniaContainer();
                case PageType.LiniaData:
                    return new LiniaData();
                case PageType.FirmaContainer:
                    return new FirmaContainer();
                case PageType.FirmaData:
                    return new FirmaData();
                case PageType.PrzejazdyContainer:
                    return new PrzejazdyContainer();
                case PageType.PrzejazdyData:
                    return new PrzejazdyData();
                case PageType.ZarzadContainer:
                    return new ZarzadContainer();
                case PageType.ZarzadData:
                    return new ZarzadData();
                case PageType.KonfiguracjaContainer:
                    return new KonfiguracjaContainer();
                case PageType.KonfiguracjaConstants:
                    return new KonfiguracjaConstants();
                case PageType.KonfiguracjaZarzady:
                    return new KonfiguracjaZarzady();
                default:
                    return new MainPage();
            }
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
