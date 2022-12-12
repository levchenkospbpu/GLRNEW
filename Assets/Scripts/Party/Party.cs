using Data;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.LookDev;
using VContainer;
using VContainer.Unity;
using IInitializable = VContainer.Unity.IInitializable;

public class Party : IInitializable
{
    public Dictionary<PartySlotType, int> PartyIDs { get; private set; } = new ();

    public CharactersDataConfig CharactersDataConfig { get; private set; }

    public Party(CharactersDataConfig charactersDataConfig)
    {
        CharactersDataConfig = charactersDataConfig;
    }

    public void Initialize()
    {
        PartyIDs.Add(PartySlotType.Drums, PlayerPrefs.GetInt(PlayerPrefsKeys.DrumsCharacterID, -1));
        PartyIDs.Add(PartySlotType.Guitar, PlayerPrefs.GetInt(PlayerPrefsKeys.GuitarCharacterID, -1));
        PartyIDs.Add(PartySlotType.Bass, PlayerPrefs.GetInt(PlayerPrefsKeys.BassCharacterID, -1));
    }

    public void Save()
    {
        PlayerPrefs.SetInt(PlayerPrefsKeys.DrumsCharacterID, PartyIDs[PartySlotType.Drums]);
        PlayerPrefs.SetInt(PlayerPrefsKeys.GuitarCharacterID, PartyIDs[PartySlotType.Guitar]);
        PlayerPrefs.SetInt(PlayerPrefsKeys.BassCharacterID, PartyIDs[PartySlotType.Bass]);
        PlayerPrefs.Save();
    }

    public void SetCurrentDrumsID(int id)
    {
        PartyIDs[PartySlotType.Drums] = id;
    }

    public void SetCurrentGuitarID(int id)
    {
        PartyIDs[PartySlotType.Guitar] = id;
    }

    public void SetCurrentBassID(int id)
    {
        PartyIDs[PartySlotType.Bass] = id;
    }
}
