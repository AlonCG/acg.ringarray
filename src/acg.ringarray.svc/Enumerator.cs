using System;
using System.Collections;

namespace acg.ringarray.svc
{
    public class Enumerator : IEnumerator
    {
        public int[] Values;
        private int _position = -1;

        public Enumerator(int[] values) { Values = values; }

        public object Current {
            get {
                try {
                    return Values[_position];
                } catch (IndexOutOfRangeException) {
                    throw new InvalidOperationException();
                }
            }
        }

        public bool MoveNext()
        {
            _position++;
            return (_position < Values.Length);
        }

        public void Reset()
        {
            _position = -1;
        }

        // IDisposable issue : CA1816
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing) {
                if (Values != null) {
                    Values = null;
                    Reset();
                }
            }
        }
    }
}
