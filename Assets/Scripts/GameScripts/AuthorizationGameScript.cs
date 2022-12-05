using SceneControllers;
using UnityEngine;
using VContainer;

namespace GameScripts
{
    public class AuthorizationGameScript : GameScriptBase
    {
        [Inject] private readonly ISceneController _sceneController;
        
        public override void OnStart()
        {
            var accessToken = PlayerPrefs.GetString(PlayerPrefsKeys.AccessToken, string.Empty);

            if (string.IsNullOrEmpty(accessToken))
            {
                PlayerPrefs.SetString(PlayerPrefsKeys.AccessToken, Random.Range(0,100).ToString());
                _sceneController.StartGameScript(typeof(AvatarGameScript));
            }
            else
            {
                _sceneController.StartGameScript(typeof(MainPanelGameScript));
            }
            
            StopThisGameScript();
        }

        public override void OnDestroy()
        {
            
        }
    }
}