using System.Collections.Generic;
using Data;
using Pools;
using UnityEngine;
using VContainer;

namespace Audio
{
    public class SoundManager
    {
        [Inject] private readonly AudioSourcePool _audioSourcePool;

        private readonly Dictionary<SoundType, float> _volumes = new()
        {
            { SoundType.Music, 1f }
        };

        public void Play(AudioClip clip, SoundType type)
        {
            var source = _audioSourcePool.Take();
            source.volume = _volumes[type];
            source.clip = clip;
        }

        public void Stop(AudioClip clip)
        {
            
        }
    }
}