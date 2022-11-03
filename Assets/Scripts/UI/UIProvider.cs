using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using VContainer.Unity;
using Object = UnityEngine.Object;

public class UIProvider : IStartable
{
    private UIProviderConfig _uiProviderConfig;
    private Dictionary<Type, UIElement> _uiElements;

    public UIProvider(UIProviderConfig uiProviderConfig)
    {
        _uiProviderConfig = uiProviderConfig;
    }

    public void Start()
    {
        _uiElements = _uiProviderConfig.UIPrefabs.ToDictionary(x => x.GetType(), y => y);
    }

    public void Show(Type type, Transform parent)
    {
        if (_uiElements.ContainsKey(type))
        {
            Object.Instantiate(_uiElements[type], parent);
        }
    }
}
