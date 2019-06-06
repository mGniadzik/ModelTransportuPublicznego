using ModelTransportuPublicznego.Misc;
using System;
using System.Collections.Generic;
using System.IO;

namespace ModelTransportuPublicznego.Implementacja.Pasazerowie
{
    public struct DanePasazera : IEquatable<DanePasazera>
    {
        public string id;
        public Type typPasazera;
        public int czasWsiadania;
        public int czasWysiadania;
        public string pPoczatkowy;
        public string pKoncowy;

        public DanePasazera(Type typPasazera, int czasWsiadania, int czasWysiadania, string pPoczatkowy, string pKoncowy)
        {
            id = UidGenerator.WygenerujUid();
            this.typPasazera = typPasazera;
            this.czasWsiadania = czasWsiadania;
            this.czasWysiadania = czasWysiadania;
            this.pPoczatkowy = pPoczatkowy;
            this.pKoncowy = pKoncowy;
        }

        public static bool operator == (DanePasazera dp1, DanePasazera dp2)
        {
            return dp1.id == dp2.id;
        }

        public static bool operator !=(DanePasazera dp1, DanePasazera dp2)
        {
            return dp1.id != dp2.id;
        }

        public bool Equals(DanePasazera other)
        {
            return id.Equals(other.id);
        }

        public void Zapisz(StreamWriter sw)
        {
            sw.Write($"{typPasazera}:{czasWsiadania}:{czasWysiadania}:{pPoczatkowy}:{pKoncowy}");
        }

        public override int GetHashCode()
        {
            var hashCode = 9350577;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(id);
            hashCode = hashCode * -1521134295 + EqualityComparer<Type>.Default.GetHashCode(typPasazera);
            hashCode = hashCode * -1521134295 + czasWsiadania.GetHashCode();
            hashCode = hashCode * -1521134295 + czasWysiadania.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(pPoczatkowy);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(pKoncowy);
            return hashCode;
        }
    }
}
