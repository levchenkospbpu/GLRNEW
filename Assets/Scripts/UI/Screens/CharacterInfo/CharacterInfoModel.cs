using Common.MVP;
using Data;

namespace UI.Screens.CharacterInfo
{
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
}
