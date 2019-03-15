using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplikacjaCzytaniaLogow
{
    class WynikInterpretacji
    {
        public readonly string idPrzejazdu;
        public readonly TimeSpan czasRozpoczecia;
        public readonly string idLinii;
        public readonly string przystanekS;
        public readonly string przystanekK;
        public readonly string idAutobusu;
        public readonly TimeSpan czasKoncowy;

        public WynikInterpretacji(string idPrzejazdu, TimeSpan czasRozpoczecia, string idLinii, string przystanekS, string przystanekK, string idAutobusu, TimeSpan czasKoncowy)
        {
            this.idPrzejazdu = idPrzejazdu;
            this.czasRozpoczecia = czasRozpoczecia;
            this.idLinii = idLinii;
            this.przystanekS = przystanekS;
            this.przystanekK = przystanekK;
            this.idAutobusu = idAutobusu;
            this.czasKoncowy = czasKoncowy;
        }
    }
}
