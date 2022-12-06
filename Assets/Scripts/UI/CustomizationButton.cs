using UnityEngine;
using UnityEngine.UI;

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
