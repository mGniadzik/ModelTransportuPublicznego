using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ModelTransportuPublicznego.Misc {
    internal class MinKopiec<T> : IEnumerable where T : IComparable<T>
    {
        private List<T> elementy;

        public MinKopiec()
        {
            elementy = new List<T>();
        }

        public int Count => elementy.Count;

        private int IndexLewegoDziecka(int index) => 2 * index + 1;
        private int IndexPrawegoDziecka(int index) => 2 * index + 2;
        private int IndexRodzica(int index) => (index - 1) / 2;
        private T ZwrocLeweDziecko(int index) => elementy[IndexLewegoDziecka(index)];
        private T ZwrocPraweDziecko(int index) => elementy[IndexPrawegoDziecka(index)];
        private T ZwrocRodzica(int index) => elementy[IndexRodzica(index)];

        private bool IstniejeLeweDziecko(int index) => IndexLewegoDziecka(index) < elementy.Count;
        private bool IstniejePraweDziecko(int index) => IndexPrawegoDziecka(index) < elementy.Count;
        private bool JestKorzeniem(int index) => index == 0;
        public bool JestPusty => elementy.Count == 0;

        private void Zamien(int firstIndex, int secondIndex)
        {
            var temp = elementy[firstIndex];
            elementy[firstIndex] = elementy[secondIndex];
            elementy[secondIndex] = temp;
        }

        public T Peek()
        {
            if (JestPusty) throw new IndexOutOfRangeException();

            return elementy[0];
        }

        public T ZdejminNajmniejszy()
        {
            if (JestPusty) throw new IndexOutOfRangeException();

            var rezultat = elementy[0];

            if (elementy.Count != 1)
            {
                elementy[0] = elementy[elementy.Count - 1];
                elementy.Remove(elementy[elementy.Count - 1]);
                HeapifyDown();
            } else
            {
                elementy.Clear();
            }

            return rezultat;
        }

        public void Dodaj(T elem)
        {
            elementy.Add(elem);

            HeapifyUp();
        }

        public void NaprawKopiec() {
            Dodaj(ZdejminNajmniejszy());
        }

        public void DodajWiele(IEnumerable<T> elems) {
            foreach (var elem in elems) {
                elementy.Add(elem);
            }
            
            HeapifyUp();
        }

        private void HeapifyDown()
        {
            int index = 0;
            
            while(IstniejeLeweDziecko(index))
            {
                var mniejszyIndex = IndexLewegoDziecka(index);
                if (IstniejePraweDziecko(index) && ZwrocPraweDziecko(index).CompareTo(ZwrocLeweDziecko(index)) < 0)
                {
                    mniejszyIndex = IndexPrawegoDziecka(index);
                }

                if (elementy[mniejszyIndex].CompareTo(elementy[index]) >= 0) break;

                Zamien(mniejszyIndex, index);
                index = mniejszyIndex;
            }
        }

        private void HeapifyUp()
        {
            var index = elementy.Count - 1;

            while(!JestKorzeniem(index) && elementy[index].CompareTo(ZwrocRodzica(index)) < 0)
            {
                var indexRodzica = IndexRodzica(index);
                Zamien(indexRodzica, index);
                index = indexRodzica;
            }
        }

        public IEnumerator GetEnumerator() {
            return elementy.GetEnumerator();
        }
    }
}