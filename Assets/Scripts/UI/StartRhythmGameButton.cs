using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartRhythmGameButton : MonoBehaviour
{
    [SerializeField] private PartyPanel _partyPanel;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(StopSong);
        GetComponent<Button>().onClick.AddListener(LoadRhythmGameScene);
    }

    private void StopSong()
    {
        AudioManager.Instance.Stop();
    }

    private void LoadRhythmGameScene()
    {
        _partyPanel.ActionCaller.Raise(ActionType.LoadScene, new DataProvider(SceneManager.GetActiveScene().name + "RhythmGame"));
    }
}
