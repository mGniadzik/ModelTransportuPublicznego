using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
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

        public virtual IEnumerable<Linia> ZwrocLinie()
        {
            return rozkladJazdy.Select(wrj => wrj.LiniaObslugujaca).Distinct();
        }


        public IEnumerator<WpisRozkladuJazdy> GetEnumerator() {
            return rozkladJazdy.GetEnumerator();
        }

        public IEnumerable<WpisRozkladuJazdy> ZwrocPozostaleWpisy(TimeSpan czas) {
            return rozkladJazdy.Where((wpis) => !wpis.CzyWykonany && wpis.CzasPrzyjazdu > czas).OrderBy(wpis => wpis.CzasPrzyjazdu);
        }

        public void UstawJakoOdwiedzony(Linia linia, TimeSpan czas) {
            foreach (var wpis in rozkladJazdy) {
                if (wpis.LiniaObslugujaca == linia && wpis.CzasPrzyjazdu == czas && !wpis.CzyWykonany) {
                    wpis.CzyWykonany = true;
                    return;
                }
            } 
            
            
            throw new InvalidEnumArgumentException(
                $"W rozkładzie nie ma przejazdu linii {linia.IdLinii} o godzinie {czas}");
        }
        
        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
    }
}