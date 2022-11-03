using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Appearance : MonoBehaviour
{
    private CustomizationData _customizationData;
    private Material _hairMaterial;
    private Material _skinMaterial;
    private Material _topMaterial;
    private Material _bottomMaterial;
    private Material _shoesMaterial;

    public void SetHairColor(int hairColorID)
    {
        //_hairMaterial.color = _customizationData.GetHairColor(hairColorID);
        Debug.Log(_customizationData.GetHairColor(hairColorID));
    }

    public void SetSkinColor(int skinColorID)
    {
        //_skinMaterial.color = _customizationData.GetSkinColor(skinColorID);
        Debug.Log(_customizationData.GetHairColor(skinColorID));
    }

    public void SetTopColor(int topColorID)
    {
        //_topMaterial.color = _customizationData.GetClothColor(topColorID);
        Debug.Log(_customizationData.GetHairColor(topColorID));
    }

    public void SetBottomColor(int bottomColorID)
    {
        //_bottomMaterial.color = _customizationData.GetClothColor(bottomColorID);
        Debug.Log(_customizationData.GetHairColor(bottomColorID));
    }

    public void SetShoesColor(int shoesColorID)
    {
        //_shoesMaterial.color = _customizationData.GetClothColor(shoesColorID);
        Debug.Log(_customizationData.GetHairColor(shoesColorID));
    }
}
