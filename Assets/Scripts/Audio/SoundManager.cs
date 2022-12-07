using System.Collections.Generic;
using Data;
using Pools;
using UnityEngine;
using VContainer;

namespace Audio
{
    public class SoundManager : VContainer.Unity.IFixedTickable
    {
        private List<SoundEntity> _activeSounds;

        private readonly AudioSourcePool _audioSourcePool;

        private readonly Dictionary<SoundType, float> _volumes = new()
        {
            { SoundType.Music, 1f }
        };

        SoundManager ()
        {
            _audioSourcePool = new AudioSourcePool(1);
            _activeSounds = new List<SoundEntity>();
        }

        public SoundEntity Play (AudioClip clip, SoundType type)
        {
            var source = _audioSourcePool.Take();
            source.volume = _volumes[type];
            source.clip = clip;
            source.Play();
            var entity = new SoundEntity(source);
            _activeSounds.Add(entity);
            return entity;
        }

        public SoundEntity CreateSound(AudioClip clip, SoundType type, AudioSource source)
        {
            source.volume = _volumes[type];
            source.clip = clip;
            var entity = new SoundEntity(source);
            return entity;
        }

        public void FixedTick()
        {
            foreach (SoundEntity entity in _activeSounds)
            {
                if (!entity.IsPaused && !entity.IsPlaying)
                {
                    _audioSourcePool.Return(entity);
                    _activeSounds.Remove(entity);
                }
            }
        }
    }
}