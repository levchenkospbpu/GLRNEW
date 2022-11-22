using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactersData
{
    private CharactersDataConfig _charactersDataConfig;

    public CharactersData(CharactersDataConfig charactersDataConfig)
    {
        _charactersDataConfig = charactersDataConfig;
    }

    public Character[] Characters { get { return _charactersDataConfig.Characters; } }
}
