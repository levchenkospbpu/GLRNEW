using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomizationTopColorButton : MonoBehaviour
{
    [SerializeField] private CustomizationPanel _customizationPanel;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(LoadTopColorItems);
    }

    private void LoadTopColorItems()
    {
        _customizationPanel.ItemsScrollView.LoadTopColorItems();
    }
}
