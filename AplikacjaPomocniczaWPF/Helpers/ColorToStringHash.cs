using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplikacjaPomocniczaWPF.Helpers
{
    public static class ColorToStringHash
    {
        public static string GetHashFromColor(Color color)
        {
            string r = color.R.ToString("X");
            string g = color.G.ToString("X");
            string b = color.B.ToString("X");

            if (r.Length == 1) r = "0" + r;
            if (g.Length == 1) g = "0" + g;
            if (b.Length == 1) b = "0" + b;

            return "#" + r + g + b;
        }
    }
}
