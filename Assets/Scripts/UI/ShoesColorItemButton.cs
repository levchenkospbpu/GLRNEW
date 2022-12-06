using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ShoesColorItemButton : UIElement
    {
        [field: SerializeField] public Button Button { private set; get; }
        [field: SerializeField] public Image Image { private set; get; }
    }
}
