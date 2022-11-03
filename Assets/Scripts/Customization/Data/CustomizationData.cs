using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomizationData
{
    private CustomizationDataConfig _customizationDataConfig;

    public Color GetHairColor(int index)
    {
        return _customizationDataConfig.HairColors[index];
    }

    public Color GetSkinColor(int index)
    {
        return _customizationDataConfig.SkinColors[index];
    }

    public Color GetClothColor(int index)
    {
        return _customizationDataConfig.ClothColors[index];
    }
}
