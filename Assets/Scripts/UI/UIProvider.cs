using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using VContainer.Unity;
using Object = UnityEngine.Object;

public class UIProvider
{
    private Dictionary<Type, UIElement> _uiElements;
    private UIElement _currentUIElement;

    public UIProvider(UIProviderConfig uiProviderConfig)
    {
        _uiElements = uiProviderConfig.UIPrefabs.ToDictionary(x => x.GetType(), y => y);
    }

    public void Show(Type type, Transform parent)
    {
        if (_uiElements.ContainsKey(type))
        {
            Object.Destroy(_currentUIElement?.gameObject);
            _currentUIElement = Object.Instantiate(_uiElements[type], parent);
        }
    }
}
