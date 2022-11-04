using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewCustomizationDataConfig", menuName = "Data/CustomizationDataConfig")]
public class CustomizationDataConfig : ScriptableObject
{
    [field: SerializeField] public Hair[] Hairs { get; private set; }
    [field: SerializeField] public Color[] HairColors { get; private set; }
    [field: SerializeField] public Color[] SkinColors { get; private set; }
}

[Serializable]
public struct Hair
{
    public SkinnedMeshRenderer skinnedMeshRenderer;
    public GameObject rootBone;
}
