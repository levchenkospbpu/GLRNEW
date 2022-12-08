using System.Collections.Generic;
using Data;
using Pools;
using UnityEngine;
using VContainer.Unity;

namespace Audio
{
    public class SoundManager : ITickable
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

        public void Tick()
        {
            foreach (var entity in _activeSounds)
            {
                if (entity.BindObject != null)
                {
                    entity.SetPosition(entity.BindObject.position);
                }

                if (!entity.IsPaused && !entity.IsPlaying)
                {
                    if (entity.IsFromPool) _audioSourcePool.Return(entity);
                    _activeSounds.Remove(entity);
                }
            }
        }
    }
}