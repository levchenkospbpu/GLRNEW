using System;
using VContainer.Unity;

namespace SceneControllers
{
    public interface ISceneController : IStartable
    {
        void StartGameScript(Type type);
    }
}