using ModelTransportuPublicznego.Implementacja.Autobusy;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using ModelTransportuPublicznego.Model.Przystanek;
using System.Linq;
using ModelTransportuPublicznego.Model;
using ModelTransportuPublicznego.Model.Firma;
using ModelTransportuPublicznego.Implementacja.Firmy;
using ModelTransportuPublicznego.Implementacja;

namespace AplikacjaPomocnicza
{
    public partial class AplikacjaPomocnicza : Form
    {
        private readonly List<Panel> panele;
        private AutobusLiniowy autobus;
        private Przystanek przystanek;
        private string nazwaPliku;

        public AplikacjaPomocnicza()
        {
            InitializeComponent();
            panele = new List<Panel>() { pPowitanie, pZmianaPrzyspieszenia, pAutobusStale, pPrzystanekStale, pPrzystanekProgi, pPrzejazdy,
                pPrzejazdyUstawianie, pAutobus, pPrzystanek, pFirma, pFirmaStaleLinie, pFirmaTabor, pLinia, pLiniaDane, pZarzadTransportu,
                pZarzadDanePrzystanki, pZarzadLinieFirmy };
            nazwaPliku = null;
        }

        private void BAutobus_Click(object sender, EventArgs e)
        {
            UstawPaneleJakoWidoczne(pAutobus, pAutobusStale);
        }

        private void UstawPaneleJakoWidoczne(params Panel[] tmp)
        {
            foreach (var p in panele)
            {
                if (tmp.Contains(p))
                {
                    p.Visible = true;
                    continue;
                }

                p.Visible = false;
            }
        }

        private void BCancel_Click(object sender, EventArgs e)
        {
            WyczyscDaneAutobusu();
            UstawPaneleJakoWidoczne(pPowitanie);
        }

        private void BNext_Click(object sender, EventArgs e)
        {
            if (nazwaPliku == null)
            {
                autobus = StworzAutobusZTB();
                UstawPaneleJakoWidoczne(pAutobus, pZmianaPrzyspieszenia);
                var tmp = (ToolStripMenuItem)msAutobus.Items[0];
                tmp.DropDownItems[1].Enabled = true;
                return;
            }

            using (var sr = new StreamReader(nazwaPliku))
            {
                sr.ReadLine();
                DodajDaneDoDataGridView(dgPrzysp, sr.ReadLine(), '|', '-');
                DodajDaneDoDataGridView(dgHamowanie, sr.ReadLine(), '|', '-');
            }

            UstawPaneleJakoWidoczne(pAutobus, pZmianaPrzyspieszenia);
        }

        private void BBack_Click(object sender, EventArgs e)
        {
            WyczyscDaneAutobusu();
            UstawPaneleJakoWidoczne(pPowitanie);
        }

        private void BSave_Click(object sender, EventArgs e)
        {
            DodajProgiDoAutobusu(autobus);
            ZapiszAutobusDoPlikuOpenFileDialog();
        }

        private void ZapiszAutobusDoPlikuOpenFileDialog()
        {
            DodajProgiDoAutobusu(autobus);

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

            UstawPaneleJakoWidoczne(pPowitanie);
            WyczyscDaneAutobusu();
        }

        private void ZapiszPrzystanekDoPlikuOpenDialog()
        {
            UstawKolory(dgProgiPrzystanekPasazerowie);
            UstawKolory(dgProgiPrzystanekAutobusy);
            ZamienDGVRowsNaDane(dgProgiPrzystanekPasazerowie.Rows, dgProgiPrzystanekAutobusy.Rows, przystanek);

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

            UstawPaneleJakoWidoczne(pPowitanie);
            UstawAtrybutyEnabledMenuStripItem(msPrzystanek.Items[0], false);
        }

