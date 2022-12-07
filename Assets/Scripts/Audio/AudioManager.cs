using System;
using UnityEngine;

namespace Audio
{
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager Instance { get; private set; }
        public event Action SongStarted;

        private AudioSource _audioSource;

        private void Start()
        {
            _audioSource = GetComponent<AudioSource>();
            DontDestroyOnLoad(gameObject);
        }

        public void Play(AudioClip audioClip)
        {
            _audioSource.clip = audioClip;
            _audioSource.Play();
            SongStarted?.Invoke();
        }

        public void Stop()
        {
            _audioSource.Stop();
        }

        public AudioClip GetAudioClip()
        {
            return _audioSource.clip;
        }
    }
}
