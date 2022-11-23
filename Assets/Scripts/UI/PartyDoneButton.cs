using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

public class PartyDoneButton : MonoBehaviour
{
    [SerializeField] private PartyPanel _partyPanel;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(Save);
        GetComponent<Button>().onClick.AddListener(OpenLocationPanel);
    }

    private void Save()
    {
        _partyPanel.ActionCaller.Raise(ActionType.SaveParty, new DataProvider());
    }

    private void OpenLocationPanel()
    {
        _partyPanel.UIProvider.Show(_partyPanel.GetPrevPanelType(), GameObject.FindGameObjectWithTag("MainCanvas").transform);
    }
}
