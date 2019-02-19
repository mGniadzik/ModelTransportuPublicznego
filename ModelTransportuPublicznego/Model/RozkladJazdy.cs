using System;
using System.Collections.Generic;

namespace ModelTransportuPublicznego.Model {
    public class RozkladJazdy {
        private List<TimeSpan> czasyPrzejazdow;

        public RozkladJazdy(IEnumerable<TimeSpan> listaPrzejazdow) {
            czasyPrzejazdow = new List<TimeSpan>();
            
            foreach (var ts in listaPrzejazdow) {
                czasyPrzejazdow.Add(ts);
            }
        }
        
        public List<TimeSpan> CzasyPrzejazdow => czasyPrzejazdow;
    }
}