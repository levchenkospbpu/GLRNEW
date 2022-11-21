using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class GameInitializer : IStartable
{
    private UIProvider _uiProvider;

    public GameInitializer(UIProvider uiProvider)
    {
        _uiProvider = uiProvider;
    }

    public void Start()
    {
        string accessToken = PlayerPrefs.GetString(PlayerPrefsKeys.AccesToken, string.Empty);

        if (string.IsNullOrEmpty(accessToken))
        {
            AccessManager.GenerateAccesToken();
            _uiProvider.Show(typeof(CharacterCreationPanel), GameObject.FindGameObjectWithTag("MainCanvas").transform);
        }
        else
        {
            _uiProvider.Show(typeof(MainPanel), GameObject.FindGameObjectWithTag("MainCanvas").transform);
        }
    }
}
