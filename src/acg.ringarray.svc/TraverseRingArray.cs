using acg.ringarray.svc.Interfaces;

namespace acg.ringarray.svc
{

    public class TraverseIntRingArray : TraverseRingArray<int>
    {
        public TraverseIntRingArray(IRingArray<int> ringArray) : base(ringArray) { }
    } 

    public abstract class TraverseRingArray<T> : ITraverseRingArray<T>
    {
        private readonly IRingArray<T> _ringArray;

        protected TraverseRingArray(IRingArray<T> ringArray)
        {
            _ringArray = ringArray;
        }

        public T Traverse(int steps) => Traverse(steps, 0);
        public T Traverse(int steps, int startPosition) =>
            Traverse(_ringArray.FillRingArray(), steps, startPosition);
        public T Traverse(T[] ringArray, int steps, int startPosition)
        {
            var index = (startPosition + steps) % _ringArray.RingSize;
            return ringArray[index];
        }
    }
}
