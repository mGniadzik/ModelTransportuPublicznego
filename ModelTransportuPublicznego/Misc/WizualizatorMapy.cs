using ModelTransportuPublicznego.Model;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using ModelTransportuPublicznego.Model.Przystanek;

namespace ModelTransportuPublicznego.Misc
{
    class WizualizatorMapy
    {
        private Image tlo;
        private int szerokosc;
        private int wysokosc;
        private static WizualizatorMapy wizualizatorMapy = null;
        private WizualizatorMapy(string plikTla, int szerokosc, int wysokosc)
        {
            tlo = Image.FromFile(plikTla);
            this.szerokosc = szerokosc;
            this.wysokosc = wysokosc;
        }

        public static WizualizatorMapy Instancja(string plikTla, int szerokosc, int wysokosc)
        {
            if (wizualizatorMapy == null)
            {
                wizualizatorMapy = new WizualizatorMapy(plikTla, szerokosc, wysokosc);
            }

            return wizualizatorMapy;
        }

        public static WizualizatorMapy Instancja()
        {
            return wizualizatorMapy;
        }

        public void NarysujMape(string nazwaMapy, IEnumerable<Przystanek> siecPrzystankow, IEnumerable<Linia> linie, int promienWewnetrzny = 10, int promienZewnetrzny = 20)
        {
            var bmp = new Bitmap(szerokosc, wysokosc);
            using (Graphics grph = Graphics.FromImage(bmp))
            {
                grph.DrawImage(tlo, 0, 0, szerokosc, wysokosc);
                grph.SmoothingMode = SmoothingMode.AntiAlias;

                foreach (var p in siecPrzystankow)
                {
                    grph.DrawString(p.NazwaPrzystanku, new Font("Arial", 12), new SolidBrush(p.KolorZapelnieniaPasazerow), p.X, p.Y + 15);
                    grph.FillEllipse(new SolidBrush(p.KolorZapelnieniaAutobusow), p.X - promienZewnetrzny, p.Y - promienZewnetrzny, promienZewnetrzny + promienZewnetrzny, promienZewnetrzny + promienZewnetrzny);
                    grph.FillEllipse(new SolidBrush(p.KolorZapelnieniaPasazerow), p.X - promienWewnetrzny, p.Y - promienWewnetrzny, promienWewnetrzny + promienWewnetrzny, promienWewnetrzny + promienWewnetrzny);
                }

                foreach (var l in linie)
                {
                    for (int i = 0; i < l.Count - 1; i++)
                    {
                        grph.DrawLines(new Pen(Color.Black), l[i].ZwrocPunktyWpisu());
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
