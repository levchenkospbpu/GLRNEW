using Common.MVP;
using UnityEngine;
using UnityEngine.UI;

namespace UI.CharacterCreation
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
        [field: SerializeField] public GameObject HairItemButton { private set; get; }
        [field: SerializeField] public GameObject HairColorItemButton { private set; get; }
        [field: SerializeField] public GameObject SkinColorItemButton { private set; get; }
    }
}
