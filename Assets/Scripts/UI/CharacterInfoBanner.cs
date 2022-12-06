using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterInfoBanner : MonoBehaviour
{
    [SerializeField] private PartyPanel _partyPanel;

    private void OnEnable()
    {
        _partyPanel.Party.ChangeableCharacterIDChanged += UpdateSprite;
    }

    private void OnDisable()
    {
        _partyPanel.Party.ChangeableCharacterIDChanged -= UpdateSprite;
    }

    private void Start()
    {
        UpdateSprite();
    }

    private void UpdateSprite()
    {
        int changeableCharacterID = _partyPanel.Party.ChangeableCharacterID;
        if (changeableCharacterID != -1)
        {
            GetComponent<Image>().sprite = _partyPanel.Party.CharactersData.Characters[changeableCharacterID].Banner;
        }
    }
}
