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
        private readonly CustomizationDataContainer _customizationData;
        private readonly PlayerData _playerData;
        private readonly Appearance _appearance;

        private readonly CharacterCreationPresenter _characterCreationPresenter;

        public AvatarState(ISceneController sceneController, CustomizationDataContainer customizationData, UIProviderConfig uiProviderConfig, PlayerData playerData, UiCanvasData uiCanvasData, Appearance appearance)
        {
            _sceneController = sceneController;
            _customizationData = customizationData;
            _playerData = playerData;
            _appearance = appearance;

            _characterCreationPresenter = new CharacterCreationPresenter(uiCanvasData, uiProviderConfig);
        }

        protected override void OnEnter(DataProvider dataProvider)
        {
            _characterCreationPresenter.Enable(new CharacterCreationModel(_customizationData.HairMaterals, _playerData.Hair, _customizationData.SkinMaterials));

            _characterCreationPresenter.OnApplyHandler += ApplyHandler;
            _characterCreationPresenter.OnHairHandler += _appearance.SetHair;
            _characterCreationPresenter.OnHairColorHandler += _appearance.SetHairColor;
            _characterCreationPresenter.OnSkinColorHandler += _appearance.SetSkinColor;
        }

        private void ApplyHandler()
        {
            _appearance.Save();
            PlayerPrefs.SetString(PlayerPrefsKeys.AccessToken, Guid.NewGuid().ToString());
            
            _sceneController.ChangeState<MainPanelState>(new DataProvider());
        }

        protected override void OnEnd(DataProvider dataProvider)
        {
            _characterCreationPresenter.Disable();
        }
    }
}