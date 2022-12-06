using Common.MVP;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Popups.ConfirmationPopup
{
    public class ConfirmationPopupView : BaseView
    {
        [field: SerializeField] public TextMeshProUGUI Description { private set; get; }
        [field: SerializeField] public Button YesButton { private set; get; }
        [field: SerializeField] public Button NoButton { private set; get; }
    }
}