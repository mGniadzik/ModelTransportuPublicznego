using ModelTransportuPublicznego.Implementacja.Autobusy;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace AplikacjaPomocnicza
{
    public partial class Form1 : Form
    {
        private List<Panel> panele;
        private AutobusLiniowy autobus;
        private string nazwaPliku;

        public Form1()
        {
            InitializeComponent();
            panele = new List<Panel>() { pPowitanie, pZmianaPrzyspieszenia, pAutobusStale };
            nazwaPliku = null;
        }

        private void bAutobus_Click(object sender, EventArgs e)
        {
            UstawPanelJakoWidoczny(pAutobusStale);
        }

        private void UstawPanelJakoWidoczny(Panel panel)
        {
            foreach (var p in panele)
            {
                if (p == panel)
                {
                    p.Visible = true;
                    continue;
                }

                p.Visible = false;
            }
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            UstawPanelJakoWidoczny(pPowitanie);
        }

        private void bNext_Click(object sender, EventArgs e)
        {
            if (nazwaPliku == null)
            {
                autobus = StworzAutobusZTB();
                UstawPanelJakoWidoczny(pZmianaPrzyspieszenia);
                return;
            }

            

            using (var sr = new StreamReader(nazwaPliku))
            {
                sr.ReadLine();
                DodajDaneDoDataGridView(dgPrzysp, sr.ReadLine());
                DodajDaneDoDataGridView(dgHamowanie, sr.ReadLine());
            }

            UstawPanelJakoWidoczny(pZmianaPrzyspieszenia);
        }

        private void bBack_Click(object sender, EventArgs e)
        {
            UstawPanelJakoWidoczny(pPowitanie);
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgPrzysp.Rows)
            {
                autobus.DodajProgWartoscSpowolnieniaPrzyspieszania(Convert.ToInt32(row.Cells["cProgPrzysp"].Value), Convert.ToInt32(row.Cells["cSpowolnieniePrzysp"].Value));
            }

            foreach (DataGridViewRow row in dgHamowanie.Rows)
            {
                autobus.DodajProgWartoscWydluzeniaHamowania(Convert.ToInt32(row.Cells["cProgHamowanie"].Value), Convert.ToInt32(row.Cells["cSpowolnienieHamowanie"].Value));
            }

            autobus.ZapiszDoPliku(tbNazwaPliku.Text);
            UstawPanelJakoWidoczny(pPowitanie);
            WyczyscDane();
        }

        private void bKonfiguracja_Click(object sender, EventArgs e)
        {
            var fd = new OpenFileDialog();
            if (fd.ShowDialog() == DialogResult.OK)
            {
                nazwaPliku = fd.FileName;
                using (var sr = new StreamReader(nazwaPliku))
                {
                    var stale = sr.ReadLine().Split('|');

                    if (stale.Length < 7)
                    {
                        MessageBox.Show("Niewłaściwy format pliku");
                        UstawPanelJakoWidoczny(pPowitanie);
                        return;
                    }

                    tbId.Text = stale[0];
                    tbPojemnosc.Text = stale[1];
                    tbDrzwi.Text = stale[2];
                    tbDlugosc.Text = stale[6];
                    tbPrzyspieszenie.Text = stale[3];
                    tbHamowanie.Text = stale[4];
                    tbVMax.Text = stale[5];

                    autobus = StworzAutobusZTB();
                    UstawPanelJakoWidoczny(pAutobusStale);
                }
            }
        }

        private void DodajDaneDoDataGridView(DataGridView dgv, string text)
        {
            var elementy = text.Split('|');

            foreach (var element in elementy)
            {
                var wartosci = element.Split('-');
                var dgr = (DataGridViewRow)dgv.Rows[0].Clone();
                dgr.Cells[0].Value = wartosci[0];
                dgr.Cells[1].Value = wartosci[1];

                dgv.Rows.Add(dgr);
            }
        }

        private void WyczyscDane()
        {
            dgPrzysp.Rows.Clear();
            dgHamowanie.Rows.Clear();
            tbId.Text = "";
            tbHamowanie.Text = "";
            tbDrzwi.Text = "";
            tbDlugosc.Text = "";
            tbPojemnosc.Text = "";
            tbPrzyspieszenie.Text = "";
            tbVMax.Text = "";
        }

        private AutobusLiniowy StworzAutobusZTB()
        {
            AutobusLiniowy autobus = null;
            try
            {
                autobus = new AutobusLiniowy(tbId.Text, Convert.ToInt32(tbPojemnosc.Text), Convert.ToInt32(tbDrzwi.Text), Convert.ToDouble(tbPrzyspieszenie.Text),
                Convert.ToDouble(tbHamowanie.Text), Convert.ToDouble(tbVMax.Text), Convert.ToDouble(tbDlugosc.Text));
            }
            catch (Exception exc)
            {
                MessageBox.Show(string.Format("Znaleziono wyjątek: {0}", exc));
            }

            return autobus;
        }
    }
}
