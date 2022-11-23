using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomePartyButton : MonoBehaviour
{
    [SerializeField] private MainPanel _mainPanel;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(ShowPartyPanel);
    }

    private void ShowPartyPanel()
    {
        PartyPanel partyPanel = _mainPanel.UIProvider.Show(typeof(PartyPanel), GameObject.FindGameObjectWithTag("MainCanvas").transform) as PartyPanel;
        partyPanel.SetPrevPanelType(typeof(MainPanel));
    }
}
