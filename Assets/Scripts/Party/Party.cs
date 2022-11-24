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
    public int TempBassID { get; private set; }
    public int TempDrumsID { get; private set; }
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
        _actionRegister.Register(ActionType.ResetIDs, ResetIDs);
    }

    public void Initialize()
    {
        CurrentBassID = PlayerPrefs.GetInt(PlayerPrefsKeys.BassCharacterID, -1);
        CurrentDrumsID = PlayerPrefs.GetInt(PlayerPrefsKeys.DrumsCharacterID, -1);
        TempBassID = CurrentBassID;
        TempDrumsID = CurrentDrumsID;
    }

    private void SetChangeableSlotType(DataProvider dataProvider)
    {
        ChangeableSlotType = dataProvider.GetData<CharacterSlotType>();
        switch (ChangeableSlotType)
        {
            case CharacterSlotType.Bass:
                ChangeableCharacterID = TempBassID;
                break;
            case CharacterSlotType.Drums:
                ChangeableCharacterID = TempDrumsID;
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
        TempBassID = ChangeableCharacterID;
        if (TempDrumsID == TempBassID)
        {
            TempDrumsID = -1;
        }
    }

    private void SetCurrentDrumsID()
    {
        TempDrumsID = ChangeableCharacterID;
        if (TempBassID == TempDrumsID)
        {
            TempBassID = -1;
        }
    }

    private void Save(DataProvider dataProvider)
    {
        CurrentBassID = TempBassID;
        CurrentDrumsID = TempDrumsID;
        PlayerPrefs.SetInt(PlayerPrefsKeys.BassCharacterID, TempBassID);
        PlayerPrefs.SetInt(PlayerPrefsKeys.DrumsCharacterID, TempDrumsID);
    }

    private void ResetIDs(DataProvider dataProvider)
    {
        TempBassID = CurrentBassID;
        TempDrumsID = CurrentDrumsID;
    }
}
