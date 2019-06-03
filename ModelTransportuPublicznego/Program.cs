using System;
using System.Collections.Generic;
using ModelTransportuPublicznego.Implementacja;
using ModelTransportuPublicznego.Implementacja.Autobusy;
using ModelTransportuPublicznego.Implementacja.Firmy;
using ModelTransportuPublicznego.Implementacja.Graf;
using ModelTransportuPublicznego.Misc;
using ModelTransportuPublicznego.Model;
using ModelTransportuPublicznego.Model.Przystanek;

namespace ModelTransportuPublicznego
{

    internal static class Program {
        public static void Main(string[] args)
        {
            Symulacja symulacja = new Symulacja("../../../config.txt");
        }
    }


}