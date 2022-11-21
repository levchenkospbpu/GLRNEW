using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocationMapButton : MonoBehaviour
{
    [SerializeField] private LocationPanel _locationPanel;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(ShowMapPanel);
    }

    private void ShowMapPanel()
    {
        _locationPanel.UIProvider.Show(typeof(MapPanel), GameObject.FindGameObjectWithTag("MainCanvas").transform);
    }
}
