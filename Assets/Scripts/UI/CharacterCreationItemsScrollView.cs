using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VContainer.Unity;

public class CharacterCreationItemsScrollView : MonoBehaviour
{
    [SerializeField] private CharacterCreationPanel _characterCreationPanel;

    private void Start()
    {
        LoadHairItems();
    }

    public void Clear()
    {
        foreach(Transform child in GetComponentInChildren<CustomizationItemsContent>().transform)
        {
            Destroy(child.gameObject);
        }
    }

    public void LoadHairItems()
    {
        Clear();
        for (int i = 0; i < _characterCreationPanel.Appearance.Hairs.Length; i++)
        {
            HairItemButton hairItemButton = _characterCreationPanel.UIProvider.Instantiate(typeof(HairItemButton), GetComponentInChildren<CustomizationItemsContent>().gameObject.transform) as HairItemButton;
            hairItemButton.SetID(i);
        }
    }

    public void LoadHairColorItems()
    {
        Clear();
        for (int i = 0; i < _characterCreationPanel.Appearance.CustomizationData.HairMaterials.Length; i++)
        {
            HairColorItemButton hairColorItemButton = _characterCreationPanel.UIProvider.Instantiate(typeof(HairColorItemButton), GetComponentInChildren<CustomizationItemsContent>().gameObject.transform) as HairColorItemButton;
            hairColorItemButton.SetID(i);
        }
    }

    public void LoadSkinColorItems()
    {
        Clear();
        for (int i = 0; i < _characterCreationPanel.Appearance.CustomizationData.ClothesMaterials.Length; i++)
        {
            SkinColorItemButton skinColorItemButton = _characterCreationPanel.UIProvider.Instantiate(typeof(SkinColorItemButton), GetComponentInChildren<CustomizationItemsContent>().gameObject.transform) as SkinColorItemButton;
            skinColorItemButton.SetID(i);
        }
    }
}
