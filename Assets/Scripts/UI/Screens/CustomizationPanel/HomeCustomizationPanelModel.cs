using Common.MVP;
using UnityEngine;

namespace UI.Screens.CustomizationPanel
{
    public class HomeCustomizationPanelModel : BaseModel
    {
        public readonly Material[] HairMaterials;
        public readonly SkinnedMeshRenderer[] Hairs;
        public readonly Material[] ClothesMaterials;

        public HomeCustomizationPanelModel(Material[] hairMaterials, SkinnedMeshRenderer[] hairs, Material[] clothesMaterials)
        {
            HairMaterials = hairMaterials;
            Hairs = hairs;
            ClothesMaterials = clothesMaterials;
        }
    }
}