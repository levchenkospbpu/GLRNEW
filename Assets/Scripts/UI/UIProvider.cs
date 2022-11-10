using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using VContainer;
using VContainer.Unity;
using Object = UnityEngine.Object;

public class UIProvider
{
    private Dictionary<Type, UIElement> _uiElements;
    private UIElement _currentUIElement;
    private IObjectResolver _objectResolver;

    public UIProvider(UIProviderConfig uiProviderConfig, IObjectResolver resolver)
    {
        _uiElements = uiProviderConfig.UIPrefabs.ToDictionary(x => x.GetType(), y => y);
        _objectResolver = resolver;
    }

    public void Show(Type type, Transform parent)
    {
        if (_uiElements.ContainsKey(type))
        {
            Object.Destroy(_currentUIElement?.gameObject);
            _currentUIElement = _objectResolver.Instantiate(_uiElements[type], parent);
        }
    }

    public UIElement Instantiate(Type type, Transform parent)
    {
        if (_uiElements.ContainsKey(type))
        {
            _currentUIElement = _objectResolver.Instantiate(_uiElements[type], parent);
            return _currentUIElement;
        }
        else return new UIElement();
    }
}
