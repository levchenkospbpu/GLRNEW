using SceneControllers;
using States;
using System.Collections;
using System.Collections.Generic;
using UI.Canvas;
using UI.Screens.PartyPanel;
using UI;
using UnityEngine;
using States.HomeScene;
using UI.Screens.CustomizationPanel;
using UI.Popups.ConfirmationPopup;

public class CharacterInfoState : State
{
    private readonly ISceneController _sceneController;

    private readonly CharacterInfoPresenter _characterInfoPresenter;
    private readonly ConfirmationPopupPresenter _confirmationPopupPresenter;

    public CharacterInfoState(ISceneController sceneController, UIProviderConfig uiProviderConfig, UiCanvasData uiCanvasData)
    {
        _sceneController = sceneController;
        _characterInfoPresenter = new CharacterInfoPresenter(uiCanvasData, uiProviderConfig);
    }

    protected override void OnEnter()
    {
        _characterInfoPresenter.Enable();

        _characterInfoPresenter.OnChooseButton += () =>
        {
            _sceneController.ChangeState<PartyPanelState>();
        };

        _characterInfoPresenter.OnChooseButton += () =>
        {
            _confirmationPopupPresenter.Enable(new ConfirmationPopupModel("$CONFIRMATION_CANCEL_CHAR_CHANGING_TEXT"));

            _confirmationPopupPresenter.OnNoButton += () =>
            {
                _confirmationPopupPresenter.Disable();
            };

            _confirmationPopupPresenter.OnYesButton += () =>
            {
                //Chose character

                _sceneController.ChangeState<PartyPanelState>();
            };
        };
    }

    protected override void OnEnd()
    {
        _characterInfoPresenter.Disable();
    }
}
