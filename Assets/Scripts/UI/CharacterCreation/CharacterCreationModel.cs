using Common.MVP;
using UnityEngine;

namespace UI.CharacterCreation
{
    public class CharacterCreationModel : BaseModel
    {
        public Material[] HairMaterials { get; }
        public SkinnedMeshRenderer[] Hairs { get; }
        public Material[] SkinMaterials { get; }
        
        public CharacterCreationModel(Material[] hairMaterials, SkinnedMeshRenderer[] hairs, Material[] skinMaterials)
        {
            HairMaterials = hairMaterials;
            Hairs = hairs;
            SkinMaterials = skinMaterials;
        }
    }
}