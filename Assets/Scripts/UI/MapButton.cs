using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

public class MapButton : MonoBehaviour
{
    [SerializeField] private MainPanel _mainPanel;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(ShowMapPanel);
    }

    private void ShowMapPanel()
    {
        _mainPanel.UIProvider.Show(typeof(MapPanel), GameObject.FindGameObjectWithTag("MainCanvas").transform);
    }
}
