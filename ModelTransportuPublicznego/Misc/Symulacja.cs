using ModelTransportuPublicznego.Implementacja;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace ModelTransportuPublicznego.Misc
{
    class Symulacja
    {
        private string sciezkaPlikuTla;
        private Image tlo;
        private int szerokoscMapy;
        private int wysokoscMapy;
        private bool czyGenerowacLinieOdwrotne;
        private List<SynchronicznyZarzadTransportu> zarzadyTransportu;
        public Symulacja(string sciezkaPlikuKonfiguracji)
        {
            using (var sr = File.OpenText(sciezkaPlikuKonfiguracji))
            {
                var dane = sr.ReadLine().Split('|');
                sciezkaPlikuKonfiguracji = dane[0];
                tlo = Image.FromFile(sciezkaPlikuKonfiguracji);
                szerokoscMapy = Convert.ToInt32(dane[2]);
                wysokoscMapy = Convert.ToInt32(dane[3]);
                czyGenerowacLinieOdwrotne = (dane[4] == "1") ? true : false;

                do
                {
                    var zt = SynchronicznyZarzadTransportu.OdczytajPlik(sr.ReadLine());
                    zarzadyTransportu.Add(zt);

                    if (czyGenerowacLinieOdwrotne)
                    {
                        zt.DodajLiniePowrotne();
                    }

                } while (!sr.EndOfStream);

                using (var srPrzejazdy = File.OpenText(dane[1]))
                {
                    do
                    {
                        var danePrzejazdu = sr.ReadLine().Split('|');
                        var zt = ZwrocZarzadPosiadajacyFirmeDanejKonfiguracji(danePrzejazdu[1]);
                        zt.DodajPrzejazdDoListy(danePrzejazdu[0], danePrzejazdu[1], danePrzejazdu[2], danePrzejazdu[3]);
                    } while (!srPrzejazdy.EndOfStream);
                }
            }

            WizualizatorMapy.Instancja(sciezkaPlikuTla, szerokoscMapy, wysokoscMapy);
        }

        public void RozpocznijSymulacje()
        {
            foreach (var zt in zarzadyTransportu)
            {
                zt.WykonajPrzejazdy();
            }
        }

        private SynchronicznyZarzadTransportu ZwrocZarzadPosiadajacyFirmeDanejKonfiguracji(string sciezkaPlikuKonfiguracji)
        {
            foreach (var zt in zarzadyTransportu)
            {
                foreach (var f in zt.ListaFirm)
                {
                    if (f.SciezkaPlikuKonfiguracyjnego == sciezkaPlikuKonfiguracji) return zt;
                }
            }

            return null;
        }
    }
}
