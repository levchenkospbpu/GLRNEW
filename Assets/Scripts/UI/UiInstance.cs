using Common.MVP;
using UnityEngine;

namespace UI
{
    public class UiInstance<T> : IUiInstance where T : BaseView
    {
        private GameObject _instance;
        private T _component;
        
        public UiInstance(GameObject prefab, Transform parent)
        {
            _instance = Object.Instantiate(prefab, parent);
            _component = _instance.GetComponent<T>();
        }
        
        public void Destroy()
        {
            Object.Destroy(_instance);
            _instance = null;
        }
    }
}