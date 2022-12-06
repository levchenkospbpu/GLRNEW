using UnityEngine;

namespace Common.MVP
{
    public abstract class BasePresenter<TView, TModel> where TView : BaseView where TModel : BaseModel
    {
        private readonly GameObject _prefab;
        private readonly Transform _parent;
        
        private GameObject _instance;
        private bool _isEnabled;

        protected TView View;
        protected TModel Model;

        protected BasePresenter(GameObject prefab, Transform parent)
        {
            _prefab = prefab;
            _parent = parent;
        }

        public void Enable(TModel model = null)
        {
            if (_isEnabled) return;
            
            _instance = Object.Instantiate(_prefab, _parent);
            View = _instance.GetComponent<TView>();
            Model = model;
            _isEnabled = true;

            OnEnable();
        }

        protected virtual void OnEnable()
        {
            
        }

        public void Disable()
        {
            Object.Destroy(_instance);
            _isEnabled = false;
            
            OnDisable();
        }

        protected virtual void OnDisable()
        {
            
        }
    }
}