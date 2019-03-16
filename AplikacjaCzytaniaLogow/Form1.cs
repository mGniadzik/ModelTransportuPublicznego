using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace AplikacjaCzytaniaLogow
{
    public partial class Form1 : Form
    {
        private List<Linia> linie;

        public Form1()
        {
            InitializeComponent();
            linie = new List<Linia>();
            linieCB.DropDownStyle = ComboBoxStyle.DropDownList;
            dodajPrzejazdCB.DropDownStyle = ComboBoxStyle.DropDownList;
            usunPrzejazdCB.DropDownStyle = ComboBoxStyle.DropDownList;
            wykresP.Series.Clear();
        }

        private void buttonWybraniaLogow_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "Log files(*.log)|*.log"
            };
            ofd.ShowDialog();

            if (ofd.FileName != "")
            {
                linie = ZinterpretujZawartoscPliku(PrzeczytajPlik(ofd.FileName));
                WlaczPanelWykresu();
                ZapelnijLinie();
            }
        }

        private IEnumerable<string> PrzeczytajPlik(string plik)
        {
            var rezultat = new List<string>();
            var fs = new FileStream(plik, FileMode.Open, FileAccess.Read);
            using (var sr = new StreamReader(fs, Encoding.UTF8))
            {
                string text;
                while ((text = sr.ReadLine()) != null)
                {
                    rezultat.Add(text);
                }
            }
            fs.Close();

            return rezultat;
        }

        private List<Linia> ZinterpretujZawartoscPliku(IEnumerable<string> dane)
        {
            var rezultat = new List<Linia>();

            if (dane == null) throw new Exception("Plik nie został przeczytany.");

            foreach (var linia in dane)
            {
                var wynikI = ZinterpretujLinie(linia);
                int indexLinii;
                int indexPrzejazdu;
                
                if ((indexLinii = ZwrocIndexLinii(rezultat, wynikI.idLinii)) > -1)
                {
                    if ((indexPrzejazdu = rezultat[indexLinii].ZwrocIndexPrzejazdu(wynikI.idPrzejazdu)) > -1)
                    {
                        rezultat[indexLinii][indexPrzejazdu].DodajWpis(new WpisPrzejazdu(wynikI.przystanekS, wynikI.czasRozpoczecia), 
                            new WpisPrzejazdu(wynikI.przystanekK, wynikI.czasKoncowy));
                    }
                    else
                    {
                        rezultat[indexLinii].DodajPrzejazd(new Przejazd(wynikI.idPrzejazdu,
                        new WpisPrzejazdu(wynikI.przystanekS, wynikI.czasRozpoczecia), new WpisPrzejazdu(wynikI.przystanekK, wynikI.czasKoncowy)));
                    }
                }
                else
                {
                    rezultat.Add(new Linia(wynikI.idLinii, new List<Przejazd>() { new Przejazd(wynikI.idPrzejazdu,
                        new WpisPrzejazdu(wynikI.przystanekS, wynikI.czasRozpoczecia), new WpisPrzejazdu(wynikI.przystanekK, wynikI.czasKoncowy))}));
                }
            }

            return rezultat;
        }

        private WynikInterpretacji ZinterpretujLinie(string linia)
        {
            var rezultat = linia.Split('|');

            if (rezultat.Length != 7) throw new ArgumentException("Log nie posiada właściwego formatu danych.");
            return new WynikInterpretacji(rezultat[0], TimeSpan.Parse(rezultat[1]), rezultat[2], rezultat[3], rezultat[4], rezultat[5], TimeSpan.Parse(rezultat[6]));
        }

        private int ZwrocIndexLinii(List<Linia> linie, string idLinii)
        {
            for (int i = 0; i < linie.Count; i++)
            {
                if (linie[i].idLinii == idLinii) return i;
            }

            return -1;
        }

        private Linia ZwrocLinie(string idLinii)
        {
            foreach (var linia in linie)
                if (linia.idLinii == idLinii) return linia;
            return null;
        }

        private void ZapelnijLinie()
        {
            if (linie.Count > 0)
            {
                foreach (var linia in linie)
                {
                    linieCB.Items.Add(linia.idLinii);
                }

                linieCB.SelectedIndex = 0;
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            WlaczPanelPowitania();
            UsunWszystkiePrzejazdy();
            ZresetujDaneProgramu();
        }

        private void WlaczPanelPowitania()
        {
            panelWykresu.Visible = false;
            panelPowitania.Visible = true;
        }

        private void WlaczPanelWykresu()
        {
            panelPowitania.Visible = false;
            panelWykresu.Visible = true;
        }

        private void ZresetujDaneProgramu()
        {
            linie = new List<Linia>();
            linieCB.Items.Clear();
            dodajPrzejazdCB.Items.Clear();
            usunPrzejazdCB.Items.Clear();
        }

        private void UsunDaneZWykresu(string czas)
        {
            wykresP.Series.Remove(wykresP.Series.FindByName(czas));
        }

        private void UsunWszystkiePrzejazdy()
        {
            var idLinii = linieCB.SelectedItem.ToString();

            if (idLinii == "")
            {
                MessageBox.Show("Nie wybrano żadnej linii.");
                return;
            }

            var linia = ZwrocLinie(idLinii);
            foreach (var p in linia)
                UsunPrzejazd(p.ZwrocCzasZaczeciaPrzejazdu());
        }

        private void DodajWszystkiePrzejazdy()
        {
            var idLinii = linieCB.SelectedItem.ToString();

            if (idLinii == "")
            {
                MessageBox.Show("Nie wybrano żadnej linii.");
                return;
            }

            var linia = ZwrocLinie(idLinii);
            foreach (var p in linia)
            {
                DodajPrzejazd(p.ZwrocCzasZaczeciaPrzejazdu());
                // DodajPrzejazdDoWykresu(p.ZwrocCzasZaczeciaPrzejazdu());
            }
        }

        private void DodajPrzejazdDoWykresu(string czas)
        {
            var wybor = linieCB.SelectedItem.ToString();
            var przejazd = ZwrocLinie(wybor).ZwrocPrzejazdGodzina(czas);
            var series = wykresP.Series.FindByName(czas);

            var czasRozpoczecia = przejazd[0].czas;

            if (przejazd.Any)
                series.Points.AddXY(przejazd[0].przystanek, (przejazd[0].czas - czasRozpoczecia).Seconds);

            for (int i = 1; i < przejazd.Count; i += 2)
            {
                series.Points.AddXY(przejazd[i].przystanek, (przejazd[i].czas - czasRozpoczecia).Seconds);
            }
        }

        private void UsunPrzejazd(string czas)
        {
            UsunDaneZWykresu(czas);
            usunPrzejazdCB.Items.Remove(czas);
            if (usunPrzejazdCB.Items.Count == 1) usunPrzejazdCB.SelectedIndex = 0;
            dodajPrzejazdCB.Items.Add(czas);
            if (dodajPrzejazdCB.Items.Count == 1) dodajPrzejazdCB.SelectedIndex = 0;
        }

        private void DodajPrzejazd(string czas)
        {
            if (!wykresP.Series.Contains(wykresP.Series.FindByName(czas)))
                wykresP.Series.Add(czas);

            usunPrzejazdCB.Items.Add(czas);
            if (usunPrzejazdCB.Items.Count == 1) usunPrzejazdCB.SelectedIndex = 0;
            dodajPrzejazdCB.Items.Remove(czas);
            if (dodajPrzejazdCB.Items.Count == 1) dodajPrzejazdCB.SelectedIndex = 0;

            DodajPrzejazdDoWykresu(czas);
        }

        private void wybierzLinieB_Click(object sender, EventArgs e)
        {
            if (linieCB.SelectedItem == null) return;
            wykresP.Series.Clear();
            usunPrzejazdCB.Items.Clear();
            dodajPrzejazdCB.Items.Clear();
            var wybor = linieCB.SelectedItem.ToString();
            
            foreach (var przejazd in ZwrocLinie(wybor))
            {
                dodajPrzejazdCB.Items.Add(przejazd.ZwrocCzasZaczeciaPrzejazdu());
            }

            dodajPrzejazdCB.SelectedIndex = 0;
        }

        private void dodajPrzejazdB_Click(object sender, EventArgs e)
        {
            if (linieCB.SelectedItem == null) return;
            var idLinii = linieCB.SelectedItem.ToString();
            var przejazd = ZwrocLinie(idLinii).ZwrocPrzejazdGodzina(dodajPrzejazdCB.SelectedItem.ToString());
            var czas = przejazd.ZwrocCzasZaczeciaPrzejazdu();

            DodajPrzejazd(czas);
        }

        private void usunPrzejazdB_Click(object sender, EventArgs e)
        {
            if (usunPrzejazdCB.SelectedItem == null) return;
            var idLinii = linieCB.SelectedItem.ToString();
            var przejazd = ZwrocLinie(idLinii).ZwrocPrzejazdGodzina(usunPrzejazdCB.SelectedItem.ToString());
            var czas = przejazd.ZwrocCzasZaczeciaPrzejazdu();

            UsunPrzejazd(czas);
        }

        private void dodajWszystkiePrzejazdyB_Click(object sender, EventArgs e)
        {
            DodajWszystkiePrzejazdy();
        }

        private void usunWszystkiePrzejazdyB_Click(object sender, EventArgs e)
        {
            UsunWszystkiePrzejazdy();
        }
    }
}
