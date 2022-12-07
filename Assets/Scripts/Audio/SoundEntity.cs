using Pools;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SoundEntity
{
    public static implicit operator AudioSource(SoundEntity entity) => entity._audioSource;

    public bool IsPaused { get; private set; }
    public bool IsPlaying { get { return _audioSource.isPlaying; } private set { } }

    public readonly AudioSource _audioSource;

    public SoundEntity(AudioSource audioSource)
    {
        _audioSource = audioSource;
        IsPaused = false;
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
