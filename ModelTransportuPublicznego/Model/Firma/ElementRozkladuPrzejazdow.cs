using System;

namespace ModelTransportuPublicznego.Model.Firma
{
    public class ElementRozkladuPrzejazdow : IComparable<ElementRozkladuPrzejazdow>
    {
        public Linia Linia;
        public TimeSpan CzasPrzejazdu;
        
        public int CompareTo(ElementRozkladuPrzejazdow other)
        {
            return CzasPrzejazdu.CompareTo(other.CzasPrzejazdu);
        }
    }
}