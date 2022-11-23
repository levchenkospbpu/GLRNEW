using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

public class LocationPartyButton : MonoBehaviour
{
    [SerializeField] private LocationPanel _locationPanel;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(ShowPartyPanel);
    }

    private void ShowPartyPanel()
    {
        PartyPanel partyPanel = _locationPanel.UIProvider.Show(typeof(PartyPanel), GameObject.FindGameObjectWithTag("MainCanvas").transform) as PartyPanel;
        partyPanel.SetPrevPanelType(typeof(LocationPanel));
    }
}