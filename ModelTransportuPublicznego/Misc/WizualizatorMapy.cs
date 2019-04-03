using ModelTransportuPublicznego.Model;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace ModelTransportuPublicznego.Misc
{
    static class WizualizatorMapy
    {
        public static void NarysujMape(string nazwaMapy, IEnumerable<Przystanek> siecPrzystankow, IEnumerable<Linia> linie, int width = 640, int height = 640)
        {
            var bmp = new Bitmap(width, height);
            int promien = 10;
            using (Graphics grph = Graphics.FromImage(bmp))
            {
                foreach (var p in siecPrzystankow)
                {
                    double procent = p.IloscPasazerowOczekujacych() / (double) p.MaksymalnaPojemnoscPasazerow;
                    if (procent > 1) procent = 1;
                    var color = Color.FromArgb((int)(255 * procent), (int)(128 - 128 * procent), 0);
                    grph.DrawString(p.NazwaPrzystanku, new Font("Arial", 12), new SolidBrush(color), p.X, p.Y + 15);
                    grph.FillEllipse(new SolidBrush(color), p.X - promien, p.Y - promien, promien + promien, promien + promien);
                }

                foreach (var l in linie)
                {
                    for (int i = 0; i < l.Count - 1; i++)
                    {
                        grph.DrawLine(new Pen(Color.Red), l[i].przystanek.X, l[i].przystanek.Y, l[i + 1].przystanek.X, l[i + 1].przystanek.Y);
                    }
                }
            }

            if (!Directory.Exists("Mapy"))
            {
                Directory.CreateDirectory("Mapy");
            }

            bmp.Save(string.Format("Mapy/{0}.png", nazwaMapy));
        }
    }
}
