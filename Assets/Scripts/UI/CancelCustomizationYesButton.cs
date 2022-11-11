using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CancelCustomizationYesButton : MonoBehaviour
{
    [SerializeField] private CustomizationPanel _customizationPanel;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(ShowMainPanel);
    }

    private void ShowMainPanel()
    {
        _customizationPanel.ActionCaller.Raise(ActionType.ChangeHair, new DataProvider(_customizationPanel.StartHairID));
        _customizationPanel.ActionCaller.Raise(ActionType.ChangeHairColor, new DataProvider(_customizationPanel.StartHairColorID));
        _customizationPanel.ActionCaller.Raise(ActionType.ChangeSkinColor, new DataProvider(_customizationPanel.StartSkinColorID));
        _customizationPanel.UIProvider.Show(typeof(MainPanel), GameObject.FindGameObjectWithTag("MainCanvas").transform);
    }
}
