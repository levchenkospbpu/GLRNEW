using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

public class LocationButton : MonoBehaviour
{
    [SerializeField] private int _sceneID;
    [SerializeField] private MapPanel _mapPanel;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(LoadScene);
    }

    private void LoadScene()
    {
        _mapPanel.ActionCaller.Raise(ActionType.LoadScene, new DataProvider(_sceneID));
    }
}
