using ModelTransportuPublicznego.Implementacja.Autobusy;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AplikacjaPomocnicza
{
    public partial class Form1 : Form
    {
        private List<Panel> panele;
        private AutobusLiniowy autobus;

        public Form1()
        {
            InitializeComponent();
            panele = new List<Panel>() { pPowitanie, pZmianaPrzyspieszenia, pAutobusStale };
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
            try
            {
                autobus = new AutobusLiniowy(tbId.Text, Convert.ToInt32(tbPojemnosc.Text), Convert.ToInt32(tbDrzwi.Text), Convert.ToDouble(tbPrzyspieszenie.Text),
                Convert.ToDouble(tbHamowanie.Text), Convert.ToDouble(tbVMax.Text), Convert.ToDouble(tbDlugosc.Text));
                MessageBox.Show(autobus.DlugoscAutobusu.ToString());
            } catch (Exception exc)
            {
                MessageBox.Show(string.Format("Znaleziono wyjątek: {0}", exc));
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
        }
    }
}
