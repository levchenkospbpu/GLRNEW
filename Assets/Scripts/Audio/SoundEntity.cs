using UnityEngine;

namespace Audio
{
    public class SoundEntity
    {
        public static implicit operator AudioSource(SoundEntity entity) => entity._audioSource;

        public readonly bool IsFromPool;

        private readonly Transform _transform;
        private readonly AudioSource _audioSource;

        public SoundEntity(AudioSource audioSource, bool isFromPool = false)
        {
            _audioSource = audioSource;
            _transform = _audioSource.transform;
            
            IsFromPool = isFromPool;
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

        public SoundEntity SetPosition(Vector3 position)
        {
            _transform.position = position;
            return this;
        }

        #region BIND_TO_OBJECT

        public Transform BindObject { get; private set; }
        public SoundEntity BindTo(Transform @object)
        {
            BindObject = @object;
            return this;
        }

        #endregion

        #region PLAYING
        
        public bool IsPlaying => _audioSource.isPlaying;
        public SoundEntity Play()
        {
            _audioSource.Play();
            return this;
        }
        
        public SoundEntity Stop()
        {
            _audioSource.Stop();
            return this;
        }
        
        #endregion

        #region PAUSE

        public bool IsPaused { get; private set; }
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

        #endregion
    }
}
