namespace acg.ringarray.svc.Interfaces
{
    public interface IIterator<out T>
    {
        bool HasNext();
        T Next();
        void Reset();
    }
}