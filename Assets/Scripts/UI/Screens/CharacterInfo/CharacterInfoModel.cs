using Common.MVP;
using Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInfoModel : BaseModel
{
    public readonly Character[] Characters;
    public readonly PartySlotType ChangableSlot;

    public CharacterInfoModel(Character[] characters, PartySlotType partySlotType)
    {
        Characters = characters;
        ChangableSlot = partySlotType;
    }
}
