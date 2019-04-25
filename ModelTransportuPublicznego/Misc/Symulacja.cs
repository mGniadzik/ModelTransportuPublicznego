using ModelTransportuPublicznego.Implementacja;
using ModelTransportuPublicznego.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelTransportuPublicznego.Misc
{
    class Symulacja
    {
        private string sciezkaPlikuTla;
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
                szerokoscMapy = Convert.ToInt32(dane[2]);
                wysokoscMapy = Convert.ToInt32(dane[3]);
                czyGenerowacLinieOdwrotne = (dane[4] == "1") ? true : false;

                do
                {
                    zarzadyTransportu.Add(SynchronicznyZarzadTransportu.OdczytajPlik(sr.ReadLine()));
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
