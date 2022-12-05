using UnityEngine;

namespace SceneControllers.HomeScene
{
    public partial class HomeController
    {
        private void ShowMainPanel()
        {
            _uiProvider.Show(typeof(MainPanel), GameObject.FindGameObjectWithTag("MainCanvas").transform);
        }
    }
}