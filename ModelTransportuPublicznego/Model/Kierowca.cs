using System;

namespace ModelTransportuPublicznego.Model {
    public class Kierowca {
        private TimeSpan czasRozpoczeciaPracy;
        private TimeSpan czasRozpoczeciaOstatniegoPrzejazdu;
        private TimeSpan czasPracy;
        private TimeSpan czasPracyOdOstatniejPrzerwy;
        private TimeSpan czasPrzerwy;

        public Kierowca() {
            czasRozpoczeciaPracy = TimeSpan.Zero;
            czasPracy = TimeSpan.Zero;
            czasPracyOdOstatniejPrzerwy = TimeSpan.Zero;
            czasPrzerwy = TimeSpan.Zero;
        }

        public virtual void WykonajPrzejazd(TimeSpan czas) {
            if (czasRozpoczeciaPracy == TimeSpan.Zero) {
                czasRozpoczeciaPracy = czas;
                czasRozpoczeciaOstatniegoPrzejazdu = czas;
                return;
            }

            czasPrzerwy = czas;
            czasPracyOdOstatniejPrzerwy = TimeSpan.Zero;
            czasRozpoczeciaOstatniegoPrzejazdu = czas;
        }

        public virtual bool CzyMozeWykonacPrzejazd(TimeSpan spodziewanyCzasPrzejazdu) {
            return (czasPracyOdOstatniejPrzerwy + spodziewanyCzasPrzejazdu) < new TimeSpan(4, 30, 0);
        }

        public virtual void ZakonczPrace(TimeSpan czas) {
            czasPracy += czasRozpoczeciaOstatniegoPrzejazdu + czas;
            czasRozpoczeciaOstatniegoPrzejazdu = TimeSpan.Zero;
            czasPrzerwy = czas;
        }
    }
}