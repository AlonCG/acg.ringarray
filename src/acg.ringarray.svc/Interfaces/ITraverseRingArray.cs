namespace acg.ringarray.svc.Interfaces
{
    public interface ITraverseRingArray<T>
    {
        T Traverse(int steps);
        T Traverse(int steps, int startPosition);
        T Traverse(T[] ringArray, int steps, int startPosition);
    }
}