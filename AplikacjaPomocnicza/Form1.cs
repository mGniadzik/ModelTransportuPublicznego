using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AplikacjaPomocnicza
{
    public partial class Form1 : Form
    {
        private List<Panel> panele;

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
            UstawPanelJakoWidoczny(pZmianaPrzyspieszenia);
        }

        private void bBack_Click(object sender, EventArgs e)
        {
            UstawPanelJakoWidoczny(pPowitanie);
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            UstawPanelJakoWidoczny(pPowitanie);
        }
    }
}
