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
    class ColorToStringValueConverter : BaseValueConverter<ColorToStringValueConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var color = (Color)value;

            return "[" + color.R.ToString() + "," + color.G.ToString() + "," + color.B.ToString() + "]"; 
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var colorAsString = (string)value;
            colorAsString = colorAsString.Substring(1, colorAsString.Length - 2);
            var colors = colorAsString.Split(',');


            return Color.FromArgb(System.Convert.ToInt32(colors[0]), System.Convert.ToInt32(colors[1]), System.Convert.ToInt32(colors[2]));
        }
    }
}
