using System;
using System.Text;

namespace ModelTransportuPublicznego.Misc {
    public static class UIDGenerator {
        private static readonly string znaczki = "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM1234567890-_";
        private static readonly Random rand = new Random();

        public static string WygenerujUID() {
            return WygenerujUID(11);
        }

        public static string WygenerujUID(int dlugosc) {
//            var rand = new Random();
            var sb = new StringBuilder();

            for (int i = 0; i < dlugosc; i++) {
                sb.Append(znaczki[rand.Next(znaczki.Length)]);
            }

            return sb.ToString();
        }
    }
}