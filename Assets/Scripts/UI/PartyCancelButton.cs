using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PartyCancelButton : MonoBehaviour
{
    [SerializeField] private PartyPanel _partyPanel;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(ResetIDs);
        GetComponent<Button>().onClick.AddListener(OpenPrevPanel);
        GetComponent<Button>().onClick.AddListener(StopSong);
    }

    private void ResetIDs()
    {
        _partyPanel.ActionCaller.Raise(ActionType.ResetIDs, new DataProvider());
    }

    private void OpenPrevPanel()
    {
        _partyPanel.UIProvider.Show(_partyPanel.GetPrevPanelType(), GameObject.FindGameObjectWithTag("MainCanvas").transform);
    }

    private void StopSong()
    {
        AudioManager.Instance.Stop();
    }
}
