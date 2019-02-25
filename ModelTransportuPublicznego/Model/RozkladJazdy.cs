using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ModelTransportuPublicznego.Misc;

namespace ModelTransportuPublicznego.Model {
    public class RozkladJazdy : IEnumerable<WpisRozkladuJazdy> {
        private List<WpisRozkladuJazdy> rozkladJazdy;

        public IEnumerable<WpisRozkladuJazdy> WpisyRozkladuJazdy => rozkladJazdy;

        public RozkladJazdy() {
            rozkladJazdy = new List<WpisRozkladuJazdy>();
        }

        public RozkladJazdy(IEnumerable<WpisRozkladuJazdy> rozkladJazdy) : this() {
            foreach (var wpis in rozkladJazdy) {
                this.rozkladJazdy.Add(wpis);
            }
        }

        public void DodajWpisDoRozkladu(WpisRozkladuJazdy wpis) {
            rozkladJazdy.Add(wpis);
        }

        public IEnumerable<WpisRozkladuJazdy> ZwrocRozkladJazdy() {
            return rozkladJazdy.OrderBy(x => x.CzasPrzyjazdu);
        }


        public IEnumerator<WpisRozkladuJazdy> GetEnumerator() {
            return rozkladJazdy.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
    }
}