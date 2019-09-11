using AplikacjaPomocniczaWPF.Helpers;
using AplikacjaPomocniczaWPF.ValueConverters.Base;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplikacjaPomocniczaWPF.ValueConverters
{
    class ColorToArgbValueConverter : BaseValueConverter<ColorToArgbValueConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ColorToStringHash.GetHashFromColor((Color)value);
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
