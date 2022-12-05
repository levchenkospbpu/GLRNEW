using UnityEngine;

namespace SceneControllers.HomeScene
{
    public partial class HomeController
    {
        private void CheckAuthorization()
        {
            var accessToken = PlayerPrefs.GetString(PlayerPrefsKeys.AccessToken, string.Empty);

            if (string.IsNullOrEmpty(accessToken))
            {
                PlayerPrefs.SetString(PlayerPrefsKeys.AccessToken, Random.Range(0,100).ToString());
                NextAction(HomeActionType.AvatarPanel);
            }
            else
            {
                NextAction(HomeActionType.MainPanel);
            }
        }
    }
}