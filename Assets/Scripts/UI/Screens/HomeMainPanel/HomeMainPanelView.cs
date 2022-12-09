using Common.MVP;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Screens.HomeMainPanel
{
    public class HomeMainPanelView : BaseView
    {
        [field: SerializeField] public Button CustomizationButton { get; private set; }
        [field: SerializeField] public Button MapButton { get; private set; }
        [field: SerializeField] public Button PartyButton { get; private set; }
    }
}