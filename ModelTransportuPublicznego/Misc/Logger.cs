using System;
using ModelTransportuPublicznego.Model;

namespace ModelTransportuPublicznego.Misc {
    public static class Logger {
        public static void ZalogujBrakDostepnegoAutobusu(Firma firma, Linia linia) {
            Console.WriteLine($"Firma {firma.NazwaFirmy} nie posiadała dostępnego autobusu do obsługi linii {linia.IdLinii}.");
        }

        public static void ZalogujBrakDostepnegoKierowcy(Firma firma, Linia linia) {
            Console.WriteLine($"Firma {firma.NazwaFirmy} nie posiadała dostępnego kierowcy do obsługi linii {linia.IdLinii}.");
        }

        public static void ZalogujPobieraniePasazerow(Autobus autobus, Przystanek przystanek, int ilosc, TimeSpan czas) {
            Console.WriteLine($"Autobus {autobus.IdAutobusu} pobrał {ilosc} pasażerów na przystanku: " +
                              $"{przystanek.NazwaPrzystanku} linii: {autobus.liniaAutobusu.IdLinii}. Zajeło to: {czas}.");
        }

        public static void ZalogujPrzejechanieTrasy(Autobus autobus, Trasa trasa, TimeSpan czas) {
            Console.WriteLine($"Autobus: {autobus.IdAutobusu} linii: {autobus.liniaAutobusu.IdLinii} przewiózł " +
                              $"{autobus.IloscPasazerow} pasażerów na trasie {trasa.NazwaTrasy} po między przystankani " +
                              $"{trasa.PrzystanekPierwszy.NazwaPrzystanku} - {trasa.PrzystanekDrugi.NazwaPrzystanku}. " +
                              $"Zajeło to: {czas}.");
        }

        public static void ZalogujWypuszczniePasazerow(Autobus autobus, Przystanek przystanek, int ilosc, TimeSpan czas) {
            Console.WriteLine($"Autobus {autobus.IdAutobusu} wypuścił {ilosc} pasażerów na przystanku: " +
                              $"{przystanek.NazwaPrzystanku} linii: {autobus.liniaAutobusu.IdLinii}. Zajeło to: {czas}.");
        }

        public static void ZalogujZakonczenieTrasy(Autobus autobus, Przystanek przystanek, Linia linia,
            TimeSpan czasPerzejazdu) {
            Console.WriteLine($"Autobus: {autobus.IdAutobusu} linii: {autobus.liniaAutobusu.IdLinii} zakończył trasę na " +
                              $"przystanku: {przystanek.NazwaPrzystanku} po czasie {czasPerzejazdu}.");
        }
    }
}