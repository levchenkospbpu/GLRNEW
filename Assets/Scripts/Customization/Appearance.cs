using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;
using VContainer.Unity;
using static UnityEngine.GraphicsBuffer;

public class Appearance : IStartable
{
    public CustomizationData CustomizationData { get; private set; }
    public Hair[] Hairs { get; private set; }
    public Face Face { get; private set; }
    public Body Body { get; private set; }
    public int CurrentHairID { get; private set; }
    public int CurrentHairColorID { get; private set; }
    public int CurrentSkinColorID { get; private set; }
    public int CurrentTopColorID { get; private set; }
    public int CurrentBottomColorID { get; private set; }
    public int CurrentShoesColorID { get; private set; }
    public CustomSceneManager CustomSceneManager { get; private set; }

    private GameObject _player;
    private IActionRegister _actionRegister;

    public Appearance(CustomizationData customizationData, IActionRegister actionRegister, CustomSceneManager customSceneManager)
    {
        CustomizationData = customizationData;
        _actionRegister = actionRegister;
        CustomSceneManager = customSceneManager;
    }

    public void Initialize()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        Face = _player.GetComponentInChildren<Face>();
        Body = _player.GetComponentInChildren<Body>();
        Hairs = _player.GetComponentsInChildren<Hair>();
        foreach (Hair hair in Hairs)
        {
            hair.gameObject.SetActive(false);
        }
        CurrentHairID = PlayerPrefs.GetInt(PlayerPrefsKeys.AppearanceHairID, 0);
        CurrentHairColorID = PlayerPrefs.GetInt(PlayerPrefsKeys.AppearanceHairColorID, 0);
        CurrentSkinColorID = PlayerPrefs.GetInt(PlayerPrefsKeys.AppearanceSkinColorID, 4);
        CurrentTopColorID = PlayerPrefs.GetInt(PlayerPrefsKeys.AppearanceTopColorID, 1);
        CurrentBottomColorID = PlayerPrefs.GetInt(PlayerPrefsKeys.AppearanceBottomColorID, 2);
        CurrentShoesColorID = PlayerPrefs.GetInt(PlayerPrefsKeys.AppearanceShoesColorID, 1);
        SetHair(new DataProvider(CurrentHairID));
        SetHairColor(new DataProvider(CurrentHairColorID));
        SetSkinColor(new DataProvider(CurrentSkinColorID));
        SetTopColor(new DataProvider(CurrentTopColorID));
        SetBottomColor(new DataProvider(CurrentBottomColorID));
        SetShoesColor(new DataProvider(CurrentShoesColorID));
    }
 
    public void SetHair(DataProvider dataProvider)
    {
        int hairID = dataProvider.GetData<int>();
        if (hairID < 0 || hairID >= Hairs.Length) return;
        Hairs[CurrentHairID].gameObject.SetActive(false);
        Hairs[hairID].gameObject.SetActive(true);
        CurrentHairID = hairID;
    }

    public void SetHairColor(DataProvider dataProvider)
    {
        int hairColorID = dataProvider.GetData<int>();
        foreach (Hair hair in Hairs)
        {
            hair.gameObject.GetComponent<SkinnedMeshRenderer>().material = CustomizationData.HairMaterials[hairColorID];
        }
        CurrentHairColorID = hairColorID;
    }

    public void SetSkinColor(DataProvider dataProvider)
    {
        int skinColorID = dataProvider.GetData<int>();
        Material[] bodyMaterials = Body.gameObject.GetComponent<SkinnedMeshRenderer>().materials;
        Material[] faceMaterials = Face.gameObject.GetComponent<SkinnedMeshRenderer>().materials;
        bodyMaterials[0] = CustomizationData.SkinMaterials[skinColorID];
        faceMaterials[3] = CustomizationData.SkinMaterials[skinColorID];
        Body.gameObject.GetComponent<SkinnedMeshRenderer>().materials = bodyMaterials;
        Face.gameObject.GetComponent<SkinnedMeshRenderer>().materials = faceMaterials;
        CurrentSkinColorID = skinColorID;
    }

    public void SetTopColor(DataProvider dataProvider)
    {
        int topColorID = dataProvider.GetData<int>();
        Material[] bodyMaterials = Body.gameObject.GetComponent<SkinnedMeshRenderer>().materials;
        bodyMaterials[1] = CustomizationData.ClothesMaterials[topColorID];
        Body.gameObject.GetComponent<SkinnedMeshRenderer>().materials = bodyMaterials;
        CurrentTopColorID = topColorID;
    }

    public void SetBottomColor(DataProvider dataProvider)
    {
        int bottomColorID = dataProvider.GetData<int>();
        Material[] bodyMaterials = Body.gameObject.GetComponent<SkinnedMeshRenderer>().materials;
        bodyMaterials[3] = CustomizationData.ClothesMaterials[bottomColorID];
        Body.gameObject.GetComponent<SkinnedMeshRenderer>().materials = bodyMaterials;
        CurrentBottomColorID = bottomColorID;
    }

    public void SetShoesColor(DataProvider dataProvider)
    {
        int shoesColorID = dataProvider.GetData<int>();
        Material[] bodyMaterials = Body.gameObject.GetComponent<SkinnedMeshRenderer>().materials;
        bodyMaterials[2] = CustomizationData.ClothesMaterials[shoesColorID];
        Body.gameObject.GetComponent<SkinnedMeshRenderer>().materials = bodyMaterials;
        CurrentShoesColorID = shoesColorID;
    }

    public void Start()
    {
        _actionRegister.Register(ActionType.ChangeHair, SetHair);
        _actionRegister.Register(ActionType.ChangeHairColor, SetHairColor);
        _actionRegister.Register(ActionType.ChangeSkinColor, SetSkinColor);
        _actionRegister.Register(ActionType.ChangeTopColor, SetTopColor);
        _actionRegister.Register(ActionType.ChangeBottomColor, SetBottomColor);
        _actionRegister.Register(ActionType.ChangeShoesColor, SetShoesColor);
        CustomSceneManager.OnSceneLoaded += Initialize;
    }
}
