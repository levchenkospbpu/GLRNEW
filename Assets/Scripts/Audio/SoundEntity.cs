using UnityEngine;

namespace Audio
{
    public class SoundEntity
    {
        public static implicit operator AudioSource(SoundEntity entity) => entity._audioSource;

        public bool IsPaused { get; private set; }
        public bool IsPlaying => _audioSource.isPlaying;
    
        public readonly bool IsFromPool;

        private readonly AudioSource _audioSource;

        public SoundEntity(AudioSource audioSource, bool isFromPool = false)
        {
            _audioSource = audioSource;
            IsFromPool = isFromPool;
            IsPaused = false;
        }

        public SoundEntity SetClip(AudioClip clip)
        {
            _audioSource.clip = clip;
            return this;
        }

        public SoundEntity SetVolume(float volume)
        {
            _audioSource.volume = volume;
            return this;
        }

        public SoundEntity SetLoop(bool isLoop)
        {
            _audioSource.loop = isLoop;
            return this;
        }

        public SoundEntity Play()
        {
            _audioSource.Play();
            return this;
        }

        public SoundEntity Pause()
        {
            _audioSource.Pause();
            IsPaused = true;
            return this;
        }

        public SoundEntity UnPause()
        {
            _audioSource.UnPause();
            IsPaused = false;
            return this;
        }

        public SoundEntity Stop()
        {
            _audioSource.Stop();
            return this;
        }
    }
}
