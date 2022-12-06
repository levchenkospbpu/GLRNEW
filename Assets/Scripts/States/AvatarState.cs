using System;
using Customization;
using SceneControllers;
using UI;
using UI.Canvas;
using UI.CharacterCreation;
using UnityEngine;

namespace States
{
    public class AvatarState : State
    {
        private readonly ISceneController _sceneController;
        private readonly CustomizationData _customizationData;
        private readonly PlayerData _playerData;

        private readonly CharacterCreationPresenter _characterCreationPresenter;

        private int _currentHairId;
        private int _currentHairColorID;
        private int _currentSkinColorID;
        private int _currentTopColorID;
        private int _currentBottomColorID;
        private int _currentShoesColorID;

        public AvatarState(ISceneController sceneController, CustomizationData customizationData, UIProviderConfig uiProviderConfig, PlayerData playerData, UiCanvasData uiCanvasData)
        {
            _sceneController = sceneController;
            _customizationData = customizationData;
            _playerData = playerData;

            _characterCreationPresenter = new CharacterCreationPresenter(uiProviderConfig.CharacterCreation, uiCanvasData.Screens);
        }

        protected override void OnEnter()
        {
            _characterCreationPresenter.Enable(new CharacterCreationModel(_customizationData.HairMaterials, _playerData.Hair, _customizationData.SkinMaterials));

            _characterCreationPresenter.OnApplyHandler += ApplyHandler;
            _characterCreationPresenter.OnHairHandler += HairHandler;
            _characterCreationPresenter.OnHairColorHandler += HairColorHandler;
            _characterCreationPresenter.OnSkinColorHandler += SkinColorHandler;
            
            Initialize();
        }
        
        private void Initialize()
        {
            _currentHairId = PlayerPrefs.GetInt(PlayerPrefsKeys.AppearanceHairID, 0);
            _currentHairColorID = PlayerPrefs.GetInt(PlayerPrefsKeys.AppearanceHairColorID, 0);
            _currentSkinColorID = PlayerPrefs.GetInt(PlayerPrefsKeys.AppearanceSkinColorID, 4);
            _currentTopColorID = PlayerPrefs.GetInt(PlayerPrefsKeys.AppearanceTopColorID, 1);
            _currentBottomColorID = PlayerPrefs.GetInt(PlayerPrefsKeys.AppearanceBottomColorID, 2);
            _currentShoesColorID = PlayerPrefs.GetInt(PlayerPrefsKeys.AppearanceShoesColorID, 1);
        }
        
        private void ApplyHandler()
        {
            PlayerPrefs.SetInt(PlayerPrefsKeys.AppearanceHairID, _currentHairId);
            PlayerPrefs.SetInt(PlayerPrefsKeys.AppearanceHairColorID, _currentHairColorID);
            PlayerPrefs.SetInt(PlayerPrefsKeys.AppearanceSkinColorID, _currentSkinColorID);
            PlayerPrefs.SetInt(PlayerPrefsKeys.AppearanceTopColorID, _currentTopColorID);
            PlayerPrefs.SetInt(PlayerPrefsKeys.AppearanceBottomColorID, _currentBottomColorID);
            PlayerPrefs.SetInt(PlayerPrefsKeys.AppearanceShoesColorID, _currentShoesColorID);
            
            PlayerPrefs.SetString(PlayerPrefsKeys.AccessToken, Guid.NewGuid().ToString());

            _sceneController.ChangeState<MainPanelState>();
        }

        private void HairHandler(int id)
        {
            _playerData.Hair[_currentHairId].gameObject.SetActive(false);
            _playerData.Hair[id].gameObject.SetActive(true);
            _currentHairId = id;
        }

        private void HairColorHandler(int id)
        {
            foreach (var hair in _playerData.Hair)
            {
                hair.material = _customizationData.HairMaterials[id];
            }
            _currentHairColorID = id;
        }

        private void SkinColorHandler(int id)
        {
            var bodyMaterials = _playerData.Body.materials;
            bodyMaterials[0] = _customizationData.SkinMaterials[id];
            _playerData.Body.materials = bodyMaterials;

            var faceMaterials = _playerData.Face.materials;
            faceMaterials[3] = _customizationData.SkinMaterials[id];
            _playerData.Face.materials = faceMaterials;
                    
            _currentSkinColorID = id;
        }

        protected override void OnEnd()
        {
            _characterCreationPresenter.Disable();
        }
    }
}