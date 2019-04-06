using ModelTransportuPublicznego.Implementacja.Autobusy;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using ModelTransportuPublicznego.Model.Przystanek;
using System.Linq;

namespace AplikacjaPomocnicza
{
    public partial class Form1 : Form
    {
        private readonly List<Panel> panele;
        private AutobusLiniowy autobus;
        private Przystanek przystanek;
        private string nazwaPliku;

        public Form1()
        {
            InitializeComponent();
            panele = new List<Panel>() { pPowitanie, pZmianaPrzyspieszenia, pAutobusStale, pPrzystanekStale, pPrzystanekProgi };
            nazwaPliku = null;
        }

        private void BAutobus_Click(object sender, EventArgs e)
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

        private void BCancel_Click(object sender, EventArgs e)
        {
            UstawPanelJakoWidoczny(pPowitanie);
        }

        private void BNext_Click(object sender, EventArgs e)
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
                DodajDaneDoDataGridView(dgPrzysp, sr.ReadLine(), '|', '-');
                DodajDaneDoDataGridView(dgHamowanie, sr.ReadLine(), '|', '-');
            }

            UstawPanelJakoWidoczny(pZmianaPrzyspieszenia);
        }

        private void BBack_Click(object sender, EventArgs e)
        {
            UstawPanelJakoWidoczny(pPowitanie);
        }

        private void BSave_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgPrzysp.Rows)
            {
                autobus.DodajProgWartoscSpowolnieniaPrzyspieszania(Convert.ToInt32(row.Cells["cProgPrzysp"].Value), Convert.ToInt32(row.Cells["cSpowolnieniePrzysp"].Value));
            }

            foreach (DataGridViewRow row in dgHamowanie.Rows)
            {
                autobus.DodajProgWartoscWydluzeniaHamowania(Convert.ToInt32(row.Cells["cProgHamowanie"].Value), Convert.ToInt32(row.Cells["cSpowolnienieHamowanie"].Value));
            }

            Stream stream;
            var dialog = new SaveFileDialog
            {
                Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*",
                DefaultExt = "txt"
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                if ((stream = dialog.OpenFile()) != null)
                {
                    using (var sw = new StreamWriter(stream))
                    {
                        autobus.Zapisz(sw);
                    }
                    stream.Close();
                }
            }

            UstawPanelJakoWidoczny(pPowitanie);
            WyczyscDaneAutobusu();
        }

        private void BKonfiguracja_Click(object sender, EventArgs e)
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

        private void DodajDaneDoDataGridView(DataGridView dgv, string text, char split1, char split2, Func<string, string> func = null)
        {
            var elementy = text.Split(split1);

            foreach (var element in elementy)
            {
                var wartosci = element.Split(split2);
                var dgr = (DataGridViewRow)dgv.Rows[0].Clone();
                dgr.Cells[0].Value = wartosci[0];
                if (func == null)
                {
                    dgr.Cells[1].Value = wartosci[1];
                }
                else
                {
                    dgr.Cells[1].Value = func(wartosci[1]);
                }

                dgv.Rows.Add(dgr);
            }
        }

        private void WyczyscDaneAutobusu()
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

        private void WyczyscDanePrzystanku()
        {
            dgProgiPrzystanekPasazerowie.Rows.Clear();
            dgProgiPrzystanekAutobusy.Rows.Clear();
            tbNazwaPrzystanku.Text = "";
            tbPosX.Text = "";
            tbPosY.Text = "";
            tbDlugoscZatoki.Text = "";
            tbPojemnoscPasazerow.Text = "";
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

        private void BPrzystanek_Click(object sender, EventArgs e)
        {
            UstawPanelJakoWidoczny(pPrzystanekStale);
        }

        private void BMenuPrzystanek_Click(object sender, EventArgs e)
        {
            WyczyscDanePrzystanku();
            UstawPanelJakoWidoczny(pPowitanie);
        }

        private void BNextPrzystanek_Click(object sender, EventArgs e)
        {
            przystanek = new Przystanek(tbNazwaPrzystanku.Text, null, Convert.ToDouble(tbDlugoscZatoki.Text), 
                Convert.ToInt32(tbPosX.Text), Convert.ToInt32(tbPosY.Text), Convert.ToInt32(tbPojemnoscPasazerow.Text));
            UstawPanelJakoWidoczny(pPrzystanekProgi);
        }

        private void DgProgiPrzystanek_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            UstawKolorDataGrid(dgProgiPrzystanekPasazerowie, e);
        }

        private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            UstawKolorDataGrid(dgProgiPrzystanekAutobusy, e);
        }

        private void UstawKolorDataGrid(DataGridView dg, DataGridViewCellEventArgs e)
        {
            if (dg.CurrentCell.ColumnIndex == 1 && e.RowIndex != -1)
            {
                var dialog = new ColorDialog();

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    var cell = dg.Rows[e.RowIndex].Cells[1];
                    UstawKomorke(cell, dialog.Color);
                }
            }
        }

        private void BZapiszDoPliku_Click(object sender, EventArgs e)
        {
            UstawKolory(dgProgiPrzystanekPasazerowie);
            UstawKolory(dgProgiPrzystanekAutobusy);

            foreach (DataGridViewRow row in dgProgiPrzystanekPasazerowie.Rows)
            {
                if (row.Cells[1].Value == null)
                {
                    continue;
                }

                var kolor = row.Cells[1].Value.ToString().Split(',').Select(s => Convert.ToInt32(s)).ToArray();
                przystanek.DodajProgKolorZapelnieniaPasazerow(Convert.ToInt32(row.Cells[0].Value), Color.FromArgb(kolor[0], kolor[1], kolor[2]));
            }

            foreach (DataGridViewRow row in dgProgiPrzystanekAutobusy.Rows)
            {
                if (row.Cells[1].Value == null)
                {
                    continue;
                }

                var kolor = row.Cells[1].Value.ToString().Split(',').Select(s => Convert.ToInt32(s)).ToArray();
                przystanek.DodajProgKolorZapelnieniaAutobusow(Convert.ToInt32(row.Cells[0].Value), Color.FromArgb(kolor[0], kolor[1], kolor[2]));
            }

            var dialog = new SaveFileDialog();
            Stream stream;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                if ((stream = dialog.OpenFile()) != null)
                {
                    using (var sw = new StreamWriter(stream))
                    {
                        przystanek.Zapisz(sw);
                    }
                    stream.Close();
                }
            }

            UstawPanelJakoWidoczny(pPowitanie);
        }

        private void BKonfiguracjaPrzystanku_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var filePath = dialog.FileName;
                var stream = dialog.OpenFile();
                string[] stale;
                string progiPasazerow, progiAutobusow;

                using (var sr = new StreamReader(stream))
                {
                    stale = sr.ReadLine().Split('|');
                    progiPasazerow = sr.ReadLine();
                    progiAutobusow = sr.ReadLine();
                }

                tbNazwaPrzystanku.Text = stale[3];
                tbPosX.Text = stale[0];
                tbPosY.Text = stale[1];
                tbDlugoscZatoki.Text = stale[4];
                tbPojemnoscPasazerow.Text = stale[2];

                DodajDaneDoDataGridView(dgProgiPrzystanekPasazerowie, progiPasazerow, '|', ':', ZamienArgbNaRGB);
                DodajDaneDoDataGridView(dgProgiPrzystanekAutobusy, progiAutobusow, '|', ':', ZamienArgbNaRGB);
                UstawKolory(dgProgiPrzystanekPasazerowie);
                UstawKolory(dgProgiPrzystanekAutobusy);
                UstawPanelJakoWidoczny(pPrzystanekStale);
            }
        }

        private string ZamienArgbNaRGB(string argb)
        {
            Color color = Color.FromArgb(Convert.ToInt32(argb));
            return string.Format("{0},{1},{2}", color.R, color.G, color.B);
        }

        private void DgProgiPrzystanekPasazerowie_KeyUp(object sender, KeyEventArgs e)
        {
            if (CzyWcisnietoKlawiszZmianyPola(e.KeyCode))
            {
                UstawKolory(dgProgiPrzystanekPasazerowie);
            }
        }

        private bool CzyWcisnietoKlawiszZmianyPola(Keys key)
        {
            return key == Keys.Enter || key == Keys.Tab || key == Keys.Up || key == Keys.Left || key == Keys.Right || key == Keys.Down;
        }

        private void UstawKolory(DataGridView dg)
        {
            foreach (DataGridViewRow row in dg.Rows)
            {
                UstawKolor(row.Cells[1]);
            }
        }

        private void UstawKolor(DataGridViewCell cell)
        {
            if (cell.Value == null)
            {
                return;
            }

            string[] dane = cell.Value.ToString().Split(',');

            if (!DaneSaPoprawne(dane))
            {
                MessageBox.Show(string.Format("Niewłaściwe dane w komórce {0}, {1} kolor został zmieniony na biały!", cell.RowIndex, cell.ColumnIndex));
                UstawKomorke(cell, Color.White);
                return;
            }

            UstawKomorke(cell, Color.FromArgb(Convert.ToInt32(dane[0]), Convert.ToInt32(dane[1]), Convert.ToInt32(dane[2])));
        }

        private bool DaneSaPoprawne(string[] dane)
        {
            if (dane.Length != 3)
            {
                return false;
            }

            foreach (var d in dane)
            {
                var val = Convert.ToInt32(d);
                if (val < 0 || val > 255)
                {
                    return false;
                }
            }

            return true;
        }

        private void UstawKomorke(DataGridViewCell cell, Color color)
        {
            cell.Value = string.Format("{0},{1},{2}", color.R, color.G, color.B);
            cell.Style.BackColor = color;
        }

        private void DgProgiPrzystanekAutobusy_KeyUp(object sender, KeyEventArgs e)
        {
            if (CzyWcisnietoKlawiszZmianyPola(e.KeyCode))
            {
                UstawKolory(dgProgiPrzystanekPasazerowie);
            }
        }

        private void DgProgiPrzystanekAutobusy_MouseClick(object sender, MouseEventArgs e)
        {
            UstawKolory(dgProgiPrzystanekPasazerowie);
            UstawKolory(dgProgiPrzystanekAutobusy);
        }

        private void DgProgiPrzystanekPasazerowie_MouseClick(object sender, MouseEventArgs e)
        {
            UstawKolory(dgProgiPrzystanekPasazerowie);
            UstawKolory(dgProgiPrzystanekAutobusy);
        }

        private void BBackMenu_Click(object sender, EventArgs e)
        {
            WyczyscDanePrzystanku();
            UstawPanelJakoWidoczny(pPowitanie);
        }
    }
}
