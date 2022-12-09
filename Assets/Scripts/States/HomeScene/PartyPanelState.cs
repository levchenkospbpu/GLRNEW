using SceneControllers;
using UI;
using UI.Canvas;
using UI.Popups.ConfirmationPopup;
using UI.Screens.HomeMainPanel;
using UI.Screens.PartyPanel;

namespace States.HomeScene
{
    public class PartyPanelState : State
    {
        private readonly ISceneController _sceneController;

        private readonly PartyPanelPresenter _partyPanelPresenter;
        private readonly ConfirmationPopupPresenter _confirmationPopupPresenter;

        public PartyPanelState(ISceneController sceneController, UIProviderConfig uiProviderConfig, UiCanvasData uiCanvasData)
        {
            _sceneController = sceneController;
            _partyPanelPresenter = new PartyPanelPresenter(uiCanvasData, uiProviderConfig);
            _confirmationPopupPresenter = new ConfirmationPopupPresenter(uiCanvasData, uiProviderConfig);
        }
        
        protected override void OnEnter()
        {
            _partyPanelPresenter.Enable();

            _partyPanelPresenter.OnDoneButton += () =>
            {
                _sceneController.ChangeState<MainPanelState>();
            };

            _partyPanelPresenter.OnCancelButton += () =>
            {
                _confirmationPopupPresenter.Enable(new ConfirmationPopupModel("$CONFIRMATION_CANCEL_CHAR_CHANGING_TEXT"));

                _confirmationPopupPresenter.OnNoButton += () =>
                {
                    _confirmationPopupPresenter.Disable();
                };

                _confirmationPopupPresenter.OnYesButton += () =>
                {
                    //Save party

                    _sceneController.ChangeState<MainPanelState>();
                };
            };
        }

        protected override void OnEnd()
        {
            _partyPanelPresenter.Disable();
            _confirmationPopupPresenter.Disable();
        }
    }
}