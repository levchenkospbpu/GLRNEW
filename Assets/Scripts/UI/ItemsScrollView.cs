using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VContainer.Unity;

public class ItemsScrollView : MonoBehaviour
{
    [SerializeField] private CharacterCreationPanel _characterCreationPanel;

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
            hairItemButton.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = (i + 1).ToString();
        }
    }

    public void LoadHairColorItems()
    {
        Clear();
        for (int i = 0; i < _characterCreationPanel.Appearance.CustomizationData.HairColors.Length; i++)
        {
            HairColorItemButton hairColorItemButton = _characterCreationPanel.UIProvider.Instantiate(typeof(HairColorItemButton), GetComponentInChildren<CustomizationItemsContent>().gameObject.transform) as HairColorItemButton;
            hairColorItemButton.gameObject.GetComponent<Image>().color = _characterCreationPanel.Appearance.CustomizationData.HairColors[i];
        }
    }

    public void LoadSkinColorItems()
    {
        Clear();
        for (int i = 0; i < _characterCreationPanel.Appearance.CustomizationData.SkinColors.Length; i++)
        {
            SkinColorItemButton skinColorItemButton = _characterCreationPanel.UIProvider.Instantiate(typeof(SkinColorItemButton), GetComponentInChildren<CustomizationItemsContent>().gameObject.transform) as SkinColorItemButton;
            skinColorItemButton.gameObject.GetComponent<Image>().color = _characterCreationPanel.Appearance.CustomizationData.SkinColors[i];
        }
    }
}
