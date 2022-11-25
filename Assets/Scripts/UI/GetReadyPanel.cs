using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;

public class GetReadyPanel : PartyPanel
{
    [SerializeField] private StartRhythmGameButton _startRhythmGameButton;

    public void ShowGoButton()
    {
        _startRhythmGameButton.gameObject.SetActive(true);
    }
}
