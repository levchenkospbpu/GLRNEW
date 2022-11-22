using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.LookDev;
using VContainer;
using VContainer.Unity;
using IInitializable = VContainer.Unity.IInitializable;

public class Party : IStartable, IInitializable
{
    public event System.Action ChangeableCharacterIDChanged;
    public int CurrentBassID { get; private set; }
    public int CurrentDrumsID { get; private set; }
    public CharacterSlotType ChangeableSlotType { get; private set; }
    public int ChangeableCharacterID { get; private set; }
    public CharactersData CharactersData { get; private set; }
    private IActionRegister _actionRegister;

    public Party(CharactersData charactersData, IActionRegister actionRegister)
    {
        CharactersData = charactersData;
        _actionRegister = actionRegister;
    }

    public void Start()
    {
        _actionRegister.Register(ActionType.SetChangeableSlotType, SetChangeableSlotType);
        _actionRegister.Register(ActionType.SetChangeableCharacterID, SetChangeableCharacterID);
        _actionRegister.Register(ActionType.SetPartyCurrentIDs, SetCurrentIDs);
        _actionRegister.Register(ActionType.SaveParty, Save);
    }

    public void Initialize()
    {
        CurrentBassID = PlayerPrefs.GetInt(PlayerPrefsKeys.BassCharacterID, -1);
        CurrentDrumsID = PlayerPrefs.GetInt(PlayerPrefsKeys.DrumsCharacterID, -1);
    }

    private void SetChangeableSlotType(DataProvider dataProvider)
    {
        ChangeableSlotType = dataProvider.GetData<CharacterSlotType>();
        switch (ChangeableSlotType)
        {
            case CharacterSlotType.Bass:
                ChangeableCharacterID = CurrentBassID;
                break;
            case CharacterSlotType.Drums:
                ChangeableCharacterID = CurrentDrumsID;
                break;
            default:
                break;
        }
    }

    private void SetChangeableCharacterID(DataProvider dataProvider)
    {
        ChangeableCharacterID = dataProvider.GetData<int>();
        ChangeableCharacterIDChanged?.Invoke();
    }

    private void SetCurrentIDs(DataProvider dataProvider)
    {
        switch (ChangeableSlotType)
        {
            case CharacterSlotType.Bass:
                SetCurrentBassID();
                break;
            case CharacterSlotType.Drums:
                SetCurrentDrumsID();
                break;
            default:
                break;
        }
    }

    private void SetCurrentBassID()
    {
        CurrentBassID = ChangeableCharacterID;
        if (CurrentDrumsID == CurrentBassID)
        {
            CurrentDrumsID = -1;
        }
    }

    private void SetCurrentDrumsID()
    {
        CurrentDrumsID = ChangeableCharacterID;
        if (CurrentBassID == CurrentDrumsID)
        {
            CurrentBassID = -1;
        }
    }

    private void Save(DataProvider dataProvider)
    {
        PlayerPrefs.SetInt(PlayerPrefsKeys.BassCharacterID, CurrentBassID);
        PlayerPrefs.SetInt(PlayerPrefsKeys.DrumsCharacterID, CurrentDrumsID);
    }
}
