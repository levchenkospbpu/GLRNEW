using Common.MVP;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Screens.PartyPanel
{
    public class PartyPanelView : BaseView
    {
        [field: Header("Buttons")]
        [field: SerializeField] public Button DoneButton { private set; get; }
        [field: SerializeField] public Button CancelButton { private set; get; }
        [field: SerializeField] public Button DrumsButton { private set; get; }
        [field: SerializeField] public Button GuitarButton { private set; get; }
        [field: SerializeField] public Button BassButton { private set; get; }
    }
}