using Data;
using SceneControllers;
using System.Collections.Generic;
using UI;
using UI.Canvas;
using UI.Popups.ConfirmationPopup;
using UI.Screens.HomeMainPanel;
using UI.Screens.PartyPanel;
using UnityEngine.Rendering.LookDev;

namespace States.HomeScene
{
    public class PartyPanelState : State
    {
        private readonly ISceneController _sceneController;
        private readonly CharactersDataConfig _charactersDataConfig;
        private readonly Party _party;

        private readonly PartyPanelPresenter _partyPanelPresenter;
        private readonly ConfirmationPopupPresenter _confirmationPopupPresenter;

        private Dictionary<PartySlotType, int> _partyIDs = new();

        public PartyPanelState(ISceneController sceneController, UIProviderConfig uiProviderConfig, UiCanvasData uiCanvasData, CharactersDataConfig charactersDataConfig, Party party)
        {
            _sceneController = sceneController;
            _charactersDataConfig = charactersDataConfig;
            _party = party;
            _partyPanelPresenter = new PartyPanelPresenter(uiCanvasData, uiProviderConfig);
            _confirmationPopupPresenter = new ConfirmationPopupPresenter(uiCanvasData, uiProviderConfig);
        }

        protected override void OnEnter(DataProvider dataProvider)
        {
            _partyIDs = dataProvider.GetData<Dictionary<PartySlotType, int>>();

            _partyPanelPresenter.Enable(new PartyPanelModel(_charactersDataConfig.Characters, _partyIDs));

            _partyPanelPresenter.OnCancelButton += () =>
            {
                _confirmationPopupPresenter.Enable(new ConfirmationPopupModel("$CONFIRMATION_CANCEL_CHAR_CHANGING_TEXT"));

                _confirmationPopupPresenter.OnNoButton += () =>
                {
                    _confirmationPopupPresenter.Disable();
                };

                _confirmationPopupPresenter.OnYesButton += () =>
                {
                    _party.SetCurrentDrumsID(_partyIDs[PartySlotType.Drums]);
                    _party.SetCurrentGuitarID(_partyIDs[PartySlotType.Guitar]);
                    _party.SetCurrentBassID(_partyIDs[PartySlotType.Bass]);
                    _party.Save();

                    _sceneController.ChangeState<MainPanelState>(new DataProvider());
                };
            };

            _partyPanelPresenter.OnDoneButton += () =>
            {
                _party.Save();
                _sceneController.ChangeState<MainPanelState>(new DataProvider());
            };

            _partyPanelPresenter.OnDrumsButton += () =>
            {
                _sceneController.ChangeState<CharacterInfoState>(new DataProvider(_partyIDs));
            };

            _partyPanelPresenter.OnGuitarButton += () =>
            {
                _sceneController.ChangeState<CharacterInfoState>(new DataProvider(_partyIDs));
            };

            _partyPanelPresenter.OnBassButton += () =>
            {
                _sceneController.ChangeState<CharacterInfoState>(new DataProvider(_partyIDs));
            };
        }

        protected override void OnEnd(DataProvider dataProvider)
        {
            _partyPanelPresenter.Disable();
            _confirmationPopupPresenter.Disable();
        }
    }
}