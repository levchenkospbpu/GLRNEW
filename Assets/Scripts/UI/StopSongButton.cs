using System.Collections;
using System.Collections.Generic;
using Audio;
using UnityEngine;
using UnityEngine.UI;

public class StopSongButton : MonoBehaviour
{
    [SerializeField] private SongButton _songButton;

    private void OnEnable()
    {
        AudioManager.Instance.SongStarted += AudioManager_OnSongStarted;
    }

    private void OnDisable()
    {
        AudioManager.Instance.SongStarted -= AudioManager_OnSongStarted;
    }

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(StopSong);
        GetComponent<Button>().onClick.AddListener(Hide);
    }

    private void StopSong()
    {
        AudioManager.Instance.Stop();
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }

    private void AudioManager_OnSongStarted()
    {
        if (AudioManager.Instance.GetAudioClip() != _songButton.GetSong())
        {
            Hide();
        }
    }
}
