using System;
using Common.MVP;
using UnityEngine;

namespace UI.Screens.HomeMainPanel
{
    public class HomeMainPanelPresenter : BasePresenter<HomeMainPanelView, HomeMainPanelModel>
    {
        public Action OnPartyButton;
        public Action OnCustomizationButton;
        public Action OnMapButton;
        
        public HomeMainPanelPresenter(GameObject prefab, Transform parent) : base(prefab, parent)
        {
            
        }

        protected override void OnEnable()
        {
            View.CustomizationButton.onClick.AddListener(() => OnCustomizationButton?.Invoke());
            View.PartyButton.onClick.AddListener(() => OnPartyButton?.Invoke());
            View.MapButton.onClick.AddListener(() => OnMapButton?.Invoke());
        }

        protected override void OnDisable()
        {
            OnPartyButton = null;
            OnCustomizationButton = null;
            OnMapButton = null;
        }
    }
}