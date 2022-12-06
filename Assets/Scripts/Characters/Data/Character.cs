using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewCharacter", menuName = "Data/Character")]
public class Character : ScriptableObject
{
    [field: SerializeField] public string Name { get; private set; }
    [field: SerializeField] public int HP { get; private set; }
    [field: SerializeField] public int Atk { get; private set; }
    [field: SerializeField] public int Def { get; private set; }
    [field: SerializeField] public AudioClip[] Songs { get; private set; }
    [field: SerializeField] public Sprite Banner { get; private set; }
    [field: SerializeField] public Sprite Icon { get; private set; }
}
