using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewCustomizationDataConfig", menuName = "Data/CustomizationDataConfig")]
public class CustomizationDataConfig : ScriptableObject
{
    [field: SerializeField] public Material[] HairMaterals { get; private set; }
    [field: SerializeField] public Material[] SkinMaterials { get; private set; }
    [field: SerializeField] public Material[] ClothesMaterials { get; private set; }
}
