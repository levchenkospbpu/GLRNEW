using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomizationBottomColorButton : MonoBehaviour
{
    [SerializeField] private CustomizationPanel _customizationPanel;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(LoadBottomColorItems);
    }

    private void LoadBottomColorItems()
    {
        _customizationPanel.ItemsScrollView.LoadBottomColorItems();
    }
}
