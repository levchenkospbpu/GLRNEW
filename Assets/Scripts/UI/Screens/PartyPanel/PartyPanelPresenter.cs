using Common.MVP;
using System;
using UI.Canvas;
using UnityEngine;

namespace UI.Screens.PartyPanel
{
    public class PartyPanelPresenter : BasePresenter<PartyPanelView, PartyPanelModel>
    {
        protected override GameObject Prefab { get; }
        protected override Transform Parent { get; }

        public Action OnDoneButton;
        public Action OnCancelButton;
        public Action OnDrumsButton;
        public Action OnGuitarButton;
        public Action OnBassButton;

        public PartyPanelPresenter(UiCanvasData uiCanvasData, UIProviderConfig uiProviderConfig) : base(uiCanvasData, uiProviderConfig)
        {
            Prefab = uiProviderConfig.PartyPanel;
            Parent = uiCanvasData.Screens;
        }

        protected override void OnEnable()
        {
            View.DoneButton.onClick.AddListener(() => OnDoneButton?.Invoke());
            View.CancelButton.onClick.AddListener(() => OnCancelButton?.Invoke());
            View.DrumsButton.onClick.AddListener(() => OnDrumsButton?.Invoke());
            View.GuitarButton.onClick.AddListener(() => OnGuitarButton?.Invoke());
            View.BassButton.onClick.AddListener(() => OnBassButton?.Invoke());
        }

        protected override void OnDisable()
        {
            OnDoneButton = null;
            OnCancelButton = null;
            OnDrumsButton = null;
            OnGuitarButton = null;
            OnBassButton = null;
        }
    }
}