        private void DodajProgiDoAutobusu(AutobusLiniowy autobus)
        {
            autobus.WyczyscProgiSpowolnienia();

            foreach (DataGridViewRow row in dgPrzysp.Rows)
            {
                autobus.DodajProgWartoscSpowolnieniaPrzyspieszania(Convert.ToInt32(row.Cells["cProgPrzysp"].Value), Convert.ToInt32(row.Cells["cSpowolnieniePrzysp"].Value));
            }

            foreach (DataGridViewRow row in dgHamowanie.Rows)
            {
                autobus.DodajProgWartoscWydluzeniaHamowania(Convert.ToInt32(row.Cells["cProgHamowanie"].Value), Convert.ToInt32(row.Cells["cSpowolnienieHamowanie"].Value));
            }
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
                        UstawPaneleJakoWidoczne(pPowitanie);
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
                    UstawPaneleJakoWidoczne(pAutobusStale);
                }
            }
        }

        private void DodajDaneDoDataGridView(DataGridView dgv, string text, char split1, char split2, Func<string, string> func = null)
        {
            var elementy = text.Split(split1);

            foreach (var element in elementy)
            {
                var wartosci = element.Split(split2);

                if (wartosci.Length != 2)
                {
                    MessageBox.Show("Podany plik posiada dane w złym formacie.");
                    UstawPaneleJakoWidoczne(pPowitanie);
                    WyczyscDaneAutobusu();
                }

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
            UstawPaneleJakoWidoczne(pPrzystanek, pPrzystanekStale);
        }

        private void BMenuPrzystanek_Click(object sender, EventArgs e)
        {
            WyczyscDanePrzystanku();
            UstawPaneleJakoWidoczne(pPowitanie);
        }

        private void BNextPrzystanek_Click(object sender, EventArgs e)
        {
            przystanek = new Przystanek(tbNazwaPrzystanku.Text, null, Convert.ToDouble(tbDlugoscZatoki.Text), 
                Convert.ToInt32(tbPosX.Text), Convert.ToInt32(tbPosY.Text), Convert.ToInt32(tbPojemnoscPasazerow.Text));
            UstawPaneleJakoWidoczne(pPrzystanek, pPrzystanekProgi);
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
            ZamienDGVRowsNaDane(dgProgiPrzystanekPasazerowie.Rows, dgProgiPrzystanekAutobusy.Rows, przystanek);

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

            UstawPaneleJakoWidoczne(pPowitanie);
        }

        private void ZamienDGVRowsNaDane(DataGridViewRowCollection pasazerRows, DataGridViewRowCollection autobusRows, Przystanek przystanek)
        {
            przystanek.ZresetujProgi();

            foreach (DataGridViewRow row in pasazerRows)
            {
                if (row.Cells[1].Value == null)
                {
                    continue;
                }

                var kolor = row.Cells[1].Value.ToString().Split(',').Select(s => Convert.ToInt32(s)).ToArray();
                przystanek.DodajProgKolorZapelnieniaPasazerow(Convert.ToInt32(row.Cells[0].Value), Color.FromArgb(kolor[0], kolor[1], kolor[2]));
            }

            foreach (DataGridViewRow row in autobusRows)
            {
                if (row.Cells[1].Value == null)
                {
                    continue;
                }

                var kolor = row.Cells[1].Value.ToString().Split(',').Select(s => Convert.ToInt32(s)).ToArray();
                przystanek.DodajProgKolorZapelnieniaAutobusow(Convert.ToInt32(row.Cells[0].Value), Color.FromArgb(kolor[0], kolor[1], kolor[2]));
            }
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
                UstawPaneleJakoWidoczne(pPrzystanekStale);
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
            UstawPaneleJakoWidoczne(pPowitanie);
        }

        private void BPrzejazdy_Click(object sender, EventArgs e)
        {
            UstawPaneleJakoWidoczne(pPrzejazdy, pPrzejazdyUstawianie);
        }

        private void MsAutobusWczytaj_Click(object sender, EventArgs e)
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
                }

                UstawAtrybutyEnabledMenuStripItem(msAutobus.Items[0], true);
            }
        }

        private void UstawAtrybutyEnabledMenuStripItem(ToolStripItem item, bool wartosc)
        {
            var smth = (ToolStripMenuItem) item;
            smth.DropDownItems[0].Enabled = wartosc;
            smth.DropDownItems[1].Enabled = wartosc;
        }

        private void MsAutobusZapisz_Click(object sender, EventArgs e)
        {
            autobus = StworzAutobusZTB();
            DodajProgiDoAutobusu(autobus);

            using (var sw = File.CreateText(nazwaPliku))
            {
                autobus.Zapisz(sw);
            }

            UstawAtrybutyEnabledMenuStripItem(msAutobus.Items[0], false);
            WyczyscDaneAutobusu();
            UstawPaneleJakoWidoczne(pPowitanie);
        }

        private void MsAutobusZapiszJako_Click(object sender, EventArgs e)
        {
            autobus = StworzAutobusZTB();
            DodajProgiDoAutobusu(autobus);
            ZapiszAutobusDoPlikuOpenFileDialog();
            UstawAtrybutyEnabledMenuStripItem(msAutobus.Items[0], false);
            WyczyscDaneAutobusu();
        }

        private void WczytajToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                nazwaPliku = dialog.FileName;
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
                StworzPrzystanekZTB();
                ZamienDGVRowsNaDane(dgProgiPrzystanekPasazerowie.Rows, dgProgiPrzystanekAutobusy.Rows, przystanek);
                UstawAtrybutyEnabledMenuStripItem(msPrzystanek.Items[0], true);
            }
        }

        private void MsPrzystanekZapiszJako_Click(object sender, EventArgs e)
        {
            ZapiszPrzystanekDoPlikuOpenDialog();
            WyczyscDanePrzystanku();
        }

        private void StworzPrzystanekZTB()
        {
            przystanek = new Przystanek(tbNazwaPrzystanku.Text, null, Convert.ToDouble(tbDlugoscZatoki.Text),
                Convert.ToInt32(tbPosX.Text), Convert.ToInt32(tbPosY.Text), Convert.ToInt32(tbPojemnoscPasazerow.Text));
        }

        private void MsPrzystanekZapisz_Click(object sender, EventArgs e)
        {
            StworzPrzystanekZTB();
            ZamienDGVRowsNaDane(dgProgiPrzystanekPasazerowie.Rows, dgProgiPrzystanekAutobusy.Rows, przystanek);

            using (var sw = File.CreateText(nazwaPliku))
            {
                przystanek.Zapisz(sw);
            }

            UstawAtrybutyEnabledMenuStripItem(msPrzystanek.Items[0], false);
            WyczyscDanePrzystanku();
            UstawPaneleJakoWidoczne(pPowitanie);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            UstawPaneleJakoWidoczne(pFirma, pFirmaTabor);
        }

        private void BFirma_Click(object sender, EventArgs e)
        {
            UstawPaneleJakoWidoczne(pFirma, pFirmaStaleLinie);
        }

        private void BLinia_Click(object sender, EventArgs e)
        {
            UstawPaneleJakoWidoczne(pLinia, pLiniaDane);
        }

        private void BPrzejazdDalej_Click(object sender, EventArgs e)
        {
            UstawPaneleJakoWidoczne(pPrzejazdy, pPrzejazdyUstawianie);
        }

        private void DgLiniaDane_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                var dialog = new OpenFileDialog();

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    nazwaPliku = dialog.FileName;
                    dgLiniaDane.Rows[e.RowIndex].Cells[1].Value = dialog.FileName;
                    using (var sr = File.OpenText(dialog.FileName))
                    {
                        dgLiniaDane.Rows[e.RowIndex].Cells[0].Value = sr.ReadLine();
                    }
                }
            }
        }

        private IEnumerable<DataGridViewRow> RzedyBezNazwy(DataGridView dgv)
        {
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.Cells[0].Value == null && row.Cells[1].Value != null)
                {
                    yield return row;
                }
            }
        }

        private void DgLiniaDane_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    foreach (var row in RzedyBezNazwy(dgLiniaDane))
                    {
                        using (var sr = File.OpenText(row.Cells[1].Value.ToString()))
                        {
                            row.Cells[0].Value = sr.ReadLine();
                        }
                    }
                }
                catch (Exception exc)
                {
                    Console.WriteLine(exc);
                    var rzedyDoUsuniecia = new List<DataGridViewRow>();

                    foreach (var row in RzedyBezNazwy(dgLiniaDane))
                    {
                        rzedyDoUsuniecia.Add(row);
                    }

                    foreach (var row in rzedyDoUsuniecia)
                    {
                        dgLiniaDane.Rows.Remove(row);
                    }
                }
            }
        }

        private Linia StworzLinieZInputow()
        {
            var wpisyLinii = new List<WpisLinii>();

            foreach (DataGridViewRow row in dgLiniaDane.Rows)
            {
                var czas = row.Cells[2].Value.ToString().Split(':');
                wpisyLinii.Add(new WpisLinii(Przystanek.OdczytajPlik(row.Cells[1].Value.ToString(), null), new TimeSpan(Convert.ToInt32(czas[0]), Convert.ToInt32(czas[1]), Convert.ToInt32(czas[2]))));
            }

            return new Linia(tbLiniaId.Text, nazwaPliku, wpisyLinii);
        }

        private void MsLiniaPlikZapisz_Click(object sender, EventArgs e)
        {
            using (var sw = File.CreateText(nazwaPliku))
            {
                StworzLinieZInputow().Zapisz(sw);
            }
        }

        private void MsLiniaPlikZapiszJako_Click(object sender, EventArgs e)
        {
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
                        StworzLinieZInputow().Zapisz(sw);
                    }
                    stream.Close();
                }
            }
        }

        private void MsLiniaPlikWczytaj_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                nazwaPliku = dialog.FileName;
                var linia = Linia.OdczytajPlik(dialog.FileName, null);

                tbLiniaId.Text = linia.IdLinii;

                foreach (var wpis in linia.Wpisy)
                {
                    var row = (DataGridViewRow)dgLiniaDane.Rows[0].Clone();
                    row.Cells[1].Value = wpis.przystanek.SciezkaPlikuKonfiguracyjnego;
                    row.Cells[2].Value = wpis.czasPrzyjaduDoPrzystanku;

                    using (var sr = File.OpenText(wpis.przystanek.SciezkaPlikuKonfiguracyjnego))
                    {
                        row.Cells[0].Value = sr.ReadLine();
                    }

                    dgLiniaDane.Rows.Add(row);
                }
            }
        }

        private void DgFirmaLinia_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                var dialog = new OpenFileDialog();
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    using (var sr = File.OpenText(dialog.FileName))
                    {
                        dgFirmaLinia.Rows[e.RowIndex].Cells[0].Value = sr.ReadLine();
                    }
                    dgFirmaLinia.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = dialog.FileName;
                }
            }
        }

        private void DgFirmaTabor_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                var dialog = new OpenFileDialog();

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    dgFirmaTabor.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = dialog.FileName;
                }
            }
        }

        private Firma StworzFirmeZInputow()
        {
            var tabor = new SortedDictionary<Autobus, int>();
            var kierowcy = new List<Kierowca>();
            var linie = new List<Linia>();

            foreach (DataGridViewRow row in dgFirmaTabor.Rows)
            {
                tabor.Add(AutobusLiniowy.OdczytajPlik(row.Cells[0].Value.ToString()), Convert.ToInt32(row.Cells[1].Value));
            }

            foreach (DataGridViewRow row in dgFirmaLinia.Rows)
            {
                linie.Add(Linia.OdczytajPlik(row.Cells[1].Value.ToString(), null));
            }

            for (int i = 0; i < Convert.ToInt32(tbFirmaKierowcy.Text); i++)
            {
                kierowcy.Add(new Kierowca());
            }

            return new FirmaLosowa(tbFirmaNazwa.Text, tabor, nazwaPliku, kierowcy, linie);
        }

        private void MsFirmaPlikZapisz_Click(object sender, EventArgs e)
        {
            using (var sw = File.CreateText(nazwaPliku))
            {
                StworzFirmeZInputow().Zapisz(sw);
            }
        }

        private void MsFirmaPlikZapiszJako_Click(object sender, EventArgs e)
        {
            Stream stream;
            var dialog = new SaveFileDialog();

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                if ((stream = dialog.OpenFile()) != null)
                {
                    using (var sw = new StreamWriter(stream))
                    {
                        StworzFirmeZInputow().Zapisz(sw);
                    }
                    stream.Close();
                }
            }
        }

        private void MsFirmaPlikWczytaj_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                using (var sr = File.OpenText(dialog.FileName))
                {
                    var firma = FirmaLosowa.OdczytajPlik(dialog.FileName, null);
                    tbFirmaNazwa.Text = firma.NazwaFirmy;
                    tbFirmaKierowcy.Text = firma.ZwrocKierowcow().Count().ToString();

                    foreach (var linia in firma.LinieAutobusowe)
                    {
                        var row = (DataGridViewRow)dgFirmaLinia.Rows[0].Clone();
                        row.Cells[0].Value = linia.IdLinii;
                        row.Cells[1].Value = linia.SciezkaPlikuKonfiguracyjnego;

                        dgFirmaLinia.Rows.Add(row);
                    }

                    foreach (var kvp in firma.Tabor)
                    {
                        var row = (DataGridViewRow)dgFirmaTabor.Rows[0].Clone();
                        row.Cells[0].Value = kvp.Key.SciezkaPlikuKonfiguracyjnego;
                        row.Cells[1].Value = kvp.Value;
                    }
                }
            }
        }

        private void DgPrzejazdy_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1 || e.ColumnIndex == 2 || e.ColumnIndex == 3)
            {
                OtworzPlikDoOdczytu((dialog) =>
                {
                    dgPrzejazdy.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = dialog.FileName;
                });
            }
        }

        private void OtworzPlikDoOdczytu(Action<OpenFileDialog> action)
        {
            var dialog = new OpenFileDialog();

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                action(dialog);
            }
        }

        private void OtworzPlikDoZapisu(Action<SaveFileDialog> action)
        {
            var dialog = new SaveFileDialog();

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                action(dialog);
            }
        }

        private void BZarzad_Click(object sender, EventArgs e)
        {
            UstawPaneleJakoWidoczne(pZarzadTransportu, pZarzadDanePrzystanki);
        }

        private void DgZarzadPrzystanki_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                OtworzPlikDoOdczytu((dialog) =>
                {
                    dgZarzadPrzystanki.Rows[e.RowIndex].Cells[1].Value = dialog.FileName;

                    using (var sr = File.OpenText(dialog.FileName))
                    {
                        dgZarzadPrzystanki.Rows[e.RowIndex].Cells[0].Value = sr.ReadLine();
                    }
                });
            }
        }

        private void DgZarzadLinie_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                OtworzPlikDoOdczytu((dialog) =>
                {
                    dgZarzadLinie.Rows[e.RowIndex].Cells[1].Value = dialog.FileName;

                    using (var sr = File.OpenText(dialog.FileName))
                    {
                        dgZarzadLinie.Rows[e.RowIndex].Cells[0].Value = sr.ReadLine();
                    }
                });
            }
        }

        private void DgZarzadFirmy_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                OtworzPlikDoOdczytu((dialog) => 
                {
                    dgZarzadFirmy.Rows[e.RowIndex].Cells[1].Value = dialog.FileName;

                    using (var sr = File.OpenText(dialog.FileName))
                    {
                        dgZarzadFirmy.Rows[e.RowIndex].Cells[0].Value = sr.ReadLine();
                    }
                });
            }
        }

        private void MsTrasaPlikZapisz_Click(object sender, EventArgs e)
        {
            using (var sw = File.CreateText(nazwaPliku))
            {
                StworzTraseZInputow().Zapisz(sw);
            }
        }

        private Trasa StworzTraseZInputow()
        {
            var punktyTrasy = new List<Point>();

            foreach (DataGridViewRow row in dgTrasaPunkty.Rows)
            {
                if (row.Cells[0] == null && row.Cells[1] == null) continue;
                punktyTrasy.Add(new Point(Convert.ToInt32(row.Cells[0].Value), Convert.ToInt32(row.Cells[1].Value)));
            }

            return new Trasa(tbTrasaNazwa.Text, Convert.ToInt32(tbTrasaDlugosc.Text), Convert.ToDouble(tbTrasaPredkosc.Text), punktyTrasy);
        }

        private void MsTrasaPlikZapiszJako_Click(object sender, EventArgs e)
        {
            OtworzPlikDoZapisu((dialog) =>
            {
                Stream stream;
                if ((stream = dialog.OpenFile()) != null)
                {
                    using (var sw = new StreamWriter(stream))
                    {
                        StworzTraseZInputow().Zapisz(sw);
                    }
                    stream.Close();
                }
            });
        }

        private void MsTrasaPlikWczytaj_Click(object sender, EventArgs e)
        {
            OtworzPlikDoOdczytu((dialog) => 
            {
                nazwaPliku = dialog.FileName;
                var trasa = Trasa.OdczytajPlik(dialog.FileName);
                tbTrasaNazwa.Text = trasa.NazwaTrasy;
                tbTrasaDlugosc.Text = trasa.DystansTrasy.ToString();
                tbTrasaPredkosc.Text = trasa.VMaxTrasy.ToString();

                foreach (var punkt in trasa.PunktyTrasy)
                {
                    var row = (DataGridViewRow)dgTrasaPunkty.Rows[0].Clone();
                    row.Cells[0].Value = punkt.X;
                    row.Cells[1].Value = punkt.Y;
                    dgTrasaPunkty.Rows.Add(row);
                }
            });
        }

        private void ZapiszPrzejazdyZInputow(StreamWriter sw)
        {
            foreach (DataGridViewRow row in dgPrzejazdy.Rows)
            {
                sw.WriteLine($"{0}|{1}|{2}|{3}", row.Cells[0], row.Cells[1], row.Cells[2], row.Cells[3]);
            }
        }

        private void MsPrzejazdyPlikZapisz_Click(object sender, EventArgs e)
        {
            using (var sw = File.CreateText(nazwaPliku))
            {
                ZapiszPrzejazdyZInputow(sw);
            }
        }

        private void MsPrzejazdyPlikZapiszJako_Click(object sender, EventArgs e)
        {
            OtworzPlikDoZapisu((dialog) => 
            {
                Stream stream;
                if ((stream = dialog.OpenFile()) != null)
                {
                    using (var sw = new StreamWriter(stream))
                    {
                        ZapiszPrzejazdyZInputow(sw);
                    }
                    stream.Close();
                }
            });
        }

        private void MsPrzejazdyPlikWczytaj_Click(object sender, EventArgs e)
        {
            OtworzPlikDoOdczytu((dialog) => 
            {
                nazwaPliku = dialog.FileName;
                using (var sr = File.OpenText(dialog.FileName))
                {
                    do
                    {
                        var dane = sr.ReadLine().Split('|');
                        var row = (DataGridViewRow)dgPrzejazdy.Rows[0].Clone();

                        row.Cells[0].Value = dane[0];
                        row.Cells[1].Value = dane[1];
                        row.Cells[2].Value = dane[2];
                        row.Cells[3].Value = (dane.Length == 4) ? dane[3] : null;

                        dgPrzejazdy.Rows.Add(row);
                    } while (!sr.EndOfStream);
                }
            });
        }

        private void MsZarzadPlikWczytaj_Click(object sender, EventArgs e)
        {
            OtworzPlikDoOdczytu((dialog) => 
            {
                nazwaPliku = dialog.FileName;
                var zt = SynchronicznyZarzadTransportu.OdczytajPlik(dialog.FileName);
                tbZarzadNazwa.Text = zt.NazwaZarzadu;

                foreach (var p in zt.SiecPrzystankow)
                {
                    var row = (DataGridViewRow)dgZarzadPrzystanki.Rows[0].Clone();
                    row.Cells[0].Value = p.NazwaPrzystanku;
                    row.Cells[1].Value = p.SciezkaPlikuKonfiguracyjnego;
                    dgZarzadPrzystanki.Rows.Add(row);
                }

                foreach (var f in zt.ListaFirm)
                {
                    var row = (DataGridViewRow)dgZarzadFirmy.Rows[0].Clone();
                    row.Cells[0].Value = f.NazwaFirmy;
                    row.Cells[1].Value = f.SciezkaPlikuKonfiguracyjnego;
                    dgZarzadFirmy.Rows.Add(row);
                }

                foreach (var l in zt.ListaLinii)
                {
                    var row = (DataGridViewRow)dgZarzadLinie.Rows[0].Clone();
                    row.Cells[0].Value = l.IdLinii;
                    row.Cells[1].Value = l.SciezkaPlikuKonfiguracyjnego;
                    dgZarzadLinie.Rows.Add(row);
                }
            });
        }

        private void MsZarzadPlikZapisz_Click(object sender, EventArgs e)
        {
            using (var sw = File.CreateText(nazwaPliku))
            {
                StworzZarzadZInputow().Zapisz(sw);
            }
        }

        private ZarzadTransportu StworzZarzadZInputow()
        {
            var zt = new SynchronicznyZarzadTransportu(tbZarzadNazwa.Text);

            foreach (DataGridViewRow row in dgZarzadPrzystanki.Rows)
            {
                if (row.Cells[0].Value == null || row.Cells[1].Value == null) continue;
                zt.DodajPrzystanek(Przystanek.OdczytajPlik(row.Cells[1].Value.ToString(), zt));
            }

            foreach (DataGridViewRow row in dgZarzadFirmy.Rows)
            {
                if (row.Cells[0].Value == null || row.Cells[1].Value == null) continue;
                zt.DodajFirme(FirmaLosowa.OdczytajPlik(row.Cells[1].Value.ToString(), zt));
            }

            foreach (DataGridViewRow row in dgZarzadLinie.Rows)
            {
                if (row.Cells[0].Value == null || row.Cells[1].Value == null) continue;
                zt.DodajLinie(Linia.OdczytajPlik(row.Cells[1].Value.ToString(), zt));
            }

            return zt;
        }

        private void MsZarzadPlikZapiszJako_Click(object sender, EventArgs e)
        {
            OtworzPlikDoZapisu((dialog) =>
            {
                Stream stream;
                if ((stream = dialog.OpenFile()) != null)
                {
                    using (var sw = new StreamWriter(stream))
                    {
                        StworzZarzadZInputow().Zapisz(sw);
                    }
                    stream.Close();
                }
            });
        }

        private void ZapiszKonfiguracjeZInputow(StreamWriter sw)
        {
            sw.WriteLine($"{0}|{1}|{2}", tbKonfiguracjaZdjecie.Text, tbKonfiguracjaPrzejazdy.Text, cbKonfiguracjaGeneracjaLinii.Checked ? 1 : 0);

            foreach (DataGridViewRow row in dgKonfiguracjaZarzady.Rows)
            {
                sw.WriteLine(row.Cells[1]);
            }
        }

        private void OdczytajZarzadZPliku(string sciezkaPliku)
        {
            using (var sr = File.OpenText(sciezkaPliku))
            {
                var dane = sr.ReadLine().Split('|');

                tbKonfiguracjaZdjecie.Text = dane[0];
                tbKonfiguracjaPrzejazdy.Text = dane[1];
                cbKonfiguracjaGeneracjaLinii.Checked = (dane[2] == "1") ? true : false;

                do
                {
                    var row = (DataGridViewRow)dgKonfiguracjaZarzady.Rows[0].Clone();
                    var zt = SynchronicznyZarzadTransportu.OdczytajPlik(sr.ReadLine());
                    row.Cells[0].Value = zt.NazwaZarzadu;
                    row.Cells[1].Value = zt.SciezkaPlikuKonfiguracyjnego;

                } while (!sr.EndOfStream);
            }
        }

        private void MsKonfiguracjaPlikZapiszJako_Click(object sender, EventArgs e)
        {
            OtworzPlikDoZapisu((dialog) => 
            {
                using (var sw = File.CreateText(dialog.FileName))
                {
                    ZapiszKonfiguracjeZInputow(sw);
                }
            });
        }

        private void MsKonfiguracjaPlikZapisz_Click(object sender, EventArgs e)
        {
            using (var sw = File.CreateText(nazwaPliku))
            {
                ZapiszKonfiguracjeZInputow(sw);
            }
        }

        private void MsKonfiguracjaPlikWczytaj_Click(object sender, EventArgs e)
        {
            OtworzPlikDoOdczytu((dialog) => 
            {
                OdczytajZarzadZPliku(dialog.FileName);
            });
        }
    }
}
