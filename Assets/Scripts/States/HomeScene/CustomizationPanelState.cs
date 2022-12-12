using Customization;
using SceneControllers;
using UI;
using UI.Canvas;
using UI.Popups.ConfirmationPopup;
using UI.Screens.CustomizationPanel;
using UnityEngine;

namespace States.HomeScene
{
    public class CustomizationPanelState : State
    {
        private readonly ISceneController _sceneController;
        private readonly PlayerData _playerData;
        private readonly CustomizationDataContainer _customizationData;
        private readonly Appearance _appearance;

        private readonly HomeCustomizationPanelPresenter _homeCustomizationPanelPresenter;
        private readonly ConfirmationPopupPresenter _confirmationPopupPresenter;
        
        private int _currentHairId;
        private int _currentHairColorID;
        private int _currentTopColorID;
        private int _currentBottomColorID;
        private int _currentShoesColorID;
        
        public CustomizationPanelState(ISceneController sceneController, UIProviderConfig uiProviderConfig, UiCanvasData uiCanvasData, PlayerData playerData, CustomizationDataContainer customizationData, Appearance appearance)
        {
            _sceneController = sceneController;
            _playerData = playerData;
            _customizationData = customizationData;
            _appearance = appearance;
            _homeCustomizationPanelPresenter = new HomeCustomizationPanelPresenter(uiCanvasData, uiProviderConfig);
            _confirmationPopupPresenter = new ConfirmationPopupPresenter(uiCanvasData, uiProviderConfig);
        }
        
        protected override void OnEnter(DataProvider dataProvider)
        {
            _currentHairId = _appearance.CurrentHairId;
            _currentHairColorID = _appearance.CurrentHairColorID;
            _currentTopColorID = _appearance.CurrentTopColorID;
            _currentBottomColorID = _appearance.CurrentBottomColorID;
            _currentShoesColorID = _appearance.CurrentShoesColorID;
            
            _homeCustomizationPanelPresenter.Enable(new HomeCustomizationPanelModel(_customizationData.HairMaterals, _playerData.Hair, _customizationData.ClothesMaterials));
            
            _homeCustomizationPanelPresenter.OnCancelButton += () =>
            {
                _confirmationPopupPresenter.Enable(new ConfirmationPopupModel("$CONFIRMATION_CANCEL_CUSTOMIZATION_TEXT"));

                _confirmationPopupPresenter.OnNoButton += () =>
                {
                    _confirmationPopupPresenter.Disable();
                };

                _confirmationPopupPresenter.OnYesButton += () =>
                {
                    _appearance.SetHair(_currentHairId);
                    _appearance.SetHairColor(_currentHairColorID);
                    _appearance.SetTopColor(_currentTopColorID);
                    _appearance.SetBottomColor(_currentBottomColorID);
                    _appearance.SetShoesColor(_currentShoesColorID);
                    
                    _sceneController.ChangeState<MainPanelState>(new DataProvider());
                };
            };
            
            _homeCustomizationPanelPresenter.OnApplyButton += () =>
            {
                _appearance.Save();
                _sceneController.ChangeState<MainPanelState>(new DataProvider());
            };

            _homeCustomizationPanelPresenter.OnHairButton += _appearance.SetHair;
            _homeCustomizationPanelPresenter.OnHairColorButton += _appearance.SetHairColor;
            _homeCustomizationPanelPresenter.OnTopColorButton += _appearance.SetTopColor;
            _homeCustomizationPanelPresenter.OnBottomColorButton += _appearance.SetBottomColor;
            _homeCustomizationPanelPresenter.OnShoesColorButton += _appearance.SetShoesColor;
        }

        protected override void OnEnd(DataProvider dataProvider)
        {
            _homeCustomizationPanelPresenter.Disable();
            _confirmationPopupPresenter.Disable();
        }
    }
}