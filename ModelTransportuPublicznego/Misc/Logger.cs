using System;
using System.Globalization;
using System.IO;
using ModelTransportuPublicznego.Model;
using ModelTransportuPublicznego.Model.Firma;
using ModelTransportuPublicznego.Model.Przystanek;

namespace ModelTransportuPublicznego.Misc {
    public static class Logger {
        public static string CLogName =
            $"CLog{NazwaPliku(DateTime.Now)}.log";
        public static string HLogName = $"HLog{NazwaPliku(DateTime.Now)}.log";
        
        public static void ZalogujBrakDostepnegoAutobusu(Firma firma, Linia linia) {
            var msg = $"Firma {firma.NazwaFirmy} nie posiadała dostępnego autobusu do obsługi linii {linia.IdLinii}.";
            Console.WriteLine(msg);
            LogText(msg);
        }

        public static void ZalogujBrakDostepnegoKierowcy(Firma firma, Linia linia) {
            var msg =
                $"Firma {firma.NazwaFirmy} nie posiadała dostępnego kierowcy do obsługi linii {linia.IdLinii}.";
            Console.WriteLine(msg);
            LogText(msg);
        }

        public static void ZalogujPobieraniePasazerow(TimeSpan czasAkcji, Autobus autobus, Przystanek przystanek, int ilosc, TimeSpan czas) {
            var msg = $"[{czasAkcji}] Autobus {autobus.IdAutobusu} pobrał {ilosc} pasażerów na przystanku: " +
                      $"{przystanek.NazwaPrzystanku} linii: {autobus.liniaAutobusu.IdLinii}. Czas zakończenia akcji: {czas}.";
            Console.WriteLine(msg);
            LogText(msg);
        }

        public static void ZalogujPrzejechanieTrasy(string uid, TimeSpan czasAkcji, Autobus autobus, Trasa trasa, TimeSpan czasZakonczenia) {
            var msg = $"[{czasAkcji}] Autobus: {autobus.IdAutobusu} linii: {autobus.liniaAutobusu.IdLinii} przewiózł " +
                      $"{autobus.IloscPasazerow} pasażerów na trasie {trasa.NazwaTrasy} po między przystankani " +
                      $"{trasa.PrzystanekLewy.NazwaPrzystanku} - {trasa.PrzystanekPrawy.NazwaPrzystanku}. " +
                      $"Czas zakończenia akcji: {czasZakonczenia}.";
            Console.WriteLine(msg);
            LogText(uid, czasAkcji, autobus, trasa, autobus.liniaAutobusu, czasZakonczenia);
            LogText(msg);
        }

        public static void ZalogujWypuszczniePasazerow(TimeSpan czasAkcji, Autobus autobus, Przystanek przystanek, int ilosc, TimeSpan czas) {
            var msg = $"[{czasAkcji}] Autobus {autobus.IdAutobusu} wypuścił {ilosc} pasażerów na przystanku: " +
                      $"{przystanek.NazwaPrzystanku} linii: {autobus.liniaAutobusu.IdLinii}. Czas zakończenia akcji: {czas}.";
            Console.WriteLine(msg);
            LogText(msg);
        }

        public static void ZalogujZakonczenieTrasy(TimeSpan czasAkcji, Autobus autobus, Przystanek przystanek, Linia linia, TimeSpan czasZakonczenia) {
            var msg =
                $"[{czasAkcji}] Autobus: {autobus.IdAutobusu} linii: {autobus.liniaAutobusu.IdLinii} zakończył trasę na " +
                $"przystanku: {przystanek.NazwaPrzystanku}. Czas zakończenia akcji: {czasZakonczenia}";
            Console.WriteLine(msg);
            LogText(msg);
        }

        private static void LogText(string uid, TimeSpan czasAkcji, Autobus autobus, Trasa trasa, Linia linia, TimeSpan czasZakonczenia) {
            using (var sw = File.AppendText(CLogName)) {
                sw.WriteLine($"{uid}|{czasAkcji}|{linia.IdLinii}|{trasa.PrzystanekLewy.NazwaPrzystanku}|" +
                             $"{trasa.PrzystanekPrawy.NazwaPrzystanku}|{autobus.IdAutobusu}|{czasZakonczenia}");
                
            }
        }

        private static void LogText(string text) {
            using (var sw = File.AppendText(HLogName)) {
                sw.WriteLine(text);
                
            }
        }

        private static string NazwaPliku(DateTime dt) {
            return dt.ToString(CultureInfo.InvariantCulture).Replace('/', '_').
                Replace(' ', '_').Replace(':', '-');
        }
    }
}