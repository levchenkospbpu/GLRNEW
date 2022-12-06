using UI;
using UnityEngine;

namespace States
{
    public class MainPanelState : State
    {
        private readonly UIProvider _uiProvider;

        public MainPanelState(UIProvider uiProvider)
        {
            _uiProvider = uiProvider;
        }

        protected override void OnEnter()
        {
            _uiProvider.Show(typeof(MainPanel), GameObject.FindGameObjectWithTag("MainCanvas").transform);
        }

        protected override void OnEnd()
        {
            
        }
    }
}