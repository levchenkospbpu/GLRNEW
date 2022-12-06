using Common.MVP;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Screens.CustomizationPanel
{
    public class HomeCustomizationPanelView : BaseView
    {
        [field: Header("Buttons")]
        [field: SerializeField] public Button ApplyButton { private set; get; }
        [field: SerializeField] public Button CancelButton { private set; get; }
        [field: SerializeField] public Button HairButton { private set; get; }
        [field: SerializeField] public Button HairColorButton { private set; get; }
        [field: SerializeField] public Button TopColorButton { private set; get; }
        [field: SerializeField] public Button BottomColorButton { private set; get; }
        [field: SerializeField] public Button ShoesColorButton { private set; get; }

        [field: Header("References")] 
        [field: SerializeField] public Transform ScrollContent { private set; get; }
        
        [field: Header("Prefabs")]
        [field: SerializeField] public GameObject HairItemPrefab { private set; get; }
        [field: SerializeField] public GameObject HairColorItemPrefab { private set; get; }
        [field: SerializeField] public GameObject TopColorItemPrefab { private set; get; }
        [field: SerializeField] public GameObject BottomColorItemPrefab { private set; get; }
        [field: SerializeField] public GameObject ShoesColorItemPrefab { private set; get; }
    }
}