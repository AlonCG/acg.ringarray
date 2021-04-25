using acg.ringarray.svc.Interfaces;

namespace acg.ringarray.svc
{
    public class IntRingArray : RingArray<int>
    {
        public IntRingArray(int[] values, int ringSize) : base(values, ringSize) { }
    }

    public class LongRingArray : RingArray<long>
    {
        public LongRingArray(long[] values, int ringSize) : base(values, ringSize) { }
    }

    public class StringRingArray : RingArray<string>
    {
        public StringRingArray(string[] values, int ringSize) : base(values, ringSize) { }
    }


    // Note: For sure we don't need to use as enumerator here, 
    // we could just go through the array itself. This is so
    // I can test some experiential functionality and play a bit
    // with the "metal" of programming as compared to the "glass"
    public abstract class RingArray<T> : IRingArray<T>
    {
        private readonly IIterator<T> _iterator;
        private readonly T[] _initialValues;

        protected RingArray(T[] values, int ringSize)
        {
            _initialValues = values;
            // pass the array into an enumerator so we force a pattern
            var iterator = new SimpleIterator<T>(values);
            _iterator = iterator;

            RingSize = ringSize; 
        }

        public int RingSize { get; }

        public T[] FillRingArray()
        {
            // ?? shortcut exit when the ringarray size is equal to the values
            if (_initialValues.Length == RingSize) { 
                return _initialValues;  // << % of occurrance, waste/usefgul?
            }

            var ring = new T[RingSize];
            var index = 0;
            while (_iterator.HasNext()) {
                ring[index] = _iterator.Next();
                index = (index + 1) % RingSize;
            }
            // make sure the values are ordered properly
            var orderedRing = new T[RingSize];
            for (var idx = 0; idx < RingSize; idx++) {
                orderedRing[idx] = ring[index];
                index = (index + 1) % RingSize;
            }
            return orderedRing;
        }
    }
}
