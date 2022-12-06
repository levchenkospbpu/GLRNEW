using UnityEngine;

namespace Customization.Data
{
    [CreateAssetMenu(fileName = "NewCustomizationDataConfig", menuName = "Data/CustomizationDataConfig")]
    public class CustomizationDataConfig : ScriptableObject
    {
        [field: SerializeField] public Material[] HairMaterals { get; private set; }
        [field: SerializeField] public Material[] SkinMaterials { get; private set; }
        [field: SerializeField] public Material[] ClothesMaterials { get; private set; }
    }
}
