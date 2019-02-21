using System;
using System.Collections;
using System.Collections.Generic;

namespace ModelTransportuPublicznego.Misc {
    public class MinKopiec<T> : IEnumerable where T : IComparable<T> {

        private List<T> elementy = new List<T>();

        public int Count => elementy.Count;

        public void Add(T element) {
            elementy.Add(element);
            HeapifyUp(elementy.Count - 1);
        }

        public void AddRange(IEnumerable<T> elementy) {
            foreach (var elem in elementy) {
                Add(elem);
            }
        }

        public T ZwrocNajmniejszy() {
            return this.elementy.Count > 0 ? this.elementy[0] : throw new IndexOutOfRangeException("Kopiec nie posiada elementow!");
        }

        public T PopMin() {
            if (elementy.Count > 0) {
                var element = elementy[0];
                elementy[0] = elementy[elementy.Count - 1];
                elementy.RemoveAt(elementy.Count - 1);
                
                HeapifyDown(0);
                return element;
            }
            
            throw new InvalidOperationException("Kopiec jest pusty!");
        }

        private void HeapifyUp(int indeks) {
            var rodzic = ZwrocRodzica(indeks);

            if (rodzic >= 0 && elementy[indeks].CompareTo(elementy[rodzic]) < 0) {
                var temp = elementy[indeks];
                elementy[indeks] = elementy[rodzic];
                elementy[rodzic] = temp;
                HeapifyUp(rodzic);
            }

        }

        private void HeapifyDown(int indeks) {
            var najmniejszy = indeks;
            var lewy = ZwrocLewy(indeks);
            var prawy = ZwrocPrawy(indeks);

            if (lewy < elementy.Count && elementy[lewy].CompareTo(elementy[indeks]) < 0) {
                najmniejszy = lewy;
            }

            if (prawy < elementy.Count && elementy[prawy].CompareTo(elementy[indeks]) < 0) {
                najmniejszy = prawy;
            }

            if (najmniejszy != indeks) {
                var temp = elementy[indeks];
                elementy[indeks] = elementy[najmniejszy];
                elementy[najmniejszy] = temp;
                
                HeapifyDown(najmniejszy);
            }
        }

        public void Heapify() {
            HeapifyDown(0);
        }

        private int ZwrocRodzica(int indeks) {
            if (indeks <= 0) {
                return -1;
            }

            return (indeks - 1) / 2;
        }

        private int ZwrocLewy(int indeks) {
            return 2 * indeks + 1;
        }

        private int ZwrocPrawy(int indeks) {
            return 2 * indeks + 2;
        }

        public class KopiecEnum : IEnumerator {

            private List<T> elementy;
            private int position;

            public KopiecEnum(List<T> elementy) {
                this.elementy = elementy;
                position = -1;
            }

            public bool MoveNext() {
                return ++position < elementy.Count;
            }

            public void Reset() {
                position = -1;
            }

            object IEnumerator.Current => Current;

            private T Current {
                get {
                    try {
                        return elementy[position];
                    }
                    catch (IndexOutOfRangeException) {
                        throw new InvalidOperationException();
                    }
                }
            }
        }

        public IEnumerator GetEnumerator() {
            return new MinKopiec<T>.KopiecEnum(elementy);
        }
    }
}