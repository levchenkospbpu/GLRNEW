namespace Pools
{
    public interface IPoolBase<T>
    {
        T Take();
        void Return(T obj);
    }
}