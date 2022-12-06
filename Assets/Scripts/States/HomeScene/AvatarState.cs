using System;
using Customization;
using SceneControllers;
using UI;
using UI.Canvas;
using UI.Screens.CharacterCreation;
using UnityEngine;

namespace States.HomeScene
{
    public class AvatarState : State
    {
        private readonly ISceneController _sceneController;
        private readonly CustomizationData _customizationData;
        private readonly PlayerData _playerData;
        private readonly Appearance _appearance;

        private readonly CharacterCreationPresenter _characterCreationPresenter;

        public AvatarState(ISceneController sceneController, CustomizationData customizationData, UIProviderConfig uiProviderConfig, PlayerData playerData, UiCanvasData uiCanvasData, Appearance appearance)
        {
            _sceneController = sceneController;
            _customizationData = customizationData;
            _playerData = playerData;
            _appearance = appearance;

            _characterCreationPresenter = new CharacterCreationPresenter(uiProviderConfig.CharacterCreation, uiCanvasData.Screens);
        }

        protected override void OnEnter()
        {
            _characterCreationPresenter.Enable(new CharacterCreationModel(_customizationData.HairMaterials, _playerData.Hair, _customizationData.SkinMaterials));

            _characterCreationPresenter.OnApplyHandler += ApplyHandler;
            _characterCreationPresenter.OnHairHandler += _appearance.SetHair;
            _characterCreationPresenter.OnHairColorHandler += _appearance.SetHairColor;
            _characterCreationPresenter.OnSkinColorHandler += _appearance.SetSkinColor;
        }

        private void ApplyHandler()
        {
            _appearance.Save();
            PlayerPrefs.SetString(PlayerPrefsKeys.AccessToken, Guid.NewGuid().ToString());
            
            _sceneController.ChangeState<MainPanelState>();
        }

        protected override void OnEnd()
        {
            _characterCreationPresenter.Disable();
        }
    }
}