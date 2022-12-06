using SceneControllers;
using UnityEngine;
using VContainer;

namespace GameScripts
{
    public class AuthorizationState : State
    {
        private readonly ISceneController _sceneController;

        public AuthorizationState(ISceneController sceneController)
        {
            _sceneController = sceneController;
        }

        protected override void OnEnter()
        {
            var accessToken = PlayerPrefs.GetString(PlayerPrefsKeys.AccessToken, string.Empty);

            if (string.IsNullOrEmpty(accessToken))
            {
                PlayerPrefs.SetString(PlayerPrefsKeys.AccessToken, Random.Range(0,100).ToString());
                _sceneController.ChangeState<AvatarState>();
            }
            else
            {
                _sceneController.ChangeState<MainPanelState>();
            }
        }

        protected override void OnEnd()
        {
            
        }
    }
}