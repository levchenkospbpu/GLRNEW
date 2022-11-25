using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RhythmGameTryAgainButton : MonoBehaviour
{
    [SerializeField] private RhythmGameResultPanel _rhythmGameResultPanel;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(ReloadScene);
    }

    private void ReloadScene()
    {
        _rhythmGameResultPanel.ActionCaller.Raise(ActionType.LoadScene, new DataProvider(SceneManager.GetActiveScene().name));
    }
}
