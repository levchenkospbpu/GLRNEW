using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    [CreateAssetMenu(fileName = "NewUIProviderConfig", menuName = "Data/UIProviderConfig")]
    public class UIProviderConfig : ScriptableObject
    {
        [field: SerializeField] public GameObject CharacterCreation;
        [field: SerializeField] public List<UIElement> UIPrefabs { get; private set; }
    }
}
