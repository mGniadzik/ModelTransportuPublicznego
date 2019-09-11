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
    class ReverseColorToArgbValueConverter : BaseValueConverter<ReverseColorToArgbValueConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var color = (Color)value;
            color = Color.FromArgb(Math.Abs(color.R - 255), Math.Abs(color.G - 255), Math.Abs(color.B - 255));
            return ColorToStringHash.GetHashFromColor(color);
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
