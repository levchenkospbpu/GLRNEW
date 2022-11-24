using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SongButton : UIElement
{
    private AudioClip _audioClip;
    private StopSongButton _stopSongButton;

    private void Start()
    {
        _stopSongButton = GetComponentInChildren<StopSongButton>();
        HideStopButton();
        GetComponent<Button>().onClick.AddListener(PlaySong);
        GetComponent<Button>().onClick.AddListener(ShowStopButton);
    }

    private void PlaySong()
    {
        if (_audioClip == null)
        {
            return;
        }
        AudioManager.Instance.Play(_audioClip);
    }

    public void SetSong(AudioClip audioClip)
    {
        _audioClip = audioClip;
        GetComponentInChildren<TextMeshProUGUI>().text = _audioClip.name;
    }

    public AudioClip GetSong()
    {
        return _audioClip;
    }

    private void ShowStopButton()
    {
        _stopSongButton.gameObject.SetActive(true);
    }

    private void HideStopButton()
    {
        _stopSongButton.gameObject.SetActive(false);
    }
}
