using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomizationItemsScrollView : MonoBehaviour
{
    [SerializeField] private CustomizationPanel _customizationPanel;

    private void Start()
    {
        LoadHairItems();
    }

    public void Clear()
    {
        foreach (Transform child in GetComponentInChildren<CustomizationItemsContent>().transform)
        {
            Destroy(child.gameObject);
        }
    }

    public void LoadHairItems()
    {
        Clear();
        for (int i = 0; i < _customizationPanel.Appearance.Hairs.Length; i++)
        {
            HairItemButton hairItemButton = _customizationPanel.UIProvider.Instantiate(typeof(HairItemButton), GetComponentInChildren<CustomizationItemsContent>().gameObject.transform) as HairItemButton;
            hairItemButton.SetID(i);
        }
    }

    public void LoadHairColorItems()
    {
        Clear();
        for (int i = 0; i < _customizationPanel.Appearance.CustomizationData.HairMaterials.Length; i++)
        {
            HairColorItemButton hairColorItemButton = _customizationPanel.UIProvider.Instantiate(typeof(HairColorItemButton), GetComponentInChildren<CustomizationItemsContent>().gameObject.transform) as HairColorItemButton;
            hairColorItemButton.SetID(i);
        }
    }

    public void LoadSkinColorItems()
    {
        Clear();
        for (int i = 0; i < _customizationPanel.Appearance.CustomizationData.SkinMaterials.Length; i++)
        {
            SkinColorItemButton skinColorItemButton = _customizationPanel.UIProvider.Instantiate(typeof(SkinColorItemButton), GetComponentInChildren<CustomizationItemsContent>().gameObject.transform) as SkinColorItemButton;
            skinColorItemButton.SetID(i);
        }
    }

    public void LoadTopColorItems()
    {
        Clear();
        for (int i = 0; i < _customizationPanel.Appearance.CustomizationData.ClothesMaterials.Length; i++)
        {
            TopColorItemButton topColorItemButton = _customizationPanel.UIProvider.Instantiate(typeof(TopColorItemButton), GetComponentInChildren<CustomizationItemsContent>().gameObject.transform) as TopColorItemButton;
            topColorItemButton.SetID(i);
        }
    }

    public void LoadBottomColorItems()
    {
        Clear();
        for (int i = 0; i < _customizationPanel.Appearance.CustomizationData.ClothesMaterials.Length; i++)
        {
            BottomColorItemButton bottomColorItemButton = _customizationPanel.UIProvider.Instantiate(typeof(BottomColorItemButton), GetComponentInChildren<CustomizationItemsContent>().gameObject.transform) as BottomColorItemButton;
            bottomColorItemButton.SetID(i);
        }
    }

    public void LoadShoesColorItems()
    {
        Clear();
        for (int i = 0; i < _customizationPanel.Appearance.CustomizationData.ClothesMaterials.Length; i++)
        {
            ShoesColorItemButton shoesColorItemButton = _customizationPanel.UIProvider.Instantiate(typeof(ShoesColorItemButton), GetComponentInChildren<CustomizationItemsContent>().gameObject.transform) as ShoesColorItemButton;
            shoesColorItemButton.SetID(i);
        }
    }
}
