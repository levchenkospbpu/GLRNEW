using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CancelCustomizationNoButton : MonoBehaviour
{
    [SerializeField] private CancelCustomizationPanel _cancelCustomizationPanel;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(Hide);
    }

    private void Hide()
    {
        _cancelCustomizationPanel.gameObject.SetActive(false);
    }
}
