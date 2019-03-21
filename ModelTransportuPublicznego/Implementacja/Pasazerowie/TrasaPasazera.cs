using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using ModelTransportuPublicznego.Model;

namespace ModelTransportuPublicznego.Implementacja.Pasazerowie {
    public class TrasaPasazera : IEnumerable<ElementTrasy> {
        private List<ElementTrasy> trasa;
        private TimeSpan czasWaznosci;
        
        public ElementTrasy this[int index] => trasa[index];

        public int Count => trasa.Count;

        public Przystanek PrzystanekStartowy => trasa[0].Przystanek;

        public Przystanek PrzystanekKoncowy => trasa[trasa.Count - 1].Przystanek;

        public TimeSpan CzasWaznosci => czasWaznosci;

        public TrasaPasazera() {
            trasa = new List<ElementTrasy>();
            czasWaznosci = TimeSpan.Zero;
        }

        public TrasaPasazera(IEnumerable<ElementTrasy> trasa, TimeSpan czasWaznosci) : this() {
            foreach (var elem in trasa) {
                var el = new ElementTrasy(elem);
                elem.CzyPrzebyty = true;
                
                if (el.CzyPrzebyty) Console.WriteLine("Ten sam");
                
                this.trasa.Add(el);
            }

            this.czasWaznosci = czasWaznosci;
        }

        public bool CzyPrzedawniony(TimeSpan czasPrzedawnienia) {
            return czasPrzedawnienia > czasWaznosci;
        }

        public IEnumerator<ElementTrasy> GetEnumerator() {
            return trasa.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
    }
}