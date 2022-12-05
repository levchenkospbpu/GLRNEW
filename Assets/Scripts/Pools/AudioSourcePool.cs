using System.Collections.Generic;
using UnityEngine;

namespace Pools
{
    public class AudioSourcePool : IPoolBase<AudioSource>
    {
        private readonly Stack<AudioSource> _stack = new();
        
        private Transform _rootObject;
        private readonly List<GameObject> _audioSources = new();

        public AudioSourcePool(int capacity)
        {
            _rootObject = new GameObject("AudioSourcesPool").transform;

            for (var i = 0; i < capacity; i++)
            {
                _stack.Push(CreateAudioSource());
            }
        }
        
        public AudioSource Take()
        {
            if (!_stack.TryPop(out var obj))
            {
                return CreateAudioSource();
            }

            return obj;
        }

        public void Return(AudioSource obj)
        {
            _stack.Push(obj);
        }

        private AudioSource CreateAudioSource()
        {
            var obj = new GameObject("AudioSource");
            obj.transform.parent = _rootObject;
            _audioSources.Add(obj);
            var script = obj.AddComponent<AudioSource>();
            return script;
        }
    }
}