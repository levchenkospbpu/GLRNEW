using Common.MVP;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Screens.CharacterInfo
{
    public class CharacterInfoView : BaseView
    {
        [field: Header("Buttons")]
        [field: SerializeField] public Button ChooseButton { get; private set; }

        [field: Header("References")]
        [field: SerializeField] public Transform ScrollContent { private set; get; }

        [field: Header("Prefabs")]
        [field: SerializeField] public GameObject CharacterItemPrefab { private set; get; }
    }
}
