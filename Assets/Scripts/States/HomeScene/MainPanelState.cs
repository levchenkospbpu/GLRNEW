using SceneControllers;
using UI;
using UI.Canvas;
using UI.Screens.HomeMainPanel;

namespace States.HomeScene
{
    public class MainPanelState : State
    {
        private readonly ISceneController _sceneController;
        private readonly Party _party;
        private readonly HomeMainPanelPresenter _homeMainPanelPresenter;
        
        public MainPanelState(ISceneController sceneController, UIProviderConfig uiProviderConfig, UiCanvasData uiCanvasData, Party party)
        {
            _party = party;
            _sceneController = sceneController;
            _homeMainPanelPresenter = new HomeMainPanelPresenter(uiCanvasData, uiProviderConfig);
        }

        protected override void OnEnter(DataProvider dataProvider)
        {
            _homeMainPanelPresenter.Enable();

            _homeMainPanelPresenter.OnCustomizationButton += () =>
            {
                _sceneController.ChangeState<CustomizationPanelState>(new DataProvider());
            };

            _homeMainPanelPresenter.OnMapButton += () =>
            {
                _sceneController.ChangeState<MapPanelState>(new DataProvider());
            };

            _homeMainPanelPresenter.OnPartyButton += () =>
            {
                _sceneController.ChangeState<PartyPanelState>(new DataProvider(_party.PartyIDs));
            };
        }

        protected override void OnEnd(DataProvider dataProvider)
        {
            _homeMainPanelPresenter.Disable();
        }
    }
}