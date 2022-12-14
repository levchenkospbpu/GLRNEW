using Data;
using SceneControllers;
using System.Collections.Generic;
using UI;
using UI.Canvas;
using UI.Popups.ConfirmationPopup;
using UI.Screens.CharacterInfo;
using UI.Screens.HomeMainPanel;
using UI.Screens.PartyPanel;
using UnityEngine.Rendering.LookDev;

namespace States.HomeScene
{
    public class PartyPanelState : State
    {
        private readonly ISceneController _sceneController;
        private readonly CharactersDataConfig _charactersDataConfig;
        private readonly Party.Party _party;

        private readonly PartyPanelPresenter _partyPanelPresenter;
        private readonly CharacterInfoPresenter _characterInfoPresenter;
        private readonly ConfirmationPopupPresenter _confirmationPopupPresenter;

        private Dictionary<PartySlotType, int> _startPartyIDs = new();

        public PartyPanelState(ISceneController sceneController, UIProviderConfig uiProviderConfig, UiCanvasData uiCanvasData, CharactersDataConfig charactersDataConfig, Party.Party party)
        {
            _sceneController = sceneController;
            _charactersDataConfig = charactersDataConfig;
            _party = party;
            _partyPanelPresenter = new PartyPanelPresenter(uiCanvasData, uiProviderConfig);
            _characterInfoPresenter = new CharacterInfoPresenter(uiCanvasData, uiProviderConfig);
            _confirmationPopupPresenter = new ConfirmationPopupPresenter(uiCanvasData, uiProviderConfig);
        }

        protected override void OnEnter(DataProvider dataProvider)
        {
            _startPartyIDs = new Dictionary<PartySlotType, int>(dataProvider.GetData<Dictionary<PartySlotType, int>>());

            ShowPartyPanel();
        }

        private void ShowPartyPanel()
        {
            _partyPanelPresenter.Enable(new PartyPanelModel(_charactersDataConfig.Characters, _party.PartyIDs));

            _partyPanelPresenter.OnCancelButton += () =>
            {
                _confirmationPopupPresenter.Enable(new ConfirmationPopupModel("$CONFIRMATION_CANCEL_CHAR_CHANGING_TEXT"));

                _confirmationPopupPresenter.OnNoButton += () =>
                {
                    _confirmationPopupPresenter.Disable();
                };

                _confirmationPopupPresenter.OnYesButton += () =>
                {
                    _party.SetID(PartySlotType.Drums, _startPartyIDs[PartySlotType.Drums]);
                    _party.SetID(PartySlotType.Guitar, _startPartyIDs[PartySlotType.Guitar]);
                    _party.SetID(PartySlotType.Bass, _startPartyIDs[PartySlotType.Bass]);
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
                ShowCharacterInfo(PartySlotType.Drums);
                _partyPanelPresenter.Disable();
            };

            _partyPanelPresenter.OnGuitarButton += () =>
            {
                ShowCharacterInfo(PartySlotType.Guitar);
                _partyPanelPresenter.Disable();
            };

            _partyPanelPresenter.OnBassButton += () =>
            {
                ShowCharacterInfo(PartySlotType.Bass);
                _partyPanelPresenter.Disable();
            };
        }

        private void ShowCharacterInfo(PartySlotType changableSlot)
        {
            _characterInfoPresenter.Enable(new CharacterInfoModel(_charactersDataConfig.Characters, changableSlot));

            _characterInfoPresenter.OnChooseButton += (PartySlotType slotType, int id) =>
            {
                _party.SetID(slotType, id);
                ShowPartyPanel();
                _characterInfoPresenter.Disable();
            };
        }

        protected override void OnEnd(DataProvider dataProvider)
        {
            _partyPanelPresenter.Disable();
            _confirmationPopupPresenter.Disable();
        }
    }
}