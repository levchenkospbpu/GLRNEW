using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.UI;
using VContainer;
using VContainer.Unity;

public class CustomizationButton : MonoBehaviour
{
    [SerializeField] private MainPanel _mainPanel;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(ShowCustomizationPanel);
    }

    private void ShowCustomizationPanel()
    {
        _mainPanel.UIProvider.Show(typeof(CustomizationPanel), GameObject.FindGameObjectWithTag("MainCanvas").transform);
    }
}
