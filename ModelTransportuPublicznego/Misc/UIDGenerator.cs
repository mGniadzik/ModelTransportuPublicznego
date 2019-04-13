using System;
using System.Text;

namespace ModelTransportuPublicznego.Misc {
    public static class UidGenerator {
        private static readonly string znaczki = "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM1234567890-_";
        private static readonly Random Rand = new Random();

        public static string WygenerujUid(int dlugosc = 11) {
//            var rand = new Random();
            var sb = new StringBuilder();

            for (int i = 0; i < dlugosc; i++) {
                sb.Append(znaczki[Rand.Next(znaczki.Length)]);
            }

            return sb.ToString();
        }
    }
}