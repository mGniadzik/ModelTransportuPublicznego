using System;

namespace AplikacjaCzytaniaLogow
{
    class WpisPrzejazdu
    {
        public readonly string przystanek;
        public readonly TimeSpan czas;

        public WpisPrzejazdu(string przystanek, TimeSpan czas)
        {
            this.przystanek = przystanek;
            this.czas = czas;
        }

        public WpisPrzejazdu(string przystanek, string czas)
        {
            this.przystanek = przystanek;
            this.czas = TimeSpan.Parse(czas);
        }
    }
}
