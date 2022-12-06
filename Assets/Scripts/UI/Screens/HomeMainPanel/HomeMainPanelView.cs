using Common.MVP;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Screens.HomeMainPanel
{
    public class HomeMainPanelView : BaseView
    {
        [field: SerializeField] public Button CustomizationButton { private set; get; }
        [field: SerializeField] public Button MapButton { private set; get; }
        [field: SerializeField] public Button PartyButton { private set; get; }
    }
}