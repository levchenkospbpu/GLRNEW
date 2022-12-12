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
using UI.Screens.CharacterCreation;
using Customization;
using Data;

public class CharacterInfoState : State
{
    private readonly ISceneController _sceneController;
    private readonly CharactersDataConfig _charactersDataConfig;

    private readonly CharacterInfoPresenter _characterInfoPresenter;

    private Dictionary<PartySlotType, int> _partyIDs = new();

    public CharacterInfoState(ISceneController sceneController, UIProviderConfig uiProviderConfig, UiCanvasData uiCanvasData, CharactersDataConfig charactersDataConfig)
    {
        _sceneController = sceneController;
        _charactersDataConfig = charactersDataConfig;

        _characterInfoPresenter = new CharacterInfoPresenter(uiCanvasData, uiProviderConfig);
    }

    protected override void OnEnter(DataProvider dataProvider)
    {
        _partyIDs = dataProvider.GetData<Dictionary<PartySlotType, int>>();

        _characterInfoPresenter.Enable(new CharacterInfoModel(_charactersDataConfig.Characters));

        _characterInfoPresenter.OnChooseButton += () =>
        {
            _sceneController.ChangeState<PartyPanelState>(new DataProvider(_partyIDs));
        };
    }

    protected override void OnEnd(DataProvider dataProvider)
    {
        _characterInfoPresenter.Disable();
    }
}
