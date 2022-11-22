using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomeButton : MonoBehaviour
{
    [SerializeField] private LocationPanel _locationPanel;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(LoadHomeScene);
    }

    private void LoadHomeScene()
    {
        _locationPanel.ActionCaller.Raise(ActionType.LoadScene, new DataProvider(0));
    }
}
