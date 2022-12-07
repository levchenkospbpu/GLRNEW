using System;
using Common.MVP;
using Customization;
using UI.Canvas;
using UnityEngine;

namespace UI.Screens.HomeMainPanel
{
    public class HomeMainPanelPresenter : BasePresenter<HomeMainPanelView, HomeMainPanelModel>
    {
        protected override GameObject Prefab { get; }
        protected override Transform Parent { get; }
        
        public Action OnPartyButton;
        public Action OnCustomizationButton;
        public Action OnMapButton;
        
        public HomeMainPanelPresenter(UiCanvasData uiCanvasData, UIProviderConfig uiProviderConfig) : base(uiCanvasData, uiProviderConfig)
        {
            Prefab = uiProviderConfig.HomeMainPanel;
            Parent = uiCanvasData.Screens;
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