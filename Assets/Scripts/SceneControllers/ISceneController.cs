using States;
using VContainer.Unity;

namespace SceneControllers
{
    public interface ISceneController : IStartable
    {
        
        T ChangeState<T>() where T : IState;
    }
}