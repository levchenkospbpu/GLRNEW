using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomizationHairButton : MonoBehaviour
{
    [SerializeField] private CustomizationPanel _customizationPanel;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(LoadHairItems);
    }

    private void LoadHairItems()
    {
        _customizationPanel.ItemsScrollView.LoadHairItems();
    }
}
