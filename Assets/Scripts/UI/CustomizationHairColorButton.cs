using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomizationHairColorButton : MonoBehaviour
{
    [SerializeField] private CustomizationPanel _customizationPanel;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(LoadHairColorItems);
    }

    private void LoadHairColorItems()
    {
        _customizationPanel.ItemsScrollView.LoadHairColorItems();
    }
}
