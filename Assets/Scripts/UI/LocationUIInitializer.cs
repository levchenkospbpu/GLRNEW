using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;
using VContainer;

public class LocationUIInitializer : MonoBehaviour
{
    [Inject]
    public UIProvider UIProvider { get; private set; }

    private void Start()
    {
        UIProvider.Show(typeof(LocationPanel), GameObject.FindGameObjectWithTag("MainCanvas").transform);
    }
}
