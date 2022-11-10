using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;
using static UnityEngine.GraphicsBuffer;

public class Appearance
{
    public CustomizationData CustomizationData { get; private set; }
    public Hair[] Hairs { get; private set; }
    public int CurrentHairID { get; private set; }

    private GameObject _player;

    public Appearance(CustomizationData customizationData)
    {
        CustomizationData = customizationData;
    }

    public void Initialize()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        Hairs = _player.GetComponentsInChildren<Hair>();
        foreach (Hair hair in Hairs)
        {
            hair.gameObject.SetActive(false);
        }
        CurrentHairID = PlayerPrefs.GetInt(PlayerPrefsKeys.AppearanceHairID, 0);
        SetHair(CurrentHairID);
    }
 
    public void SetHair(int hairID)
    {
        if (hairID < 0 || hairID >= Hairs.Length) return;
        Hairs[CurrentHairID].gameObject.SetActive(false);
        Hairs[hairID].gameObject.SetActive(true);
        CurrentHairID = hairID;
    }

    public void SetHairColor(int hairColorID)
    {
        CustomizationData.HairMaterial.color = CustomizationData.HairColors[hairColorID];
    }

    public void SetSkinColor(int skinColorID)
    {
        CustomizationData.SkinMaterial.color = CustomizationData.SkinColors[skinColorID];
    }
}
