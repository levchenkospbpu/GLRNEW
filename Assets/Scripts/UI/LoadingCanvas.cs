using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using VContainer;

public class LoadingCanvas : MonoBehaviour
{
    [Inject]
    private CustomSceneManager _customSceneManager;

    private void Start()
    {
        _customSceneManager.OnSceneLoadingStarted += CustomSceneManager_OnSceneLoadingStarted;
        _customSceneManager.OnSceneLoaded += CustomSceneManager_OnSceneLoaded;
    }

    private void CustomSceneManager_OnSceneLoadingStarted()
    {
        gameObject.layer = Physics.IgnoreRaycastLayer;
        transform.GetChild(0).gameObject.SetActive(true);
    }

    private void CustomSceneManager_OnSceneLoaded()
    {
        gameObject.layer = Physics.DefaultRaycastLayers;
        transform.GetChild(0).gameObject.SetActive(false);
    }
}
