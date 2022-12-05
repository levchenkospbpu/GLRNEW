using System;
using System.Collections.Generic;
using Data.SceneActions;
using SceneControllers.HomeScene;

namespace SceneControllers
{
    public abstract class SceneControllerBase : ISceneController
    {
        protected readonly Dictionary<HomeActionType, Action> Actions = new();

        public abstract void Start();

        protected void NextAction(HomeActionType type)
        {
            if (!Actions.TryGetValue(type, out var action))
            {
                throw new KeyNotFoundException($"SceneController: Key {type} not found");
            }
            action?.Invoke();
        }
    }
}