using System;
using System.Collections.Generic;

namespace Pools
{
    public class Pool<T> : IPool<T>
    {
        private readonly Stack<T> _stack = new();
        private readonly Func<T> _generator;

        public Pool(Func<T> generator, int capacity)
        {
            _generator = generator;
            for (var i = 0; i < capacity; i++)
            {
                _stack.Push(generator.Invoke());
            }
        }
        
        public T Take()
        {
            return _stack.Count > 0 ? _stack.Pop() : _generator.Invoke();
        }

        public void Return(T obj)
        {
            _stack.Push(obj);
        }
    }
}