using GameScripts;
using VContainer;

namespace SceneControllers
{
    public class HomeController : SceneControllerBase
    {
        private readonly IContainerBuilder _containerBuilder;

        public HomeController(IContainerBuilder containerBuilder)
        {
            _containerBuilder = containerBuilder;
        }

        public override void Start()
        {
            var authorizationGameScript = new AuthorizationGameScript();
            _containerBuilder.RegisterInstance(authorizationGameScript).AsSelf();
            GameScripts.Add(authorizationGameScript);
            
            var avatarGameScript = new AvatarGameScript();
            _containerBuilder.RegisterInstance(avatarGameScript).AsSelf();
            GameScripts.Add(avatarGameScript);
            
            var mainPanelGameScript = new MainPanelGameScript();
            _containerBuilder.RegisterInstance(mainPanelGameScript).AsSelf();
            GameScripts.Add(mainPanelGameScript);
            
            StartGameScript(typeof(AuthorizationGameScript));
        }
    }
}