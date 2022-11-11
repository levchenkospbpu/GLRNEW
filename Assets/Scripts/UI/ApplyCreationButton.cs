using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ApplyCreationButton : MonoBehaviour
{
    [SerializeField] private CharacterCreationPanel _characterCreationPanel;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(SaveChanges);
        GetComponent<Button>().onClick.AddListener(ShowMainPanel);
    }

    private void SaveChanges()
    {
        PlayerPrefs.SetInt(PlayerPrefsKeys.AppearanceHairID, _characterCreationPanel.Appearance.CurrentHairID);
        PlayerPrefs.SetInt(PlayerPrefsKeys.AppearanceHairColorID, _characterCreationPanel.Appearance.CurrentHairColorID);
        PlayerPrefs.SetInt(PlayerPrefsKeys.AppearanceSkinColorID, _characterCreationPanel.Appearance.CurrentSkinColorID);
    }

    private void ShowMainPanel()
    {
        _characterCreationPanel.UIProvider.Show(typeof(MainPanel), GameObject.FindGameObjectWithTag("MainCanvas").transform);
    }
}
