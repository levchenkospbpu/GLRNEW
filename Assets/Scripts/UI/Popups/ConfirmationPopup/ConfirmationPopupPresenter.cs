using System;
using Common.MVP;
using UI.Canvas;
using UnityEngine;

namespace UI.Popups.ConfirmationPopup
{
    public class ConfirmationPopupPresenter : BasePresenter<ConfirmationPopupView, ConfirmationPopupModel>
    {
        protected override GameObject Prefab { get; }
        protected override Transform Parent { get; }
        
        public Action OnYesButton;
        public Action OnNoButton;
        
        public ConfirmationPopupPresenter(UiCanvasData uiCanvasData, UIProviderConfig uiProviderConfig) : base(uiCanvasData, uiProviderConfig)
        {
            Prefab = uiProviderConfig.ConfirmationPopup;
            Parent = uiCanvasData.Popups;
        }

        protected override void OnEnable()
        {
            View.Description.text = Model.Description;
            View.YesButton.onClick.AddListener(() => OnYesButton?.Invoke());
            View.NoButton.onClick.AddListener(() => OnNoButton?.Invoke());
        }

        protected override void OnDisable()
        {
            OnYesButton = null;
            OnNoButton = null;
        }
    }
}