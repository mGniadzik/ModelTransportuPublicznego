using System;
using System.Collections;
using System.Collections.Generic;

namespace ModelTransportuPublicznego.Model.Firma {
    public class RozkladPrzejazdow : IEnumerable<ElementRozkladuPrzejazdow>
    {
        protected List<ElementRozkladuPrzejazdow> przejazdy;

        protected RozkladPrzejazdow()
        {
            przejazdy = new List<ElementRozkladuPrzejazdow>();
        }

        protected RozkladPrzejazdow(IEnumerable<ElementRozkladuPrzejazdow> przejazdy) : this()
        {
            foreach (var p in przejazdy)
            {
                this.przejazdy.Add(p);
            }
        }


        public IEnumerator<ElementRozkladuPrzejazdow> GetEnumerator()
        {
            return przejazdy.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
    }
}