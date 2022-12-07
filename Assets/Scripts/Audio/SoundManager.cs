using System.Collections.Generic;
using System.Linq;
using Data;
using Pools;
using UnityEngine;

namespace Audio
{
    public class SoundManager : VContainer.Unity.IFixedTickable
    {
        private readonly List<SoundEntity> _activeSounds = new();
        private readonly AudioSourcePool _audioSourcePool = new();

        private readonly Dictionary<SoundType, float> _volumes = new()
        {
            { SoundType.Music, 1f }
        };

        public SoundEntity Create(AudioClip clip, SoundType type)
        {
            var entity = new SoundEntity(_audioSourcePool.Take(), true)
                .SetClip(clip)
                .SetVolume(_volumes[type]);
            
            _activeSounds.Add(entity);
            return entity;
        }

        public SoundEntity Create(AudioClip clip, SoundType type, AudioSource source)
        {
            var entity = new SoundEntity(source)
                .SetClip(clip)
                .SetVolume(_volumes[type]);
            
            _activeSounds.Add(entity);
            return entity;
        }

        public void FixedTick()
        {
            foreach (var entity in _activeSounds.Where(entity => !entity.IsPaused && !entity.IsPlaying))
            {
                if(entity.IsFromPool) _audioSourcePool.Return(entity);
                _activeSounds.Remove(entity);
            }
        }
    }
}