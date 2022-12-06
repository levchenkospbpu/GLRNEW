using Common.MVP;
using UnityEngine;

namespace UI.Screens.CharacterCreation
{
    public class CharacterCreationModel : BaseModel
    {
        public readonly Material[] HairMaterials;
        public readonly SkinnedMeshRenderer[] Hairs;
        public readonly Material[] SkinMaterials;
        
        public CharacterCreationModel(Material[] hairMaterials, SkinnedMeshRenderer[] hairs, Material[] skinMaterials)
        {
            HairMaterials = hairMaterials;
            Hairs = hairs;
            SkinMaterials = skinMaterials;
        }
    }
}