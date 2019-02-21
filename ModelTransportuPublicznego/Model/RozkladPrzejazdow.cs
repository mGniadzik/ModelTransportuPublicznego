using System;
using System.Collections.Generic;

namespace ModelTransportuPublicznego.Model {
    public class RozkladPrzejazdow {
        private List<TimeSpan> czasyPrzejazdow;

        public RozkladPrzejazdow(IEnumerable<TimeSpan> listaPrzejazdow) {
            czasyPrzejazdow = new List<TimeSpan>();
            
            foreach (var ts in listaPrzejazdow) {
                czasyPrzejazdow.Add(ts);
            }
        }
        
        public List<TimeSpan> CzasyPrzejazdow => czasyPrzejazdow;
    }
}