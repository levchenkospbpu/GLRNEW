using SceneControllers;
using UnityEngine;

namespace States
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