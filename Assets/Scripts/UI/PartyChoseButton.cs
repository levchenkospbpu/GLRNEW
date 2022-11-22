using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PartyChoseButton : MonoBehaviour
{
    [SerializeField] private PartyPanel _partyPanel;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(SetCurrentIDs);
        GetComponent<Button>().onClick.AddListener(UpdatePartySlotsUI);
        GetComponent<Button>().onClick.AddListener(ShowOther);
        GetComponent<Button>().onClick.AddListener(HidePanel);
    }

    private void SetCurrentIDs()
    {
        _partyPanel.ActionCaller.Raise(ActionType.SetPartyCurrentIDs, new DataProvider());
    }

    private void UpdatePartySlotsUI()
    {
        _partyPanel.UpdatePartySlotsUI();
    }

    private void HidePanel()
    {
        _partyPanel.HideCharacterInfo();
    }

    private void ShowOther()
    {
        _partyPanel.ShowObjects();
    }
}
