using UnityEngine;
using VContainer.Unity;

namespace Customization
{
    public class Appearance : IInitializable
    {
        private readonly CustomizationData _customizationData;
        private readonly PlayerData _playerData;
        
        public int CurrentHairId { private set; get; }
        public int CurrentHairColorID { private set; get; }
        public int CurrentSkinColorID { private set; get; }
        public int CurrentTopColorID { private set; get; }
        public int CurrentBottomColorID { private set; get; }
        public int CurrentShoesColorID { private set; get; }

        public Appearance(CustomizationData customizationData, PlayerData playerData)
        {
            _customizationData = customizationData;
            _playerData = playerData;
        }

        public void Initialize()
        {
            CurrentHairId = PlayerPrefs.GetInt(PlayerPrefsKeys.AppearanceHairID, 0);
            CurrentHairColorID = PlayerPrefs.GetInt(PlayerPrefsKeys.AppearanceHairColorID, 0);
            CurrentSkinColorID = PlayerPrefs.GetInt(PlayerPrefsKeys.AppearanceSkinColorID, 4);
            CurrentTopColorID = PlayerPrefs.GetInt(PlayerPrefsKeys.AppearanceTopColorID, 1);
            CurrentBottomColorID = PlayerPrefs.GetInt(PlayerPrefsKeys.AppearanceBottomColorID, 2);
            CurrentShoesColorID = PlayerPrefs.GetInt(PlayerPrefsKeys.AppearanceShoesColorID, 1);
            
            SetHair(CurrentHairId);
            SetHairColor(CurrentHairColorID);
            SetSkinColor(CurrentSkinColorID);
            SetTopColor(CurrentTopColorID);
            SetBottomColor(CurrentBottomColorID);
            SetShoesColor(CurrentShoesColorID);
        }

        public void Save()
        {
            PlayerPrefs.SetInt(PlayerPrefsKeys.AppearanceHairID, CurrentHairId);
            PlayerPrefs.SetInt(PlayerPrefsKeys.AppearanceHairColorID, CurrentHairColorID);
            PlayerPrefs.SetInt(PlayerPrefsKeys.AppearanceTopColorID, CurrentTopColorID);
            PlayerPrefs.SetInt(PlayerPrefsKeys.AppearanceBottomColorID, CurrentBottomColorID);
            PlayerPrefs.SetInt(PlayerPrefsKeys.AppearanceShoesColorID, CurrentShoesColorID);
            PlayerPrefs.Save();
        }

        public void SetTopColor(int id)
        {
            var bodyMaterials = _playerData.Body.materials;
            bodyMaterials[1] = _customizationData.ClothesMaterials[id];
            _playerData.Body.materials = bodyMaterials;

            CurrentTopColorID = id;
        }

        public void SetBottomColor(int id)
        {
            var bodyMaterials = _playerData.Body.materials;
            bodyMaterials[3] = _customizationData.ClothesMaterials[id];
            _playerData.Body.materials = bodyMaterials;

            CurrentBottomColorID = id;
        }

        public void SetShoesColor(int id)
        {
            var bodyMaterials = _playerData.Body.materials;
            bodyMaterials[2] = _customizationData.ClothesMaterials[id];
            _playerData.Body.materials = bodyMaterials;

            CurrentShoesColorID = id;
        }

        public void SetHair(int id)
        {
            _playerData.Hair[CurrentHairId].gameObject.SetActive(false);
            _playerData.Hair[id].gameObject.SetActive(true);

            CurrentHairId = id;
        }

        public void SetHairColor(int id)
        {
            foreach (var hair in _playerData.Hair)
            {
                hair.material = _customizationData.HairMaterials[id];
            }

            CurrentHairColorID = id;
        }
        
        public void SetSkinColor(int id)
        {
            var bodyMaterials = _playerData.Body.materials;
            bodyMaterials[0] = _customizationData.SkinMaterials[id];
            _playerData.Body.materials = bodyMaterials;

            var faceMaterials = _playerData.Face.materials;
            faceMaterials[3] = _customizationData.SkinMaterials[id];
            _playerData.Face.materials = faceMaterials;

            CurrentSkinColorID = id;
        }
    }
}
