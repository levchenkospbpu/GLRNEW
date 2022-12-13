using States;
using States.HomeScene;
using VContainer;

namespace SceneControllers
{
    public class HomeController : SceneControllerBase
    {
        private readonly IContainerBuilder _containerBuilder;

        public HomeController(IObjectResolver resolver) : base(resolver)
        {
            
        }

        public override void Start()
        {
            ChangeState<AuthorizationState>(new DataProvider());
        }
    }
}