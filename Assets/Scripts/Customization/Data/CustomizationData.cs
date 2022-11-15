using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomizationData
{
    private CustomizationDataConfig _customizationDataConfig;

    public CustomizationData(CustomizationDataConfig customizationDataConfig)
    {
        _customizationDataConfig = customizationDataConfig;
    }
    
    public Material[] HairMaterials { get { return _customizationDataConfig.HairMaterals; } }
    public Material[] SkinMaterials { get { return _customizationDataConfig.SkinMaterials; } }
    public Material[] ClothesMaterials { get { return _customizationDataConfig.ClothesMaterials; } }
}
