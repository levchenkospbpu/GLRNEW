using SceneControllers;
using UI;
using UI.Canvas;
using UI.Screens.HomeMainPanel;

namespace States.HomeScene
{
    public class MainPanelState : State
    {
        private readonly ISceneController _sceneController;
        private readonly HomeMainPanelPresenter _homeMainPanelPresenter;
        
        public MainPanelState(ISceneController sceneController, UIProviderConfig uiProviderConfig, UiCanvasData uiCanvasData)
        {
            _sceneController = sceneController;
            _homeMainPanelPresenter = new HomeMainPanelPresenter(uiProviderConfig.HomeMainPanel, uiCanvasData.Screens);
        }

        protected override void OnEnter()
        {
            _homeMainPanelPresenter.Enable();

            _homeMainPanelPresenter.OnCustomizationButton += () =>
            {
                _sceneController.ChangeState<CustomizationPanelState>();
            };

            _homeMainPanelPresenter.OnMapButton += () =>
            {
                _sceneController.ChangeState<MapPanelState>();
            };

            _homeMainPanelPresenter.OnPartyButton += () =>
            {
                _sceneController.ChangeState<PartyPanelState>();
            };
        }

        protected override void OnEnd()
        {
            _homeMainPanelPresenter.Disable();
        }
    }
}