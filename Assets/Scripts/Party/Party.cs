using System.Collections.Generic;
using Data;
using UnityEngine;
using IInitializable = VContainer.Unity.IInitializable;

namespace Party
{
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
            PartyIDs[PartySlotType.Drums] = PlayerPrefs.GetInt(PlayerPrefsKeys.DrumsCharacterID, -1);
            PartyIDs[PartySlotType.Guitar] = PlayerPrefs.GetInt(PlayerPrefsKeys.GuitarCharacterID, -1);
            PartyIDs[PartySlotType.Bass] = PlayerPrefs.GetInt(PlayerPrefsKeys.BassCharacterID, -1);
        }

        public void Save()
        {
            PlayerPrefs.SetInt(PlayerPrefsKeys.DrumsCharacterID, PartyIDs[PartySlotType.Drums]);
            PlayerPrefs.SetInt(PlayerPrefsKeys.GuitarCharacterID, PartyIDs[PartySlotType.Guitar]);
            PlayerPrefs.SetInt(PlayerPrefsKeys.BassCharacterID, PartyIDs[PartySlotType.Bass]);
            PlayerPrefs.Save();
        }

        public void SetID(PartySlotType slotType, int id)
        {
            switch(slotType)
            {
                case PartySlotType.Drums:
                    PartyIDs[PartySlotType.Drums] = id;
                    if (PartyIDs[PartySlotType.Guitar] == id) PartyIDs[PartySlotType.Guitar] = -1;
                    if (PartyIDs[PartySlotType.Bass] == id) PartyIDs[PartySlotType.Bass] = -1;
                    return;
                case PartySlotType.Guitar:
                    PartyIDs[PartySlotType.Guitar] = id;
                    if (PartyIDs[PartySlotType.Drums] == id) PartyIDs[PartySlotType.Drums] = -1;
                    if (PartyIDs[PartySlotType.Bass] == id) PartyIDs[PartySlotType.Bass] = -1;
                    return;
                case PartySlotType.Bass:
                    PartyIDs[PartySlotType.Bass] = id;
                    if (PartyIDs[PartySlotType.Drums] == id) PartyIDs[PartySlotType.Drums] = -1;
                    if (PartyIDs[PartySlotType.Guitar] == id) PartyIDs[PartySlotType.Guitar] = -1;
                    return;
                default:
                    return;
            }
        }
    }
}
