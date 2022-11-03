using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

public class MapButton : MonoBehaviour
{
    [Inject]
    private UIProvider _uiProvider;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(ShowMapPanel);
    }

    private void ShowMapPanel()
    {
        _uiProvider.Show(typeof(MapPanel), transform.parent);
    }
}
