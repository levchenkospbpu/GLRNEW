using SceneControllers;
using UnityEngine;

namespace States.HomeScene
{
    public class AuthorizationState : State
    {
        private readonly ISceneController _sceneController;

        public AuthorizationState(ISceneController sceneController)
        {
            _sceneController = sceneController;
        }

        protected override void OnEnter(DataProvider dataProvider)
        {
            var accessToken = PlayerPrefs.GetString(PlayerPrefsKeys.AccessToken, string.Empty);

            if (string.IsNullOrEmpty(accessToken))
            {
                _sceneController.ChangeState<AvatarState>(new DataProvider());
            }
            else
            {
                _sceneController.ChangeState<MainPanelState>(new DataProvider());
            }
        }

        protected override void OnEnd(DataProvider dataProvider)
        {
            
        }
    }
}