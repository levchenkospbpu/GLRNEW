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

    public Hair GetHair(int index)
    {
        return _customizationDataConfig.Hairs[index];
    }

    public Color GetHairColor(int index)
    {
        return _customizationDataConfig.HairColors[index];
    }

    public Color GetSkinColor(int index)
    {
        return _customizationDataConfig.SkinColors[index];
    }
}
