using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;

public class SongsPanel : UIElement
{
    [Inject]
    private Party _party;
    [Inject]
    private UIProvider _uiProvider;

    public void LoadSongButtons()
    {
        Clear();
        if (_party?.TempBassID != -1)
        {
            foreach (AudioClip song in _party.CharactersData.Characters[_party.TempBassID].Songs)
            {
                SongButton songButton = _uiProvider.Instantiate(typeof(SongButton), transform) as SongButton;
                songButton.SetSong(song);
            }
        }
        if (_party?.TempDrumsID != -1)
        {
            foreach (AudioClip song in _party.CharactersData.Characters[_party.TempDrumsID].Songs)
            {
                SongButton songButton = _uiProvider.Instantiate(typeof(SongButton), transform) as SongButton;
                songButton.SetSong(song);
            }
        }
    }

    public void Clear()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }
}
