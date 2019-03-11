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

        public static void ZalogujPobieraniePasazerow(TimeSpan czasAkcji, Autobus autobus, Przystanek przystanek, int ilosc, TimeSpan czas) {
            Console.WriteLine($"[{czasAkcji}] Autobus {autobus.IdAutobusu} pobrał {ilosc} pasażerów na przystanku: " +
                              $"{przystanek.NazwaPrzystanku} linii: {autobus.liniaAutobusu.IdLinii}. Czas zakończenia akcji: {czas}.");
        }

        public static void ZalogujPrzejechanieTrasy(TimeSpan czasAkcji, Autobus autobus, Trasa trasa, TimeSpan czas) {
            Console.WriteLine($"[{czasAkcji}] Autobus: {autobus.IdAutobusu} linii: {autobus.liniaAutobusu.IdLinii} przewiózł " +
                              $"{autobus.IloscPasazerow} pasażerów na trasie {trasa.NazwaTrasy} po między przystankani " +
                              $"{trasa.PrzystanekLewy.NazwaPrzystanku} - {trasa.PrzystanekPrawy.NazwaPrzystanku}. " +
                              $"Czas zakończenia akcji: {czas}.");
        }

        public static void ZalogujWypuszczniePasazerow(TimeSpan czasAkcji, Autobus autobus, Przystanek przystanek, int ilosc, TimeSpan czas) {
            Console.WriteLine($"[{czasAkcji}] Autobus {autobus.IdAutobusu} wypuścił {ilosc} pasażerów na przystanku: " +
                              $"{przystanek.NazwaPrzystanku} linii: {autobus.liniaAutobusu.IdLinii}. Czas zakończenia akcji: {czas}.");
        }

        public static void ZalogujZakonczenieTrasy(TimeSpan czasAkcji, Autobus autobus, Przystanek przystanek, Linia linia, TimeSpan czasZakonczenia) {
            Console.WriteLine($"[{czasAkcji}] Autobus: {autobus.IdAutobusu} linii: {autobus.liniaAutobusu.IdLinii} zakończył trasę na " +
                              $"przystanku: {przystanek.NazwaPrzystanku}. Czas zakończenia akcji: {czasZakonczenia}");
        }
    }
}