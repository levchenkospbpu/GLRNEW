using UnityEngine;

namespace UI.Canvas
{
    public class UiCanvasData : MonoBehaviour
    {
        [field: SerializeField] public Transform Screens { private set; get; }
        [field: SerializeField] public Transform Notifications { private set; get; }
    }
}