using System;
using acg.ringarray.svc.Interfaces;

namespace acg.ringarray.svc
{
    public class SimpleIterator<T> : IIterator<T>
    {
        private readonly T[] _values;
        private int _position = -1;

        public SimpleIterator(T[] values) { _values = values; }

        public bool HasNext()
        {
            _position++;
            return (_position < _values.Length);
        }

        public T Next()
        {
            try {
                return _values[_position];
            } catch (IndexOutOfRangeException) {
                throw new InvalidOperationException();
            }
        }

        public void Reset()
        {
            _position = -1;
        }
    }
}
