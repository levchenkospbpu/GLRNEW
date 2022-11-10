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
    
    public Color[] HairColors { get { return _customizationDataConfig.HairColors; } }
    public Color[] SkinColors { get { return _customizationDataConfig.SkinColors; } }
    public Material HairMaterial { get { return _customizationDataConfig.HairMaterial; } }
    public Material SkinMaterial { get { return _customizationDataConfig.SkinMaterial; } }
}
