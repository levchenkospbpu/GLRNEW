using System;
using System.Collections.Generic;
using System.Linq;
using GameScripts;

namespace SceneControllers
{
    public abstract class SceneControllerBase : ISceneController
    {
        protected readonly List<GameScriptBase> GameScripts = new();

        public abstract void Start();

        public void StartGameScript(Type type)
        {
            var script = GameScripts.FirstOrDefault(t => t.GetType() == type);
            if (script == null)
            {
                throw new Exception($"SceneController: Game Script {type} not found");
            }
            script.OnStart();
        }
    }
}