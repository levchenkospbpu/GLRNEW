using States;
using VContainer;

namespace SceneControllers
{
    public abstract class SceneControllerBase : ISceneController
    {
        private readonly IObjectResolver _resolver;
        private IState _previousState;

        protected SceneControllerBase(IObjectResolver resolver)
        {
            _resolver = resolver;
        }

        public abstract void Start();

        public T ChangeState<T>(DataProvider dataProvider) where T : IState
        {
            _previousState?.End(dataProvider);
            var state = _resolver.Resolve<T>();
            _previousState = state;
            state.Enter(dataProvider);
            return state;
        }
    }
}