using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace UI
{
    public class HairItemButton : UIElement
    {
        [field: SerializeField] public Button Button { private set; get; }
        [field: SerializeField] public TextMeshProUGUI Text { private set; get; }
    }
}
