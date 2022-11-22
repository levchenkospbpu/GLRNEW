using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewCharactersDataConfig", menuName = "Data/CharactersDataConfig")]
public class CharactersDataConfig : ScriptableObject
{
    [field: SerializeField] public Character[] Characters { get; private set; }
}
