namespace Pools
{
    public interface IPool<T>
    {
        T Take();
        void Return(T obj);
    }
}