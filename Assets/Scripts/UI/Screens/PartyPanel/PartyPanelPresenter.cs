using Common.MVP;
using UI.Canvas;
using UnityEngine;

namespace UI.Screens.PartyPanel
{
    public class PartyPanelPresenter : BasePresenter<PartyPanelView, PartyPanelModel>
    {
        protected override GameObject Prefab { get; }
        protected override Transform Parent { get; }

        public PartyPanelPresenter(UiCanvasData uiCanvasData, UIProviderConfig uiProviderConfig) : base(uiCanvasData, uiProviderConfig)
        {
            Parent = uiCanvasData.Screens;
        }
    }
}