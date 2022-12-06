using UnityEngine;

namespace Customization
{
    [CreateAssetMenu(fileName = "NewCustomizationDataConfig", menuName = "Data/CustomizationDataConfig")]
    public class CustomizationDataContainer : ScriptableObject
    {
        [field: SerializeField] public Material[] HairMaterals { get; private set; }
        [field: SerializeField] public Material[] SkinMaterials { get; private set; }
        [field: SerializeField] public Material[] ClothesMaterials { get; private set; }
    }
}
