using VContainer;

namespace SceneControllers.HomeScene
{
    public partial class HomeController : SceneControllerBase
    {
        [Inject] private readonly UIProvider _uiProvider;

        public override void Start()
        {
            Actions.Add(HomeActionType.CheckAuthorization, CheckAuthorization);
            Actions.Add(HomeActionType.AvatarPanel, ShowAvatarPanel);
            Actions.Add(HomeActionType.MainPanel, ShowMainPanel);
            
            NextAction(HomeActionType.CheckAuthorization);
        }
    }
}