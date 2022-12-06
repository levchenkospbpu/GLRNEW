using System;
using Common.MVP;
using UnityEngine;

namespace UI.Popups.ConfirmationPopup
{
    public class ConfirmationPopupPresenter : BasePresenter<ConfirmationPopupView, ConfirmationPopupModel>
    {
        public Action OnYesButton;
        public Action OnNoButton;
        
        public ConfirmationPopupPresenter(GameObject prefab, Transform parent) : base(prefab, parent)
        {
        
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