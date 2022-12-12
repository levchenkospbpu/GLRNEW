using Common.MVP;
using Data;
using System.Collections.Generic;

namespace UI.Screens.PartyPanel
{
    public class PartyPanelModel : BaseModel
    {
        public readonly Character[] Characters;
        public Dictionary<PartySlotType, int> PartyIDs;

        public PartyPanelModel(Character[] characters, Dictionary<PartySlotType, int> partyIDs)
        {
            Characters = characters;
            PartyIDs = partyIDs;
        }
    }
}