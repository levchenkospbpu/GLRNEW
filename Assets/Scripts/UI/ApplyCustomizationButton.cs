using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ApplyCustomizationButton : MonoBehaviour
{
    [SerializeField] private CustomizationPanel _customizationPanel;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(SaveChanges);
        GetComponent<Button>().onClick.AddListener(ShowMainPanel);
    }

    private void SaveChanges()
    {
        PlayerPrefs.SetInt(PlayerPrefsKeys.AppearanceHairID, _customizationPanel.Appearance.CurrentHairID);
        PlayerPrefs.SetInt(PlayerPrefsKeys.AppearanceHairColorID, _customizationPanel.Appearance.CurrentHairColorID);
        PlayerPrefs.SetInt(PlayerPrefsKeys.AppearanceSkinColorID, _customizationPanel.Appearance.CurrentSkinColorID);
        PlayerPrefs.SetInt(PlayerPrefsKeys.AppearanceTopColorID, _customizationPanel.Appearance.CurrentTopColorID);
        PlayerPrefs.SetInt(PlayerPrefsKeys.AppearanceBottomColorID, _customizationPanel.Appearance.CurrentBottomColorID);
        PlayerPrefs.SetInt(PlayerPrefsKeys.AppearanceShoesColorID, _customizationPanel.Appearance.CurrentShoesColorID);
    }

    private void ShowMainPanel()
    {
        _customizationPanel.UIProvider.Show(typeof(MainPanel), GameObject.FindGameObjectWithTag("MainCanvas").transform);
    }
}
