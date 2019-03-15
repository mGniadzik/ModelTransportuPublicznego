using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using System.Windows.Forms;

namespace AplikacjaCzytaniaLogow
{
    public partial class Form1 : Form
    {
        private List<string> zawartoscPliku;

        public Form1()
        {
            InitializeComponent();
            zawartoscPliku = new List<string>();
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
                MessageBox.Show($"{ofd.FileName}", "Name of a file", MessageBoxButtons.OK);
                zawartoscPliku = PrzeczytajPlik(ofd.FileName).ToList();
                MessageBox.Show($"{zawartoscPliku.Count}", "Rezultat", MessageBoxButtons.OK);
                panelPowitania.Visible = false;
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


    }
}
