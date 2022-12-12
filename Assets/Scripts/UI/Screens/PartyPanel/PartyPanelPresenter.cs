using Common.MVP;
using Data;
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

            InitizlizeBanners();
        }

        protected override void OnDisable()
        {
            OnDoneButton = null;
            OnCancelButton = null;
            OnDrumsButton = null;
            OnGuitarButton = null;
            OnBassButton = null;
        }
        
        public void InitizlizeBanners()
        {
            View.DrumsButton.image.sprite = Model.Characters[Model.PartyIDs[PartySlotType.Drums]].Banner;
            View.GuitarButton.image.sprite = Model.Characters[Model.PartyIDs[PartySlotType.Guitar]].Banner;
            View.BassButton.image.sprite = Model.Characters[Model.PartyIDs[PartySlotType.Bass]].Banner;
        }
    }
}