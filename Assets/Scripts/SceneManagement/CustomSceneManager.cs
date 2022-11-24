using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using VContainer;
using VContainer.Unity;

public class CustomSceneManager : IStartable
{
    public event Action OnSceneLoadingStarted;
    public event Action OnSceneLoaded;
    private IActionRegister _actionRegister;

    public CustomSceneManager(IActionRegister actionRegister)
    {
        _actionRegister = actionRegister;
    }

    public void LoadScene(DataProvider dataProvider)
    {
        OnSceneLoadingStarted?.Invoke();
        string sceneID = dataProvider.GetData<string>();
        SceneManager.LoadScene(sceneID);
    }

    public void Start()
    {
        _actionRegister.Register(ActionType.LoadScene, LoadScene);
        SceneManager.sceneLoaded += SceneManager_OnSceneLoaded;
    }

    private void SceneManager_OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        OnSceneLoaded?.Invoke();
    }
}
