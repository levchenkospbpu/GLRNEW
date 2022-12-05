using UnityEngine;

namespace Customization
{
    public class PlayerData : MonoBehaviour
    {
        [field: SerializeField] public SkinnedMeshRenderer Face { private set; get; }
        [field: SerializeField] public SkinnedMeshRenderer Body { private set; get; }
        [field: SerializeField] public SkinnedMeshRenderer [] Hair { private set; get; }
    }
}