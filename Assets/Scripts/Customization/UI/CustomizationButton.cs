using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.UI;
using VContainer;
using VContainer.Unity;

public class CustomizationButton : UIElement
{
    [Inject]
    private UIProvider _uiProvider;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(ShowCustomizationPanel);
    }

    private void ShowCustomizationPanel()
    {
        _uiProvider.Show(typeof(CustomizationPanel), transform.parent);
    }
}
