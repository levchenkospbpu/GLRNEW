using Common.MVP;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInfoModel : BaseModel
{
    public readonly Character[] Characters;

    public CharacterInfoModel(Character[] characters)
    {
        Characters = characters;
    }
}
