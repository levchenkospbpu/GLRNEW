using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;
using VContainer;

public class RhythmGameZone : MonoBehaviour
{
    [Inject]
    private UIProvider _uiProvider;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GetReadyPanel partyPanel = _uiProvider.Show(typeof(GetReadyPanel), GameObject.FindGameObjectWithTag("MainCanvas").transform) as GetReadyPanel;
            partyPanel.SetPrevPanelType(typeof(LocationPanel));
        }
    }
}
