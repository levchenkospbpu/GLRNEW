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
    }
}