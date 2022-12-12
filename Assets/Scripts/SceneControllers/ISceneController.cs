using States;
using VContainer.Unity;

namespace SceneControllers
{
    public interface ISceneController : IStartable
    {
        
        T ChangeState<T>(DataProvider dataProvider) where T : IState;
    }
}