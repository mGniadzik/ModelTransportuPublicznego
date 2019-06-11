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
        private string sciezkaPlikuPrzyplywow;
        private List<SynchronicznyZarzadTransportu> zarzadyTransportu;
        public Symulacja(string sciezkaPlikuKonfiguracji)
        {
            zarzadyTransportu = new List<SynchronicznyZarzadTransportu>();

            using (var sr = File.OpenText(sciezkaPlikuKonfiguracji))
            {
                var dane = sr.ReadLine().Split('|');
                sciezkaPlikuTla = dane[0];
                tlo = Image.FromFile(sciezkaPlikuTla);
                szerokoscMapy = Convert.ToInt32(dane[2]);
                wysokoscMapy = Convert.ToInt32(dane[3]);
                czyGenerowacLinieOdwrotne = (dane[4] == "1") ? true : false;

                if (dane.Length == 6)
                {
                    sciezkaPlikuPrzyplywow = dane[5];
                }
                else
                {
                    sciezkaPlikuPrzyplywow = null;
                }

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
                        var danePrzejazdu = srPrzejazdy.ReadLine().Split('|');
                        var zt = ZwrocZarzadPosiadajacyFirmeDanejKonfiguracji(danePrzejazdu[1]);
                        zt.DodajPrzejazdDoListy(danePrzejazdu[0], danePrzejazdu[1], danePrzejazdu[2], danePrzejazdu[3]);
                        zt.StworzRozkladJazdyNaPrzystankach();
                    } while (!srPrzejazdy.EndOfStream);
                }
            }

            GeneratorPasazerow.Instancja(zarzadyTransportu[0].SiecPrzystankow, zarzadyTransportu[0].ListaLinii);

            var generator = GeneratorPrzyplywowPasazerow.Instancja();
            if (DaneWczytane)
            {
                generator.OdczytajPlik(sciezkaPlikuPrzyplywow, zarzadyTransportu[0]);
                zarzadyTransportu[0].DodajPrzyplywy(generator.Przyplywy);
            }

            WizualizatorMapy.Instancja(sciezkaPlikuTla, szerokoscMapy, wysokoscMapy);
        }

        public bool DaneWczytane => sciezkaPlikuPrzyplywow != null;

        public void RozpocznijSymulacje()
        {
            foreach (var zt in zarzadyTransportu)
            {
                zt.WykonajPrzejazdy();
            }
        }

        public void ZapiszStatusyLinii(string sciezkaPliku)
        {
            using (var sw = File.CreateText(sciezkaPliku))
            {
                foreach (var zt in zarzadyTransportu)
                {
                    sw.WriteLine(zt.NazwaZarzadu);
                    zt.WygenerujStatusyLinii(sw);
                }
            }
        }

        public void WygenerujLosowePrzyplywy(int iloscPrzyplywow, int liczbaPasazerow)
        {
            var generator = GeneratorPrzyplywowPasazerow.Instancja();

            foreach (var przystanek in zarzadyTransportu[0].SiecPrzystankow)
            {
                generator.WygenerujLosowePrzyplywyDlaPrzystanku(przystanek, iloscPrzyplywow, liczbaPasazerow);
            }

            var czas = DateTime.Now.TimeOfDay.ToString().Replace(':', '-');
            generator.Zapisz($"{ czas }.txt");
            zarzadyTransportu[0].DodajPrzyplywy(generator.Przyplywy);
        }

        private SynchronicznyZarzadTransportu ZwrocZarzadPosiadajacyFirmeDanejKonfiguracji(string nazwaFirmy)
        {
            foreach (var zt in zarzadyTransportu)
            {
                foreach (var f in zt.ListaFirm)
                {
                    if (f.NazwaFirmy == nazwaFirmy) return zt;
                }
            }

            return null;
        }
    }
}
