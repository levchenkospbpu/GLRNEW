using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

public class CharacterButton : UIElement
{
    [Inject]
    private IActionCaller _actionCaller;
    [Inject]
    private Party _party;
    private int _id;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(SetChangeableCharacterID);
    }

    public void SetID(int id)
    {
        _id = id;
    }

    public void Initialize()
    {
        GetComponent<Image>().sprite = _party.CharactersData.Characters[_id].Icon;
    }

    private void SetChangeableCharacterID()
    {
        _actionCaller.Raise(ActionType.SetChangeableCharacterID, new DataProvider(_id));
    }
}
