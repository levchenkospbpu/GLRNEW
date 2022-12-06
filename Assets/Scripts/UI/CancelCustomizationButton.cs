using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CancelCustomizationButton : MonoBehaviour
{
    [SerializeField] private CustomizationPanel _customizationPanel;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(ShowCancelPanel);
    }

    private void ShowCancelPanel()
    {
        _customizationPanel.CancelCustomizationPanel.gameObject.SetActive(true);
    }
}
