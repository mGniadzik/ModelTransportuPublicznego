using ModelTransportuPublicznego.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace ModelTransportuPublicznego.Misc
{
    class WizualizatorPrzejazdowLinii
    {
        private static WizualizatorPrzejazdowLinii instancja;
        private List<Linia> linie;

        private WizualizatorPrzejazdowLinii(IEnumerable<Linia> linie)
        {
            foreach (var linia in linie)
            {
                this.linie.Add(linia);
            }
        }

        public static WizualizatorPrzejazdowLinii Instancja(IEnumerable<Linia> linie)
        {
            if (instancja == null)
            {
                instancja = new WizualizatorPrzejazdowLinii(linie);
            }

            return Instancja();
        }

        public static WizualizatorPrzejazdowLinii Instancja()
        {
            return instancja;
        }

        public void NarysujWykres()
        {
            Chart chart = new Chart();
            chart.Series.Clear();
            Series series;

            foreach (var linia in linie)
            {
                series = new Series
                {
                    Name = linia.IdLinii,
                    Color = System.Drawing.Color.Green,
                    ChartType = SeriesChartType.Column
                };

                chart.Series.Add(series);
                foreach (var wpis in linia.WpisyStatusuLinii)
                {
                }
            }
        }
    }
}
