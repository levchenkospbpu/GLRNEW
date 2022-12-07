using SceneControllers;
using UI;
using UI.Canvas;
using UI.Screens.PartyPanel;

namespace States.HomeScene
{
    public class PartyPanelState : State
    {
        private readonly ISceneController _sceneController;
        private readonly PartyPanelPresenter _partyPanelPresenter;
        
        public PartyPanelState(ISceneController sceneController, UIProviderConfig uiProviderConfig, UiCanvasData uiCanvasData)
        {
            _sceneController = sceneController;
            _partyPanelPresenter = new PartyPanelPresenter(uiCanvasData, uiProviderConfig);
        }
        
        protected override void OnEnter()
        {
            _partyPanelPresenter.Enable();
        }

        protected override void OnEnd()
        {
            _partyPanelPresenter.Disable();
        }
    }
}