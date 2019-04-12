using System;
using System.Collections;
using System.Collections.Generic;

namespace ModelTransportuPublicznego.Model {
    public class RozkladPrzejazdow : IEnumerable<TimeSpan> {
        private List<TimeSpan> czasyPrzejazdow;

        public RozkladPrzejazdow(IEnumerable<TimeSpan> listaPrzejazdow) {
            czasyPrzejazdow = new List<TimeSpan>();
            
            foreach (var ts in listaPrzejazdow) {
                czasyPrzejazdow.Add(ts);
            }
        }
        
        public IEnumerable<TimeSpan> CzasyPrzejazdow => czasyPrzejazdow;


        public IEnumerator<TimeSpan> GetEnumerator() {
            return czasyPrzejazdow.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
    }
}