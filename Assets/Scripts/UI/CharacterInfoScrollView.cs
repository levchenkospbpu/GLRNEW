using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInfoScrollView : MonoBehaviour
{
    [SerializeField] private PartyPanel _partyPanel;

    public void Clear()
    {
        foreach (Transform child in GetComponentInChildren<CharacterInfoContent>().transform)
        {
            Destroy(child.gameObject);
        }
    }

    public void LoadCharacterButtons()
    {
        Clear();
        for (int i = 0; i < _partyPanel.Party.CharactersData.Characters.Length; i++)
        {
            CharacterButton characterButton = _partyPanel.UIProvider.Instantiate(typeof(CharacterButton), GetComponentInChildren<CharacterInfoContent>().gameObject.transform) as CharacterButton;
            characterButton.SetID(i);
            characterButton.Initialize();
        }
    }
}
