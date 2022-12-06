using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using VContainer;
using VContainer.Unity;
using Object = UnityEngine.Object;

namespace UI
{
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

        public UIElement Show(Type type, Transform parent)
        {
            if (_uiElements.ContainsKey(type))
            {
                Object.Destroy(_currentUIElement?.gameObject);
                return _currentUIElement = _objectResolver.Instantiate(_uiElements[type], parent);
            }
            else return new UIElement();
        }

        public UIElement Instantiate(Type type, Transform parent)
        {
            if (_uiElements.ContainsKey(type))
            {
                return _objectResolver.Instantiate(_uiElements[type], parent);
            }
            else return new UIElement();
        }
    }
}
