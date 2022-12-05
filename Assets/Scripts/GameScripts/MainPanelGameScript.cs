using UnityEngine;
using VContainer;

namespace GameScripts
{
    public class MainPanelGameScript : GameScriptBase
    {
        [Inject] private readonly UIProvider _uiProvider;
        
        public override void OnStart()
        {
            _uiProvider.Show(typeof(MainPanel), GameObject.FindGameObjectWithTag("MainCanvas").transform);
        }

        public override void OnDestroy()
        {
            
        }
    }
}