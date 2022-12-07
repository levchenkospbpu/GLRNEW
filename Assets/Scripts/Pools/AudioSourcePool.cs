using UnityEngine;

namespace Pools
{
    public class AudioSourcePool : IPool<AudioSource>
    {
        private readonly Pool<AudioSource> _pool;

        public AudioSourcePool()
        {
            var root = new GameObject("AudioSourcesPool").transform;
            _pool = new Pool<AudioSource>(() =>
            {
                var obj = new GameObject("AudioSource");
                obj.transform.SetParent(root);

                var audioSource = obj.AddComponent<AudioSource>();
                return audioSource;
            }, 10);
        }
        
        public AudioSource Take()
        {
            return _pool.Take();
        }

        public void Return(AudioSource obj)
        {
            _pool.Return(obj);
        }
    }
}