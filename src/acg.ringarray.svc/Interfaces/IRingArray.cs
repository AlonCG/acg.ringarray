namespace acg.ringarray.svc.Interfaces
{
    public interface IRingArray<out T>
    {
        int RingSize { get; }
        T[] FillRingArray();
    }
}