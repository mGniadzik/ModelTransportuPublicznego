using ModelTransportuPublicznego.Misc;

namespace ModelTransportuPublicznego
{

    internal static class Program {
        public static void Main(string[] args)
        {
            Symulacja symulacja = new Symulacja("../../../config.txt");

            if (!symulacja.DaneWczytane)
            {
                symulacja.WygenerujLosowePrzyplywy(4, 20);
            }
            
            symulacja.RozpocznijSymulacje();
            symulacja.ZapiszStatusyLinii("linie.txt");
        }
    }
}