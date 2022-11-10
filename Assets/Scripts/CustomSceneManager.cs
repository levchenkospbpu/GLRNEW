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

    public async void LoadScene(DataProvider dataProvider)
    {
        OnSceneLoadingStarted?.Invoke();
        string sceneName = dataProvider.GetData<string>();
        var scene = SceneManager.LoadSceneAsync(sceneName);
        scene.allowSceneActivation = false;
        do
        {
            await Task.Delay(100);
        }
        while (scene.progress < 0.9f);
        scene.allowSceneActivation = true;
        OnSceneLoaded?.Invoke();
    }

    public void Start()
    {
        _actionRegister.Register(ActionType.LoadScene, LoadScene);
    }
}
