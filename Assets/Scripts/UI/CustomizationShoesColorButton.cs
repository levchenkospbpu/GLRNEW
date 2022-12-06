using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomizationShoesColorButton : MonoBehaviour
{
    [SerializeField] private CustomizationPanel _customizationPanel;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(LoadShoesColorItems);
    }

    private void LoadShoesColorItems()
    {
        _customizationPanel.ItemsScrollView.LoadShoesColorItems();
    }
}
