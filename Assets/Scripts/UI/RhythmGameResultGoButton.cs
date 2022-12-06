using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RhythmGameResultGoButton : MonoBehaviour
{
    [SerializeField] private RhythmGameResultPanel _rhythmGameResultPanel;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(LoadLocation);
    }

    private void LoadLocation()
    {
        _rhythmGameResultPanel.ActionCaller.Raise(ActionType.LoadScene, new DataProvider("Home"));
    }
}
