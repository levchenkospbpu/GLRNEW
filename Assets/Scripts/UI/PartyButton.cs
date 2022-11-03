using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

public class PartyButton : MonoBehaviour
{
    [Inject]
    private UIProvider _uiProvider;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(ShowPartyPanel);
    }

    private void ShowPartyPanel()
    {
        _uiProvider.Show(typeof(PartyPanel), transform.parent);
    }
}
