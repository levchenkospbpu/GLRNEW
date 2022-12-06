using UnityEngine;

namespace UI
{
    public interface IUiSwitcher
    {
        void Show<T>(GameObject prefab, Transform parent);
        void Hide();
    }
}