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

            script.IsEnabled = true;
            script.OnStart();
        }

        public void StopGameScript(Type type)
        {
            var script = GameScripts.FirstOrDefault(t => t.GetType() == type);
            if (script == null)
            {
                throw new Exception($"SceneController: Game Script {type} not found");
            }

            if (script.IsEnabled)
            {
                script.IsEnabled = false;
                script.OnDestroy();
            }
        }
    }
}