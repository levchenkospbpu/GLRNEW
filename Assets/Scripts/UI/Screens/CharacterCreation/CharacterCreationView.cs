using Common.MVP;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Screens.CharacterCreation
{
    public class CharacterCreationView : BaseView
    {
        [field: Header("Buttons")]
        [field: SerializeField] public Button ApplyButton { private set; get; }
        [field: SerializeField] public Button HairButton { private set; get; }
        [field: SerializeField] public Button HairColorButton { private set; get; }
        [field: SerializeField] public Button SkinColorButton { private set; get; }

        [field: Header("References")]
        [field: SerializeField] public Transform ScrollContent { private set; get; }
        
        [field: Header("Prefabs")]
        [field: SerializeField] public GameObject HairItemPrefab { private set; get; }
        [field: SerializeField] public GameObject HairColorItemPrefab { private set; get; }
        [field: SerializeField] public GameObject SkinColorItemPrefab { private set; get; }
    }
}
