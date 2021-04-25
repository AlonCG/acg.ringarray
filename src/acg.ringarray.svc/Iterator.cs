using System;
using System.Collections;

namespace acg.ringarray.svc
{
    public class Iterator : IEnumerable
    {
        private int[] _values;
        public Iterator() : this(100, 1, 10000, 0) { }
        public Iterator(int arraySize, int lowerBound, int upperBound, int randomSeed) {
            _values = SeedIntArray.Seed(arraySize, lowerBound, upperBound, randomSeed);
        }

        public IEnumerator GetEnumerator() {
            return new Enumerator(_values);
        }

        private class Enumerator : IEnumerator, IIterator<int>
        {
            private int[] _values;
            private int _position = -1;
            public Enumerator(int[] values) {
                _values = values;
            }

            public int Next() => Convert.ToInt32(Current);
            public object Current {
                get {
                    try {
                        return _values[_position];
                    } catch (IndexOutOfRangeException) {
                        throw new InvalidOperationException();
                    }
                }
            }

            public void Dispose() {
                _values = null;
            }

            public bool HasNext() => MoveNext();
            public bool MoveNext() {
                _position++;
                return (_position < _values.Length);
            }

            public void Reset() {
                _position = -1;
            }
        }
    }
}
